using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Database;

namespace Server
{
    class Program
    {
        // Список подключенных клиентов
        static List<ClientData> clients;

        static void Main(string[] args)
        {
            clients = new List<ClientData>();
            string ipAddress = "0.0.0.0";
            int port = 9000;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket client;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            server.Bind(endPoint);
            server.Listen(100);
            Console.WriteLine("Сервер запущен на порту {0}...", port);

            while (true)
            {
                Console.WriteLine("Кол-во подключенных клиентов = {0}", clients.Count);
                client = server.Accept();
                Console.WriteLine("Клиент {0} подсоединился", client.RemoteEndPoint.ToString());
                ClientData clientData = new ClientData(client);
                ThreadPool.QueueUserWorkItem(Communicate, clientData);
                clients.Add(clientData);
            }
        }

        private static void Communicate(object state)
        {
            ClientData clientData = (ClientData)state;
            bool loggedIn = false;
            string[] request;
            string response = "";
            string[] responseSeparator = new string[] { "[MESSAGE]" };
            string[] responseContentSeparator = new string[] { "[CONTENT]" };

            #region Presession
            while (!loggedIn)
            {
                try
                {
                    request = HandleRequest(clientData).Split(responseContentSeparator, StringSplitOptions.RemoveEmptyEntries);
                    response = ProcessPresessionRequest(clientData, request);
                    HandleResponse(clientData, response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clients.Remove(clientData);
                    return;
                }

                if (response == "Добро пожаловать!")
                {
                    loggedIn = true;
                }
            }
            #endregion

            #region Session
            HandleResponse(clientData, clientData.Email + "[MESSAGE]");
            HandleResponse(clientData, GetVoteQuestion(clientData));
            SendStatistics(clientData);

            while (loggedIn)
            {
                try
                {
                    request = HandleRequest(clientData).Split(responseContentSeparator, StringSplitOptions.RemoveEmptyEntries);
                    ProcessSessionRequest(clientData, request);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clients.Remove(clientData);
                    return;
                }
            }
            #endregion
        }

        // Обработка пресессионного запроса от клиента
        private static string ProcessPresessionRequest(ClientData clientData, string[] request)
        {
            string email = request[0];
            string password = request[1];
            string action = request[2];
            int registeredUsers;
            string response = "";

            registeredUsers = UserLookup(email);

            if (action == "SignUp")
            {
                if (registeredUsers == 0)
                {
                    response = UserCreate(email, password);
                }
                else
                {
                    response = "Пользователь с таким email адресом уже зарегистрирован.";
                }
            }
            else if (action == "SignIn")
            {
                if (registeredUsers == 0)
                {
                    response = "Пользователь с таким email адресом не зарегистрирован.";
                }
                else
                {
                    response = UserLogIn(email, password);
                    if (response == "Добро пожаловать!")
                    {
                        clientData.Email = email;
                    }
                }
            }

            return response;
        }

        #region Session
        // Обработка сессионного запроса от клиента
        private static void ProcessSessionRequest(ClientData clientData, string[] request)
        {
            // Голосование, изменение личных данных
            if (request.Length == 2)
            {
                if (request[1] == "ChangeEmail")
                {
                    ChangeEmail(clientData, request);
                }
                else if (request[1] == "ChangePassword")
                {
                    UpdatePassword(clientData, request);
                }
                else
                {
                    ProcessVote(clientData, request);
                }                
            }
            // Задание/удаление вопроса
            else if (request.Length == 1)
            {
                ProcessQuestion(clientData, request);
            }
        }

        private static void ChangeEmail(ClientData clientData, string[] request)
        {
            int registeredUsers = UserLookup(request[0]);

            if (registeredUsers == 0)
            {
                UpdateEmail(clientData, request);
            }
            else
            {
                HandleResponse(clientData, "Пользователь с таким email адресом уже зарегистрирован.[CONTENT]ChangeEmail[MESSAGE]");
            }
        }

        // Обработка голосования
        private static void ProcessVote(ClientData clientData, string[] request)
        {
            if (QuestionLookup(clientData) == 0)
            {
                return;
            }

            WriteAnswer(clientData, request);

            User user = GetVoteQuestionOwner(clientData);
            foreach (ClientData client in clients)
            {
                if (client.Email == user.Email)
                {
                    if (client.Client.Connected)
                    {
                        SendStatistics(client);
                    }
                }
            }

            HandleResponse(clientData, GetVoteQuestion(clientData));
        }

        // Обработка операций с вопросом
        private static void ProcessQuestion(ClientData clientData, string[] request)
        {
            if (request[0] != "Remove")
            {
                CreateQuestion(clientData, request[0]);

                foreach (ClientData client in clients)
                {
                    if (client.Email != clientData.Email && client.Client.Connected)
                    {
                        HandleResponse(client, GetVoteQuestion(client));
                    }
                }        
            }
            else if (request[0] == "Remove")
            {
                RemoveQuestion(clientData);
            }
        }

        // Отправка статистики
        private static void SendStatistics(ClientData clientData)
        {
            List<List<string>> stats = GetStats(clientData);
            string statistics = "";

            if (stats.Count > 1)
            {                
                foreach (string stat in stats[0])
                {
                    statistics += stat + "[CONTENT]";
                }
                HandleResponse(clientData, statistics + "Stats[MESSAGE]");

                foreach (string comment in stats[1])
                {
                    HandleResponse(clientData, comment + "[CONTENT]Comment[MESSAGE]");
                }
            }
            else if (stats.Count > 0)
            {
                foreach (string stat in stats[0])
                {
                    statistics += stat + "[CONTENT]";
                }
                HandleResponse(clientData, statistics + "Stats[MESSAGE]");
            }
            else
            {
                HandleResponse(clientData, "None[CONTENT]Stats[MESSAGE]");
            }
        }
        #endregion

        #region Работа с базой данных
        #region Presession
        // Авторизация пользователя
        private static string UserLogIn(string email, string password)
        {
            using (Context context = new Context())
            {
                User[] loggedInUser = (from Users in context.Users where Users.Email == email && Users.Password == password select Users).ToArray();

                if (loggedInUser.Length == 0)
                {
                    return "Неверный пароль!";
                }
                else
                {                        
                    return "Добро пожаловать!";
                }
            }
        }

        // Создание нового пользователя
        private static string UserCreate(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;

            using (Context context = new Context())
            {
                UserRepository userRepository = new UserRepository(context);
                userRepository.Create(user);
                return "OK!";
            }
        }

        // Проверка пользователя на существование
        private static int UserLookup(string email)
        {
            using (Context context = new Context())
            {
                User[] existingUser = (from Users in context.Users where Users.Email == email select Users).ToArray();
                return existingUser.Length;
            }
        }
        #endregion

        #region Session
        // Поиск вопроса, на который отвечает пользователь
        private static int QuestionLookup(ClientData clientData)
        {
            using (Context context = new Context())
            {
                Question[] voteQuestion = (from Questions in context.Questions where Questions.Id == clientData.VoteQuestionId select Questions).ToArray();
                return voteQuestion.Length;
            }            
        }

        // Поиск вопроса для голосования
        private static string GetVoteQuestion(ClientData clientData)
        {
            using (Context context = new Context())
            {
                User[] currentUsers = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUsers.First();

                Question[] allVoteQuestions = (from Questions in context.Questions where Questions.Id != user.QuestionId select Questions).ToArray();
                foreach (Question question in allVoteQuestions)
                {
                    QA[] hasAnswers = (from QAs in context.QAs where QAs.QuestionId == question.Id select QAs).ToArray();
                    if (hasAnswers.Length == 0)
                    {
                        clientData.VoteQuestionId = question.Id;
                        return question.Text + "[CONTENT]Question[MESSAGE]";
                    }
                    else
                    {
                        QA[] hasUsersAnswer = (from QAs in context.QAs where QAs.QuestionId == question.Id && QAs.UserId == user.Id select QAs).ToArray();
                        if (hasUsersAnswer.Length == 0)
                        {
                            clientData.VoteQuestionId = question.Id;
                            return question.Text + "[CONTENT]Question[MESSAGE]";
                        }
                    }
                }

                return "None[CONTENT]Question[MESSAGE]";
            }
        }

        // Получение статистики к вопросу пользователя
        private static List<List<string>> GetStats(ClientData clientData)
        {
            using (Context context = new Context())
            {
                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();

                if (user.QuestionId != 0)
                {
                    List<List<string>> stats = new List<List<string>>();
                    Question[] userQuestion = (from Questions in context.Questions where Questions.Id == user.QuestionId select Questions).ToArray();
                    Question question = userQuestion.First();
                    stats.Add(new List<string> { question.Text, question.Yes.ToString(), question.No.ToString() });

                    Comment[] questionComments = (from Comments in context.Comments
                                                  where Comments.QuestionId == question.Id
                                                     && Comments.Text != "Комментарий"
                                                  select Comments).ToArray();

                    if (questionComments.Length > 0)
                    {
                        List<string> comments = new List<string>();
                        foreach (Comment comment in questionComments)
                        {
                            comments.Add(comment.Text + "[CONTENT]" + comment.YesNo);
                        }
                        stats.Add(comments);
                    }

                    return stats;
                }
                else
                {
                    return new List<List<string>>();
                }
            }
        }

        // Удаление вопроса пользователя
        private static void RemoveQuestion(ClientData clientData)
        {
            using (Context context = new Context())
            {
                UserRepository userRepository = new UserRepository(context);
                QuestionRepository questionRepository = new QuestionRepository(context);
                CommentRepository commentRepository = new CommentRepository(context);
                QARepository qaRepository = new QARepository(context);

                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();

                QA[] answers = (from QAs in context.QAs where QAs.QuestionId == user.QuestionId select QAs).ToArray();
                if (answers.Length > 0)
                {
                    foreach (QA answer in answers)
                    {
                        qaRepository.Delete(answer);
                    }
                }

                Comment[] comments = (from Comments in context.Comments where Comments.QuestionId == user.QuestionId select Comments).ToArray();
                if (comments.Length > 0)
                {
                    foreach (Comment comment in comments)
                    {
                        commentRepository.Delete(comment);
                    }
                }

                Question[] userQuestion = (from Questions in context.Questions where Questions.Id == user.QuestionId select Questions).ToArray();
                Question question = userQuestion.First();
                questionRepository.Delete(question);

                user.QuestionId = 0;
                userRepository.Update(user);
            }
        }

        // Создание вопроса пользователя
        private static void CreateQuestion(ClientData clientData, string questionText)
        {
            Question question = new Question();
            question.Text = questionText;
            using (Context context = new Context())
            {
                QuestionRepository questionRepository = new QuestionRepository(context);
                UserRepository userRepository = new UserRepository(context);

                questionRepository.Create(question);
                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();
                user.QuestionId = question.Id;
                userRepository.Update(user);
            }
        }

        // Запись ответа на вопрос голосования
        private static void WriteAnswer(ClientData clientData, string[] request)
        {
            using (Context context = new Context())
            {
                QuestionRepository questionRepository = new QuestionRepository(context);
                QARepository qaRepository = new QARepository(context);
                CommentRepository commentRepository = null;
                if (request[1] != "Комментарий")
                {
                    commentRepository = new CommentRepository(context);
                }

                Question[] voteQuestion = (from Questions in context.Questions where Questions.Id == clientData.VoteQuestionId select Questions).ToArray();
                Question question = voteQuestion.First();
                if (request[0] == "Yes")
                {
                    question.Yes = question.Yes + 1;
                }
                else if (request[0] == "No")
                {
                    question.No = question.No + 1;
                }
                questionRepository.Update(question);

                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();
                QA qa = new QA();
                qa.QuestionId = clientData.VoteQuestionId;
                qa.UserId = user.Id;
                qaRepository.Create(qa);

                if (commentRepository != null)
                {
                    Comment comment = new Comment();
                    comment.Text = request[1];
                    comment.QuestionId = clientData.VoteQuestionId;
                    comment.YesNo = request[0];
                    commentRepository.Create(comment);
                }
            }
        }

        // Поиск владельца вопроса голосования
        private static User GetVoteQuestionOwner(ClientData clientData)
        {
            using (Context context = new Context())
            {
                User[] voteQuestionOwner = (from Users in context.Users where Users.QuestionId == clientData.VoteQuestionId select Users).ToArray();
                return voteQuestionOwner.First();
            }
        }

        // Изменение пароля
        private static void UpdatePassword(ClientData clientData, string[] request)
        {
            using (Context context = new Context())
            {
                UserRepository userReposiroty = new UserRepository(context);
                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();
                user.Password = request[0];
                userReposiroty.Update(user);
            }            
        }

        // Изменение email-a
        private static void UpdateEmail(ClientData clientData, string[] request)
        {
            using (Context context = new Context())
            {
                UserRepository userReposiroty = new UserRepository(context);
                User[] currentUser = (from Users in context.Users where Users.Email == clientData.Email select Users).ToArray();
                User user = currentUser.First();
                user.Email = request[0];
                userReposiroty.Update(user);
                clientData.Email = request[0];
            }

            HandleResponse(clientData, "Email успешно обновлен.[CONTENT]ChangeEmail[MESSAGE]");
        }
        #endregion
        #endregion

        #region Связь с клиентом
        // Отправка ответа клиенту
        private static void HandleResponse(ClientData clientData, string response)
        {
            clientData.Client.Send(Encoding.Default.GetBytes(response));
        }

        // Получение запроса от клиента
        private static string HandleRequest(ClientData clientData)
        {
            int readData;
            int requestSize = 1024 * 33;
            byte[] request = new byte[requestSize];

            readData = clientData.Client.Receive(request);

            return Encoding.Default.GetString(request, 0, readData);
        }
        #endregion
    }
}
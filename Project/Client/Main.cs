using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formMain : Form
    {
        public NetworkStream Stream { get; set; }
        // Список комментариев с положительным ответом
        public List<string> CommentsYes { get; set; }
        // Список комментариев с отрицательным ответом
        public List<string> CommentsNo { get; set; }

        public formMain()
        {
            InitializeComponent();

            CommentsYes = new List<string>();
            CommentsNo = new List<string>();

            ThreadPool.QueueUserWorkItem(Recieve);
        }

        private void Recieve(object state)
        {
            string[] responseSeparator = new string[] { "[MESSAGE]" };
            string[] responseContentSeparator = new string[] { "[CONTENT]" };

            while (true)
            {
                try
                {
                    string[] responseData = Response().Split(responseSeparator, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string response in responseData)
                    {
                        string[] responseContent = response.Split(responseContentSeparator, StringSplitOptions.RemoveEmptyEntries);

                        if (responseContent[responseContent.Length - 1] == "Question")
                        {
                            if (responseContent[0] == "None")
                            {
                                continue;
                            }
                            textBoxQuestions.Text = responseContent[0];
                        }
                        else if (responseContent[responseContent.Length - 1] == "Stats")
                        {
                            if (responseContent[0] == "None")
                            {
                                continue;
                            }
                            textBoxQuestion.ReadOnly = true;
                            textBoxQuestion.Text = responseContent[0];
                            linkLabelCommentsYes.Text = responseContent[1];
                            linkLabelCommentsNo.Text = responseContent[2];
                        }
                        else if (responseContent[responseContent.Length - 1] == "Comment")
                        {
                            if (responseContent[1] == "Yes")
                            {
                                CommentsYes.Add(responseContent[0]);
                                continue;
                            }
                            CommentsNo.Add(responseContent[0]);
                        }
                        else if (responseContent[responseContent.Length - 1] == "ChangeEmail")
                        {
                            if (responseContent[0] == "Пользователь с таким email адресом уже зарегистрирован.")
                            {
                                MessageBox.Show(responseContent[0]);
                            }
                            else
                            {
                                MessageBox.Show("Email успешно обновлен.");
                                textBoxEmailCurrent.Text = textBoxEmailNew.Text;
                            }

                            InitiateTextBoxes();
                        }
                        else
                        {
                            textBoxEmailCurrent.Text = responseContent[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Попробуйте зайти позже!");
                    this.Close();
                }
            }
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            
        }

        #region Кнопки
        private void buttonYes_Click(object sender, EventArgs e)
        {
            Vote("Yes");
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Vote("No");
        }

        private void Vote(string option)
        {
            if (textBoxQuestions.Text != "В данный момент вопросов нет...")
            {
                Request(option + "[CONTENT]" + textBoxComment.Text);
               
                textBoxComment.ForeColor = Color.Gray;
                textBoxComment.Text = "Комментарий";
                textBoxQuestions.Text = "В данный момент вопросов нет...";
            }
            else
            {
                MessageBox.Show("В данный момент вопросов нет. Задайте свой вопрос, либо зайдите позже!");
            }
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            if (textBoxQuestion.ReadOnly)
            {
                MessageBox.Show("Чтобы задать новый вопрос, необходимо удалить текущий!");
                return;
            }

            string question;

            if (string.IsNullOrWhiteSpace(textBoxQuestion.Text))
            {
                MessageBox.Show("Введите вопрос!");
                return;
            }
            else
            {
                question = textBoxQuestion.Text;
            }

            Request(question);

            textBoxQuestion.ReadOnly = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (textBoxQuestion.ReadOnly)
            {
                Request("Remove");

                textBoxQuestion.ReadOnly = false;
                textBoxQuestion.Text = "";
                CommentsYes.Clear();
                CommentsNo.Clear();
                linkLabelCommentsYes.Text = "0";
                linkLabelCommentsNo.Text = "0";

                return;
            }

            MessageBox.Show("Чтобы удалить вопрос, нужно сначала его задать!");
        }

        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            if (textBoxEmailNew.Text == "Почта")
            {
                MessageBox.Show("Чтобы изменить текущий email, необходимо ввести новый email!");
                return;
            }

            List<string> errors = new List<string>();
            string action = "ChangeEmail";

            if (EmailCheck(errors))
            {
                try
                {
                    Request(textBoxEmailNew.Text + "[CONTENT]" + action);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                return;
            }

            MessageBox.Show(errors.First());
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPasswordNew.Text == "Пароль" || textBoxPassword2New.Text == "Подтверждение пароля")
            {
                MessageBox.Show("Чтобы изменить текущий пароль, необходимо ввести новый пароль!");
                return;
            }

            List<string> errors = new List<string>();
            string action = "ChangePassword";

            if (PasswordCheck(errors) && PasswordMatchCheck(errors))
            {
                try
                {
                    Request(textBoxPasswordNew.Text + "[CONTENT]" + action);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                MessageBox.Show("Пароль успешно обновлен!");
                InitiateTextBoxes();
                return;
            }

            MessageBox.Show(errors.First());
        }
        #endregion

        #region Связь с сервером
        private void Request(string data)
        {
            byte[] request = Encoding.Default.GetBytes(data);
            Stream.Write(request, 0, request.Length);
        }

        private string Response()
        {
            int recievedData;
            int responseSize = 1024 * 33;
            byte[] response = new byte[responseSize];
            recievedData = Stream.Read(response, 0, response.Length);

            return Encoding.Default.GetString(response, 0, recievedData);
        }
        #endregion

        #region Placeholder-ы
        private void textBoxComment_Enter(object sender, EventArgs e)
        {
            if (textBoxComment.Text == "Комментарий")
            {
                textBoxComment.Text = "";
            }
        }

        private void textBoxComment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxComment.Text))
            {
                textBoxComment.Text = "Комментарий";
                textBoxComment.ForeColor = Color.Gray;
            }
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            textBoxComment.ForeColor = Color.Black;
        }

        private void textBoxEmailNew_Enter(object sender, EventArgs e)
        {
            if (textBoxEmailNew.Text == "Почта")
            {
                textBoxEmailNew.Text = "";
            }
        }

        private void textBoxEmailNew_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmailNew.Text))
            {
                textBoxEmailNew.Text = "Почта";
                textBoxEmailNew.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmailNew_TextChanged(object sender, EventArgs e)
        {
            textBoxEmailNew.ForeColor = Color.Black;
        }

        private void textBoxPasswordNew_Enter(object sender, EventArgs e)
        {
            if (textBoxPasswordNew.Text == "Пароль")
            {
                textBoxPasswordNew.Text = "";
            }
        }

        private void textBoxPasswordNew_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPasswordNew.Text))
            {
                textBoxPasswordNew.Text = "Пароль";
                textBoxPasswordNew.ForeColor = Color.Gray;
                textBoxPasswordNew.PasswordChar = '\0';
            }
        }

        private void textBoxPasswordNew_TextChanged(object sender, EventArgs e)
        {
            textBoxPasswordNew.ForeColor = Color.Black;
            textBoxPasswordNew.PasswordChar = '*';
        }

        private void textBoxPassword2New_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword2New.Text == "Подтверждение пароля")
            {
                textBoxPassword2New.Text = "";
            }
        }

        private void textBoxPassword2New_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword2New.Text))
            {
                textBoxPassword2New.Text = "Подтверждение пароля";
                textBoxPassword2New.ForeColor = Color.Gray;
                textBoxPassword2New.PasswordChar = '\0';
            }
        }

        private void textBoxPassword2New_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword2New.ForeColor = Color.Black;
            textBoxPassword2New.PasswordChar = '*';
        }

        private void InitiateTextBoxes()
        {
            textBoxComment.ForeColor = Color.Gray;
            textBoxComment.Text = "Комментарий";

            textBoxEmailNew.ForeColor = Color.Gray;
            textBoxEmailNew.Text = "Почта";

            textBoxPasswordNew.ForeColor = Color.Gray;
            textBoxPasswordNew.Text = "Пароль";
            textBoxPasswordNew.PasswordChar = '\0';

            textBoxPassword2New.ForeColor = Color.Gray;
            textBoxPassword2New.Text = "Подтверждение пароля";
            textBoxPassword2New.PasswordChar = '\0';
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitiateTextBoxes();
        }
        #endregion

        #region LinkLabel-ы
        private void linkLabelCommentsYes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CommentsYes.Count > 0)
            {
                formComments comments = new formComments();
                comments.YesNoComments = CommentsYes;
                comments.Text = "Комментарии с положительным ответом";
                comments.Show();
            }
            else
            {
                MessageBox.Show("Комментариев с положительным ответом нету!");
            }
        }

        private void linkLabelCommentsNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CommentsNo.Count > 0)
            {
                formComments comments = new formComments();
                comments.YesNoComments = CommentsNo;
                comments.Text = "Комментарии с отрицательным ответом";
                comments.Show();
            }
            else
            {
                MessageBox.Show("Комментариев с отрицательным ответом нету!");
            }
        }
        #endregion

        #region Helper функции: проверка валидности почтового адреса/паролей
        private bool EmailCheck(List<string> errors)
        {
            try
            {
                MailAddress m = new MailAddress(textBoxEmailNew.Text);
                return true;
            }
            catch (FormatException)
            {
                errors.Add("Введенный email адрес имеет неверный формат!");
                return false;
            }
        }

        private bool PasswordCheck(List<string> errors)
        {
            string password = textBoxPasswordNew.Text;
            int minLength = 6;
            int maxLength = 12;

            bool meetsLengthRequirements = password.Length >= minLength && password.Length <= maxLength;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                if (Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
                {
                    foreach (char c in password)
                    {
                        if (char.IsUpper(c)) hasUpperCaseLetter = true;
                        else if (char.IsLower(c)) hasLowerCaseLetter = true;
                        else if (char.IsDigit(c)) hasDecimalDigit = true;
                    }
                }
                else
                {
                    errors.Add("Пароль может содержать только латинские буквы и цифры!");
                    return false;
                }
            }
            else
            {
                errors.Add("Длинна пароля должна быть не менее " + minLength.ToString() + " и не более " + maxLength.ToString() + " символов!");
                return false;
            }

            if (hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit)
            {
                return true;
            }
            errors.Add("Пароль должен состоять из цифр, а также заглавных и прописных букв!");
            return false;
        }

        private bool PasswordMatchCheck(List<string> errors)
        {
            string password = textBoxPasswordNew.Text;
            string password2 = textBoxPassword2New.Text;

            if (password != password2)
            {
                errors.Add("Введенные пароли не совпадают!");
                return false;
            }
            return true;
        }
        #endregion
    }
}
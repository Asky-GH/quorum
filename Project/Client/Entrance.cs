using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formEntrance : Form
    {
        public NetworkStream Stream { get; set; }

        public formEntrance()
        {
            InitializeComponent();
        }

        private void formEntrance_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void formEntrance_Shown(object sender, EventArgs e)
        {
            string serverIpAddress = "127.0.0.1";
            int serverPort = 9000;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIpAddress), serverPort);
            TcpClient client = new TcpClient();

            while (client.Connected == false)
            {
                try
                {
                    client.Connect(endPoint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Попробуйте зайти позже!");
                    this.Close();
                }
            }

            Stream = client.GetStream();
        }

        #region Placeholder-ы для полей ввода
        // Заполнение textBox-ов placeholder-ми
        private void InitiateTextBoxes()
        {
            textBoxEmail.ForeColor = Color.Gray;
            textBoxEmail.Text = "Почта";

            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.Text = "Пароль";
            textBoxPassword.PasswordChar = '\0';

            textBoxEmailSignUp.ForeColor = Color.Gray;
            textBoxEmailSignUp.Text = "Почта";

            textBoxPasswordSignUp.ForeColor = Color.Gray;
            textBoxPasswordSignUp.Text = "Пароль";
            textBoxPasswordSignUp.PasswordChar = '\0';

            textBoxPassword2SignUp.ForeColor = Color.Gray;
            textBoxPassword2SignUp.Text = "Подтверждение пароля";
            textBoxPassword2SignUp.PasswordChar = '\0';
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitiateTextBoxes();
        }

        #region Авторизация
        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Почта")
            {
                textBoxEmail.Text = "";
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxEmail.Text = "Почта";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            textBoxEmail.ForeColor = Color.Black;
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Пароль")
            {
                textBoxPassword.Text = "";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = "Пароль";
                textBoxPassword.ForeColor = Color.Gray;
                textBoxPassword.PasswordChar = '\0';
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.ForeColor = Color.Black;
            textBoxPassword.PasswordChar = '*';
        }
        #endregion

        #region Регистрация
        private void textBoxEmailSignUp_Enter(object sender, EventArgs e)
        {
            if (textBoxEmailSignUp.Text == "Почта")
            {
                textBoxEmailSignUp.Text = "";
            }
        }

        private void textBoxEmailSignUp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmailSignUp.Text))
            {
                textBoxEmailSignUp.Text = "Почта";
                textBoxEmailSignUp.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmailSignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxEmailSignUp.ForeColor = Color.Black;
        }

        private void textBoxPasswordSignUp_Enter(object sender, EventArgs e)
        {
            if (textBoxPasswordSignUp.Text == "Пароль")
            {
                textBoxPasswordSignUp.Text = "";
            }
        }

        private void textBoxPasswordSignUp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPasswordSignUp.Text))
            {
                textBoxPasswordSignUp.Text = "Пароль";
                textBoxPasswordSignUp.ForeColor = Color.Gray;
                textBoxPasswordSignUp.PasswordChar = '\0';
            }
        }

        private void textBoxPasswordSignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxPasswordSignUp.ForeColor = Color.Black;
            textBoxPasswordSignUp.PasswordChar = '*';
        }

        private void textBoxPassword2SignUp_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword2SignUp.Text == "Подтверждение пароля")
            {
                textBoxPassword2SignUp.Text = "";
            }
        }

        private void textBoxPassword2SignUp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword2SignUp.Text))
            {
                textBoxPassword2SignUp.Text = "Подтверждение пароля";
                textBoxPassword2SignUp.ForeColor = Color.Gray;
                textBoxPassword2SignUp.PasswordChar = '\0';
            }
        }

        private void textBoxPassword2SignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword2SignUp.ForeColor = Color.Black;
            textBoxPassword2SignUp.PasswordChar = '*';
        }
        #endregion

        #endregion

        #region Helper функции: проверка валидности почтового адреса/паролей, связь с сервером
        private bool EmailCheck(List<string> errors)
        {
            try
            {
                MailAddress m = new MailAddress(textBoxEmailSignUp.Text);
                return true;
            }
            catch (FormatException)
            {
                errors.Add("Введенный email адрес имеет неверный формат.");
                return false;
            }
        }

        private bool PasswordCheck(List<string> errors)
        {
            string password = textBoxPasswordSignUp.Text;
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
                    errors.Add("Пароль может содержать только латинские буквы и цифры.");
                    return false;
                }
            }
            else
            {
                errors.Add("Длинна пароля должна быть не менее " + minLength.ToString() + " и не более " + maxLength.ToString() + " символов.");
                return false;
            }

            if (hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit)
            {
                return true;
            }
            errors.Add("Пароль должен состоять из цифр, а также заглавных и прописных букв.");
            return false;
        }

        private bool PasswordMatchCheck(List<string> errors)
        {
            string password = textBoxPasswordSignUp.Text;
            string password2 = textBoxPassword2SignUp.Text;

            if (password != password2)
            {
                errors.Add("Введенные пароли не совпадают.");
                return false;
            }
            return true;
        }

        // Связь с сервером
        private string TalkToServer(string data)
        {
            byte[] request = Encoding.Default.GetBytes(data);
            Stream.Write(request, 0, request.Length);

            int recievedData = 0;
            int responseSize = 1024 * 33;
            byte[] response = new byte[responseSize];
            recievedData = Stream.Read(response, 0, response.Length);

            return Encoding.Default.GetString(response, 0, recievedData);
        }
        #endregion

        #region Кнопки        
        // Кнопка регистрации
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textBoxEmailSignUp.Text == "Почта" || textBoxPasswordSignUp.Text == "Пароль" || textBoxPassword2SignUp.Text == "Подтверждение пароля")
            {
                MessageBox.Show("Введите свой email адрес и пароль!");
                return;
            }

            List<string> errors = new List<string>();
            string action = "SignUp";

            if (EmailCheck(errors) && PasswordCheck(errors) && PasswordMatchCheck(errors))
            {
                string response = "";

                try
                {
                    response = TalkToServer(textBoxEmailSignUp.Text + "[CONTENT]" + textBoxPasswordSignUp.Text + "[CONTENT]" + action);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Попробуйте зайти позже!");
                    this.Close();
                }

                if (response == "OK!")
                {
                    MessageBox.Show("Вы успешно зарегистрировались.");
                    InitiateTextBoxes();
                    return;
                }
                MessageBox.Show(response);
                return;
            }
            MessageBox.Show(errors.First());
        }

        // Кнопка входа
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Почта" || textBoxPassword.Text == "Пароль")
            {
                MessageBox.Show("Введите свой email адрес и пароль!");
                return;
            }

            string response = "";

            try
            {
                response = TalkToServer(textBoxEmail.Text + "[CONTENT]" + textBoxPassword.Text + "[CONTENT]" + "SignIn");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Попробуйте зайти позже!");
                this.Close();
            }

            if (response == "Добро пожаловать!")
            {
                MessageBox.Show(response);

                formMain main = new formMain();
                main.Stream = Stream;
                main.Show();
                this.Close();
                return;
            }

            MessageBox.Show(response);
        }
        #endregion
    }
}
namespace Client
{
    partial class formEntrance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEntrance));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSignIn = new System.Windows.Forms.TabPage();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.tabPageSignUp = new System.Windows.Forms.TabPage();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.textBoxPassword2SignUp = new System.Windows.Forms.TextBox();
            this.textBoxPasswordSignUp = new System.Windows.Forms.TextBox();
            this.textBoxEmailSignUp = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageSignIn.SuspendLayout();
            this.tabPageSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSignIn);
            this.tabControl.Controls.Add(this.tabPageSignUp);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(260, 237);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageSignIn
            // 
            this.tabPageSignIn.Controls.Add(this.textBoxPassword);
            this.tabPageSignIn.Controls.Add(this.textBoxEmail);
            this.tabPageSignIn.Controls.Add(this.buttonSignIn);
            this.tabPageSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageSignIn.Location = new System.Drawing.Point(4, 22);
            this.tabPageSignIn.Name = "tabPageSignIn";
            this.tabPageSignIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSignIn.Size = new System.Drawing.Size(252, 211);
            this.tabPageSignIn.TabIndex = 0;
            this.tabPageSignIn.Text = "Авторизация";
            this.tabPageSignIn.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPassword.Location = new System.Drawing.Point(27, 86);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Text = "Пароль";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxEmail.Location = new System.Drawing.Point(27, 60);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.Text = "Почта";
            this.textBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSignIn.Location = new System.Drawing.Point(90, 119);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(75, 23);
            this.buttonSignIn.TabIndex = 2;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // tabPageSignUp
            // 
            this.tabPageSignUp.Controls.Add(this.buttonSignUp);
            this.tabPageSignUp.Controls.Add(this.textBoxPassword2SignUp);
            this.tabPageSignUp.Controls.Add(this.textBoxPasswordSignUp);
            this.tabPageSignUp.Controls.Add(this.textBoxEmailSignUp);
            this.tabPageSignUp.Location = new System.Drawing.Point(4, 22);
            this.tabPageSignUp.Name = "tabPageSignUp";
            this.tabPageSignUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSignUp.Size = new System.Drawing.Size(252, 211);
            this.tabPageSignUp.TabIndex = 1;
            this.tabPageSignUp.Text = "Регистрация";
            this.tabPageSignUp.UseVisualStyleBackColor = true;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSignUp.Location = new System.Drawing.Point(54, 136);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(150, 23);
            this.buttonSignUp.TabIndex = 3;
            this.buttonSignUp.Text = "Зарегистрироваться";
            this.buttonSignUp.UseVisualStyleBackColor = false;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // textBoxPassword2SignUp
            // 
            this.textBoxPassword2SignUp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPassword2SignUp.Location = new System.Drawing.Point(27, 103);
            this.textBoxPassword2SignUp.Name = "textBoxPassword2SignUp";
            this.textBoxPassword2SignUp.Size = new System.Drawing.Size(200, 20);
            this.textBoxPassword2SignUp.TabIndex = 2;
            this.textBoxPassword2SignUp.Text = "Подтверждение пароля";
            this.textBoxPassword2SignUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword2SignUp.TextChanged += new System.EventHandler(this.textBoxPassword2SignUp_TextChanged);
            this.textBoxPassword2SignUp.Enter += new System.EventHandler(this.textBoxPassword2SignUp_Enter);
            this.textBoxPassword2SignUp.Leave += new System.EventHandler(this.textBoxPassword2SignUp_Leave);
            // 
            // textBoxPasswordSignUp
            // 
            this.textBoxPasswordSignUp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPasswordSignUp.Location = new System.Drawing.Point(27, 77);
            this.textBoxPasswordSignUp.Name = "textBoxPasswordSignUp";
            this.textBoxPasswordSignUp.Size = new System.Drawing.Size(200, 20);
            this.textBoxPasswordSignUp.TabIndex = 1;
            this.textBoxPasswordSignUp.Text = "Пароль";
            this.textBoxPasswordSignUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPasswordSignUp.TextChanged += new System.EventHandler(this.textBoxPasswordSignUp_TextChanged);
            this.textBoxPasswordSignUp.Enter += new System.EventHandler(this.textBoxPasswordSignUp_Enter);
            this.textBoxPasswordSignUp.Leave += new System.EventHandler(this.textBoxPasswordSignUp_Leave);
            // 
            // textBoxEmailSignUp
            // 
            this.textBoxEmailSignUp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxEmailSignUp.Location = new System.Drawing.Point(27, 51);
            this.textBoxEmailSignUp.Name = "textBoxEmailSignUp";
            this.textBoxEmailSignUp.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmailSignUp.TabIndex = 0;
            this.textBoxEmailSignUp.Text = "Почта";
            this.textBoxEmailSignUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEmailSignUp.TextChanged += new System.EventHandler(this.textBoxEmailSignUp_TextChanged);
            this.textBoxEmailSignUp.Enter += new System.EventHandler(this.textBoxEmailSignUp_Enter);
            this.textBoxEmailSignUp.Leave += new System.EventHandler(this.textBoxEmailSignUp_Leave);
            // 
            // formEntrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formEntrance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кворум";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formEntrance_FormClosed);
            this.Shown += new System.EventHandler(this.formEntrance_Shown);
            this.tabControl.ResumeLayout(false);
            this.tabPageSignIn.ResumeLayout(false);
            this.tabPageSignIn.PerformLayout();
            this.tabPageSignUp.ResumeLayout(false);
            this.tabPageSignUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSignIn;
        private System.Windows.Forms.TabPage tabPageSignUp;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.TextBox textBoxPassword2SignUp;
        private System.Windows.Forms.TextBox textBoxPasswordSignUp;
        private System.Windows.Forms.TextBox textBoxEmailSignUp;
    }
}
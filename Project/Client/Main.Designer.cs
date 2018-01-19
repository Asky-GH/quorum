namespace Client
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAnswer = new System.Windows.Forms.TabPage();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxQuestions = new System.Windows.Forms.TextBox();
            this.tabPageQuestion = new System.Windows.Forms.TabPage();
            this.linkLabelCommentsNo = new System.Windows.Forms.LinkLabel();
            this.linkLabelCommentsYes = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAsk = new System.Windows.Forms.Button();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
            this.groupBoxNewEmail = new System.Windows.Forms.GroupBox();
            this.buttonChangeEmail = new System.Windows.Forms.Button();
            this.textBoxEmailNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxNewPassword = new System.Windows.Forms.GroupBox();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.textBoxPassword2New = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPasswordNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxCurrent = new System.Windows.Forms.GroupBox();
            this.textBoxEmailCurrent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageAnswer.SuspendLayout();
            this.tabPageQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageProfile.SuspendLayout();
            this.groupBoxNewEmail.SuspendLayout();
            this.groupBoxNewPassword.SuspendLayout();
            this.groupBoxCurrent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAnswer);
            this.tabControl.Controls.Add(this.tabPageQuestion);
            this.tabControl.Controls.Add(this.tabPageProfile);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(410, 387);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageAnswer
            // 
            this.tabPageAnswer.Controls.Add(this.buttonNo);
            this.tabPageAnswer.Controls.Add(this.buttonYes);
            this.tabPageAnswer.Controls.Add(this.textBoxComment);
            this.tabPageAnswer.Controls.Add(this.textBoxQuestions);
            this.tabPageAnswer.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnswer.Name = "tabPageAnswer";
            this.tabPageAnswer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnswer.Size = new System.Drawing.Size(402, 361);
            this.tabPageAnswer.TabIndex = 0;
            this.tabPageAnswer.Text = "Голосование";
            this.tabPageAnswer.UseVisualStyleBackColor = true;
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNo.Location = new System.Drawing.Point(200, 162);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 3;
            this.buttonNo.Text = "Нет";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonYes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonYes.Location = new System.Drawing.Point(119, 162);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 23);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "Да";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // textBoxComment
            // 
            this.textBoxComment.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxComment.Location = new System.Drawing.Point(6, 205);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(390, 150);
            this.textBoxComment.TabIndex = 1;
            this.textBoxComment.Text = "Комментарий";
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            this.textBoxComment.Enter += new System.EventHandler(this.textBoxComment_Enter);
            this.textBoxComment.Leave += new System.EventHandler(this.textBoxComment_Leave);
            // 
            // textBoxQuestions
            // 
            this.textBoxQuestions.Location = new System.Drawing.Point(6, 6);
            this.textBoxQuestions.Multiline = true;
            this.textBoxQuestions.Name = "textBoxQuestions";
            this.textBoxQuestions.ReadOnly = true;
            this.textBoxQuestions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxQuestions.Size = new System.Drawing.Size(390, 150);
            this.textBoxQuestions.TabIndex = 0;
            this.textBoxQuestions.Text = "В данный момент вопросов нет...";
            // 
            // tabPageQuestion
            // 
            this.tabPageQuestion.Controls.Add(this.linkLabelCommentsNo);
            this.tabPageQuestion.Controls.Add(this.linkLabelCommentsYes);
            this.tabPageQuestion.Controls.Add(this.pictureBox2);
            this.tabPageQuestion.Controls.Add(this.pictureBox1);
            this.tabPageQuestion.Controls.Add(this.buttonRemove);
            this.tabPageQuestion.Controls.Add(this.buttonAsk);
            this.tabPageQuestion.Controls.Add(this.textBoxQuestion);
            this.tabPageQuestion.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuestion.Name = "tabPageQuestion";
            this.tabPageQuestion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuestion.Size = new System.Drawing.Size(402, 361);
            this.tabPageQuestion.TabIndex = 1;
            this.tabPageQuestion.Text = "Вопрос";
            this.tabPageQuestion.UseVisualStyleBackColor = true;
            // 
            // linkLabelCommentsNo
            // 
            this.linkLabelCommentsNo.AutoSize = true;
            this.linkLabelCommentsNo.Location = new System.Drawing.Point(318, 297);
            this.linkLabelCommentsNo.Name = "linkLabelCommentsNo";
            this.linkLabelCommentsNo.Size = new System.Drawing.Size(13, 13);
            this.linkLabelCommentsNo.TabIndex = 4;
            this.linkLabelCommentsNo.TabStop = true;
            this.linkLabelCommentsNo.Text = "0";
            this.linkLabelCommentsNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelCommentsNo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCommentsNo_LinkClicked);
            // 
            // linkLabelCommentsYes
            // 
            this.linkLabelCommentsYes.AutoSize = true;
            this.linkLabelCommentsYes.Location = new System.Drawing.Point(86, 297);
            this.linkLabelCommentsYes.Name = "linkLabelCommentsYes";
            this.linkLabelCommentsYes.Size = new System.Drawing.Size(13, 13);
            this.linkLabelCommentsYes.TabIndex = 3;
            this.linkLabelCommentsYes.TabStop = true;
            this.linkLabelCommentsYes.Text = "0";
            this.linkLabelCommentsYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelCommentsYes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCommentsYes_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(299, 227);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemove.Location = new System.Drawing.Point(208, 162);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Снять";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAsk
            // 
            this.buttonAsk.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonAsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAsk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAsk.Location = new System.Drawing.Point(127, 162);
            this.buttonAsk.Name = "buttonAsk";
            this.buttonAsk.Size = new System.Drawing.Size(75, 23);
            this.buttonAsk.TabIndex = 1;
            this.buttonAsk.Text = "Задать";
            this.buttonAsk.UseVisualStyleBackColor = false;
            this.buttonAsk.Click += new System.EventHandler(this.buttonAsk_Click);
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(6, 6);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxQuestion.Size = new System.Drawing.Size(390, 150);
            this.textBoxQuestion.TabIndex = 0;
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.groupBoxNewEmail);
            this.tabPageProfile.Controls.Add(this.groupBoxNewPassword);
            this.tabPageProfile.Controls.Add(this.groupBoxCurrent);
            this.tabPageProfile.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfile.Size = new System.Drawing.Size(402, 361);
            this.tabPageProfile.TabIndex = 2;
            this.tabPageProfile.Text = "Профиль";
            this.tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // groupBoxNewEmail
            // 
            this.groupBoxNewEmail.Controls.Add(this.buttonChangeEmail);
            this.groupBoxNewEmail.Controls.Add(this.textBoxEmailNew);
            this.groupBoxNewEmail.Controls.Add(this.label2);
            this.groupBoxNewEmail.Location = new System.Drawing.Point(6, 62);
            this.groupBoxNewEmail.Name = "groupBoxNewEmail";
            this.groupBoxNewEmail.Size = new System.Drawing.Size(390, 115);
            this.groupBoxNewEmail.TabIndex = 3;
            this.groupBoxNewEmail.TabStop = false;
            this.groupBoxNewEmail.Text = "Новый email";
            // 
            // buttonChangeEmail
            // 
            this.buttonChangeEmail.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonChangeEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChangeEmail.Location = new System.Drawing.Point(309, 86);
            this.buttonChangeEmail.Name = "buttonChangeEmail";
            this.buttonChangeEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeEmail.TabIndex = 2;
            this.buttonChangeEmail.Text = "Изменить";
            this.buttonChangeEmail.UseVisualStyleBackColor = false;
            this.buttonChangeEmail.Click += new System.EventHandler(this.buttonChangeEmail_Click);
            // 
            // textBoxEmailNew
            // 
            this.textBoxEmailNew.Location = new System.Drawing.Point(110, 39);
            this.textBoxEmailNew.Name = "textBoxEmailNew";
            this.textBoxEmailNew.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmailNew.TabIndex = 1;
            this.textBoxEmailNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEmailNew.TextChanged += new System.EventHandler(this.textBoxEmailNew_TextChanged);
            this.textBoxEmailNew.Enter += new System.EventHandler(this.textBoxEmailNew_Enter);
            this.textBoxEmailNew.Leave += new System.EventHandler(this.textBoxEmailNew_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // groupBoxNewPassword
            // 
            this.groupBoxNewPassword.Controls.Add(this.buttonChangePassword);
            this.groupBoxNewPassword.Controls.Add(this.textBoxPassword2New);
            this.groupBoxNewPassword.Controls.Add(this.label5);
            this.groupBoxNewPassword.Controls.Add(this.textBoxPasswordNew);
            this.groupBoxNewPassword.Controls.Add(this.label4);
            this.groupBoxNewPassword.Location = new System.Drawing.Point(6, 183);
            this.groupBoxNewPassword.Name = "groupBoxNewPassword";
            this.groupBoxNewPassword.Size = new System.Drawing.Size(390, 165);
            this.groupBoxNewPassword.TabIndex = 1;
            this.groupBoxNewPassword.TabStop = false;
            this.groupBoxNewPassword.Text = "Новый пароль";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChangePassword.Location = new System.Drawing.Point(309, 136);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonChangePassword.TabIndex = 5;
            this.buttonChangePassword.Text = "Изменить";
            this.buttonChangePassword.UseVisualStyleBackColor = false;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // textBoxPassword2New
            // 
            this.textBoxPassword2New.Location = new System.Drawing.Point(110, 76);
            this.textBoxPassword2New.Name = "textBoxPassword2New";
            this.textBoxPassword2New.Size = new System.Drawing.Size(200, 20);
            this.textBoxPassword2New.TabIndex = 4;
            this.textBoxPassword2New.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword2New.TextChanged += new System.EventHandler(this.textBoxPassword2New_TextChanged);
            this.textBoxPassword2New.Enter += new System.EventHandler(this.textBoxPassword2New_Enter);
            this.textBoxPassword2New.Leave += new System.EventHandler(this.textBoxPassword2New_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Пароль";
            // 
            // textBoxPasswordNew
            // 
            this.textBoxPasswordNew.Location = new System.Drawing.Point(110, 50);
            this.textBoxPasswordNew.Name = "textBoxPasswordNew";
            this.textBoxPasswordNew.Size = new System.Drawing.Size(200, 20);
            this.textBoxPasswordNew.TabIndex = 3;
            this.textBoxPasswordNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPasswordNew.TextChanged += new System.EventHandler(this.textBoxPasswordNew_TextChanged);
            this.textBoxPasswordNew.Enter += new System.EventHandler(this.textBoxPasswordNew_Enter);
            this.textBoxPasswordNew.Leave += new System.EventHandler(this.textBoxPasswordNew_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Пароль";
            // 
            // groupBoxCurrent
            // 
            this.groupBoxCurrent.Controls.Add(this.textBoxEmailCurrent);
            this.groupBoxCurrent.Controls.Add(this.label1);
            this.groupBoxCurrent.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCurrent.Name = "groupBoxCurrent";
            this.groupBoxCurrent.Size = new System.Drawing.Size(390, 50);
            this.groupBoxCurrent.TabIndex = 0;
            this.groupBoxCurrent.TabStop = false;
            this.groupBoxCurrent.Text = "Текущие данные";
            // 
            // textBoxEmailCurrent
            // 
            this.textBoxEmailCurrent.Location = new System.Drawing.Point(110, 19);
            this.textBoxEmailCurrent.Name = "textBoxEmailCurrent";
            this.textBoxEmailCurrent.ReadOnly = true;
            this.textBoxEmailCurrent.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmailCurrent.TabIndex = 0;
            this.textBoxEmailCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кворум";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPageAnswer.ResumeLayout(false);
            this.tabPageAnswer.PerformLayout();
            this.tabPageQuestion.ResumeLayout(false);
            this.tabPageQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageProfile.ResumeLayout(false);
            this.groupBoxNewEmail.ResumeLayout(false);
            this.groupBoxNewEmail.PerformLayout();
            this.groupBoxNewPassword.ResumeLayout(false);
            this.groupBoxNewPassword.PerformLayout();
            this.groupBoxCurrent.ResumeLayout(false);
            this.groupBoxCurrent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAnswer;
        private System.Windows.Forms.TabPage tabPageQuestion;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.TextBox textBoxQuestions;
        private System.Windows.Forms.Button buttonAsk;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.LinkLabel linkLabelCommentsNo;
        private System.Windows.Forms.LinkLabel linkLabelCommentsYes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPageProfile;
        private System.Windows.Forms.Button buttonChangeEmail;
        private System.Windows.Forms.GroupBox groupBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxPassword2New;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPasswordNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmailNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxCurrent;
        private System.Windows.Forms.TextBox textBoxEmailCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxNewEmail;
        private System.Windows.Forms.Button buttonChangePassword;
    }
}
namespace ViewWindowsForms
{
    partial class FormLogin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tabControlLoginReg = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.textBoxRepeatPasswordReg = new System.Windows.Forms.TextBox();
            this.textBoxPasswordReg = new System.Windows.Forms.TextBox();
            this.textBoxPhoneReg = new System.Windows.Forms.TextBox();
            this.textBoxLastNameReg = new System.Windows.Forms.TextBox();
            this.textBoxFirstNameReg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlLoginReg.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.Location = new System.Drawing.Point(144, 218);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(200, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPhone.Location = new System.Drawing.Point(144, 150);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(250, 22);
            this.textBoxPhone.TabIndex = 1;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBoxPhone_TextChanged);
            this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(144, 178);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(250, 22);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // labelPhone
            // 
            this.labelPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(71, 153);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(70, 16);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Телефон:";
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(79, 181);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 16);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Пароль:";
            // 
            // tabControlLoginReg
            // 
            this.tabControlLoginReg.Controls.Add(this.tabPage1);
            this.tabControlLoginReg.Controls.Add(this.tabPage2);
            this.tabControlLoginReg.Location = new System.Drawing.Point(13, 13);
            this.tabControlLoginReg.Name = "tabControlLoginReg";
            this.tabControlLoginReg.SelectedIndex = 0;
            this.tabControlLoginReg.Size = new System.Drawing.Size(517, 428);
            this.tabControlLoginReg.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelPassword);
            this.tabPage1.Controls.Add(this.labelPhone);
            this.tabPage1.Controls.Add(this.textBoxPhone);
            this.tabPage1.Controls.Add(this.textBoxPassword);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вход";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.buttonRegistration);
            this.tabPage2.Controls.Add(this.textBoxRepeatPasswordReg);
            this.tabPage2.Controls.Add(this.textBoxPasswordReg);
            this.tabPage2.Controls.Add(this.textBoxPhoneReg);
            this.tabPage2.Controls.Add(this.textBoxLastNameReg);
            this.tabPage2.Controls.Add(this.textBoxFirstNameReg);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Регистрация";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Подтверждение пароля:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Пароль:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Телефон:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Имя:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Фамилия:";
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Location = new System.Drawing.Point(111, 268);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(200, 23);
            this.buttonRegistration.TabIndex = 14;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // textBoxRepeatPasswordReg
            // 
            this.textBoxRepeatPasswordReg.Location = new System.Drawing.Point(191, 222);
            this.textBoxRepeatPasswordReg.MaxLength = 60;
            this.textBoxRepeatPasswordReg.Name = "textBoxRepeatPasswordReg";
            this.textBoxRepeatPasswordReg.Size = new System.Drawing.Size(250, 22);
            this.textBoxRepeatPasswordReg.TabIndex = 12;
            this.textBoxRepeatPasswordReg.TextChanged += new System.EventHandler(this.textBoxRepeatPassordReg_TextChanged);
            this.textBoxRepeatPasswordReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRepeatPassordReg_KeyPress);
            // 
            // textBoxPasswordReg
            // 
            this.textBoxPasswordReg.Location = new System.Drawing.Point(191, 194);
            this.textBoxPasswordReg.MaxLength = 60;
            this.textBoxPasswordReg.Name = "textBoxPasswordReg";
            this.textBoxPasswordReg.Size = new System.Drawing.Size(250, 22);
            this.textBoxPasswordReg.TabIndex = 11;
            this.textBoxPasswordReg.TextChanged += new System.EventHandler(this.textBoxPasswordReg_TextChanged);
            this.textBoxPasswordReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPasswordReg_KeyPress);
            // 
            // textBoxPhoneReg
            // 
            this.textBoxPhoneReg.Location = new System.Drawing.Point(191, 166);
            this.textBoxPhoneReg.MaxLength = 11;
            this.textBoxPhoneReg.Name = "textBoxPhoneReg";
            this.textBoxPhoneReg.Size = new System.Drawing.Size(250, 22);
            this.textBoxPhoneReg.TabIndex = 10;
            this.textBoxPhoneReg.TextChanged += new System.EventHandler(this.textBoxPhoneReg_TextChanged);
            this.textBoxPhoneReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhoneReg_KeyPress);
            // 
            // textBoxLastNameReg
            // 
            this.textBoxLastNameReg.Location = new System.Drawing.Point(191, 138);
            this.textBoxLastNameReg.MaxLength = 100;
            this.textBoxLastNameReg.Name = "textBoxLastNameReg";
            this.textBoxLastNameReg.Size = new System.Drawing.Size(250, 22);
            this.textBoxLastNameReg.TabIndex = 9;
            this.textBoxLastNameReg.TextChanged += new System.EventHandler(this.textBoxLastNameReg_TextChanged);
            this.textBoxLastNameReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLastNameReg_KeyPress);
            // 
            // textBoxFirstNameReg
            // 
            this.textBoxFirstNameReg.Location = new System.Drawing.Point(191, 110);
            this.textBoxFirstNameReg.MaxLength = 100;
            this.textBoxFirstNameReg.Name = "textBoxFirstNameReg";
            this.textBoxFirstNameReg.Size = new System.Drawing.Size(250, 22);
            this.textBoxFirstNameReg.TabIndex = 8;
            this.textBoxFirstNameReg.TextChanged += new System.EventHandler(this.textBoxFirstNameReg_TextChanged);
            this.textBoxFirstNameReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFirstNameReg_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 453);
            this.Controls.Add(this.tabControlLoginReg);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.tabControlLoginReg.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TabControl tabControlLoginReg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPasswordReg;
        private System.Windows.Forms.TextBox textBoxPhoneReg;
        private System.Windows.Forms.TextBox textBoxLastNameReg;
        private System.Windows.Forms.TextBox textBoxFirstNameReg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.TextBox textBoxRepeatPasswordReg;
        public System.Windows.Forms.TextBox textBoxPhone;
        public System.Windows.Forms.TextBox textBoxPassword;
    }
}


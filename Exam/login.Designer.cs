namespace Exam
{
    partial class login
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
            this.Login_Textbox = new System.Windows.Forms.TextBox();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.Auth_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Registr_label = new System.Windows.Forms.Label();
            this.Guest_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login_Textbox
            // 
            this.Login_Textbox.BackColor = System.Drawing.Color.Wheat;
            this.Login_Textbox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login_Textbox.Location = new System.Drawing.Point(228, 105);
            this.Login_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login_Textbox.Name = "Login_Textbox";
            this.Login_Textbox.Size = new System.Drawing.Size(365, 30);
            this.Login_Textbox.TabIndex = 0;
            // 
            // Password_Textbox
            // 
            this.Password_Textbox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password_Textbox.Location = new System.Drawing.Point(228, 154);
            this.Password_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.Size = new System.Drawing.Size(365, 30);
            this.Password_Textbox.TabIndex = 1;
            // 
            // Auth_button
            // 
            this.Auth_button.BackColor = System.Drawing.Color.BurlyWood;
            this.Auth_button.Location = new System.Drawing.Point(404, 202);
            this.Auth_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Auth_button.Name = "Auth_button";
            this.Auth_button.Size = new System.Drawing.Size(189, 36);
            this.Auth_button.TabIndex = 2;
            this.Auth_button.Text = "Авторизироваться";
            this.Auth_button.UseVisualStyleBackColor = false;
            this.Auth_button.Click += new System.EventHandler(this.Auth_button_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(175, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 78);
            this.label1.TabIndex = 3;
            this.label1.Text = "Добро пожаловать! Введите логин и пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // Registr_label
            // 
            this.Registr_label.AutoSize = true;
            this.Registr_label.Location = new System.Drawing.Point(400, 253);
            this.Registr_label.Name = "Registr_label";
            this.Registr_label.Size = new System.Drawing.Size(202, 16);
            this.Registr_label.TabIndex = 6;
            this.Registr_label.Text = "Ещё не зарегистрировались?";
            this.Registr_label.Click += new System.EventHandler(this.Registr_label_Click);
            // 
            // Guest_button
            // 
            this.Guest_button.Location = new System.Drawing.Point(119, 220);
            this.Guest_button.Name = "Guest_button";
            this.Guest_button.Size = new System.Drawing.Size(128, 49);
            this.Guest_button.TabIndex = 7;
            this.Guest_button.Text = "Войти как Гость";
            this.Guest_button.UseVisualStyleBackColor = true;
            this.Guest_button.Click += new System.EventHandler(this.Guest_button_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 354);
            this.Controls.Add(this.Guest_button);
            this.Controls.Add(this.Registr_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Auth_button);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.Login_Textbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "login";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Login_Textbox;
        private System.Windows.Forms.TextBox Password_Textbox;
        private System.Windows.Forms.Button Auth_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Registr_label;
        private System.Windows.Forms.Button Guest_button;
    }
}


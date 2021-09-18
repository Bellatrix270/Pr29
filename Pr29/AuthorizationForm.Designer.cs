
namespace Pr29
{
    partial class AuthorizationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelReg = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelConnectionDB = new System.Windows.Forms.Label();
            this.labelConnectionHost = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxShowPass = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.EnterButton = new yt_DesignUI.yt_Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 79);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label4.Location = new System.Drawing.Point(269, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "Авторизация";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.LavenderBlush;
            this.textBoxPassword.Location = new System.Drawing.Point(283, 344);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(232, 31);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReg.ForeColor = System.Drawing.Color.Silver;
            this.labelReg.Location = new System.Drawing.Point(330, 491);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(130, 15);
            this.labelReg.TabIndex = 3;
            this.labelReg.Text = "Зарегистрироваться";
            this.labelReg.MouseEnter += new System.EventHandler(this.labelReg_MouseEnter);
            this.labelReg.MouseLeave += new System.EventHandler(this.labelReg_MouseLeave);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.textBoxEmail.Location = new System.Drawing.Point(283, 246);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(232, 31);
            this.textBoxEmail.TabIndex = 4;
            this.textBoxEmail.Text = "Test@mail.ru...";
            this.textBoxEmail.Click += new System.EventHandler(this.textBoxEmail_Click);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label2.Location = new System.Drawing.Point(278, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label3.Location = new System.Drawing.Point(282, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Почта или логин";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.labelConnectionDB);
            this.panel2.Controls.Add(this.labelConnectionHost);
            this.panel2.Location = new System.Drawing.Point(197, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 78);
            this.panel2.TabIndex = 7;
            // 
            // labelConnectionDB
            // 
            this.labelConnectionDB.AutoSize = true;
            this.labelConnectionDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConnectionDB.ForeColor = System.Drawing.Color.LavenderBlush;
            this.labelConnectionDB.Location = new System.Drawing.Point(-1, 40);
            this.labelConnectionDB.Name = "labelConnectionDB";
            this.labelConnectionDB.Size = new System.Drawing.Size(264, 25);
            this.labelConnectionDB.TabIndex = 1;
            this.labelConnectionDB.Text = "Соединие с БД : открыто";
            // 
            // labelConnectionHost
            // 
            this.labelConnectionHost.AutoSize = true;
            this.labelConnectionHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConnectionHost.ForeColor = System.Drawing.Color.LavenderBlush;
            this.labelConnectionHost.Location = new System.Drawing.Point(-1, 15);
            this.labelConnectionHost.Name = "labelConnectionHost";
            this.labelConnectionHost.Size = new System.Drawing.Size(394, 25);
            this.labelConnectionHost.TabIndex = 0;
            this.labelConnectionHost.Text = "Соединение с хостингом установлено";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(222, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 21);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Location = new System.Drawing.Point(544, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 21);
            this.panel4.TabIndex = 9;
            // 
            // checkBoxShowPass
            // 
            this.checkBoxShowPass.AutoSize = true;
            this.checkBoxShowPass.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.checkBoxShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShowPass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkBoxShowPass.FlatAppearance.BorderSize = 0;
            this.checkBoxShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShowPass.ForeColor = System.Drawing.Color.LavenderBlush;
            this.checkBoxShowPass.Location = new System.Drawing.Point(404, 381);
            this.checkBoxShowPass.Name = "checkBoxShowPass";
            this.checkBoxShowPass.Size = new System.Drawing.Size(111, 17);
            this.checkBoxShowPass.TabIndex = 10;
            this.checkBoxShowPass.Text = "Показать пароль";
            this.checkBoxShowPass.UseVisualStyleBackColor = false;
            this.checkBoxShowPass.Click += new System.EventHandler(this.checkBoxShowPass_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel5.Controls.Add(this.EnterButton);
            this.panel5.Location = new System.Drawing.Point(197, 198);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(390, 339);
            this.panel5.TabIndex = 11;
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EnterButton.BackColorAdditional = System.Drawing.SystemColors.WindowFrame;
            this.EnterButton.BackColorGradientEnabled = true;
            this.EnterButton.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.EnterButton.BorderColor = System.Drawing.Color.LavenderBlush;
            this.EnterButton.BorderColorEnabled = true;
            this.EnterButton.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.EnterButton.BorderColorOnHoverEnabled = false;
            this.EnterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterButton.ForeColor = System.Drawing.Color.LavenderBlush;
            this.EnterButton.Location = new System.Drawing.Point(117, 228);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EnterButton.RoundingEnable = true;
            this.EnterButton.Size = new System.Drawing.Size(167, 47);
            this.EnterButton.TabIndex = 0;
            this.EnterButton.Text = "Войти";
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            this.EnterButton.MouseEnter += new System.EventHandler(this.EnterButton_MouseEnter);
            this.EnterButton.MouseLeave += new System.EventHandler(this.EnterButton_MouseLeave);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.checkBoxShowPass);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelReg);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AuthorizationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthorizationForm";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private yt_DesignUI.yt_Button EnterButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelConnectionDB;
        private System.Windows.Forms.Label labelConnectionHost;
        private System.Windows.Forms.CheckBox checkBoxShowPass;
        private System.Windows.Forms.Panel panel5;
    }
}
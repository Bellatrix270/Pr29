namespace Pr29
{
    partial class CrossAndZero
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
            this.label_current_turn = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.button_restart = new System.Windows.Forms.Button();
            this.Field_panel = new System.Windows.Forms.Panel();
            this.Field_button7 = new System.Windows.Forms.Button();
            this.Field_button4 = new System.Windows.Forms.Button();
            this.Field_button1 = new System.Windows.Forms.Button();
            this.Field_button8 = new System.Windows.Forms.Button();
            this.Field_button9 = new System.Windows.Forms.Button();
            this.Field_button3 = new System.Windows.Forms.Button();
            this.Field_button6 = new System.Windows.Forms.Button();
            this.Field_button2 = new System.Windows.Forms.Button();
            this.Field_button5 = new System.Windows.Forms.Button();
            this.Field_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_current_turn
            // 
            this.label_current_turn.AutoSize = true;
            this.label_current_turn.BackColor = System.Drawing.Color.Transparent;
            this.label_current_turn.Font = new System.Drawing.Font("Exo 2", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_current_turn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_current_turn.Location = new System.Drawing.Point(649, 9);
            this.label_current_turn.Name = "label_current_turn";
            this.label_current_turn.Size = new System.Drawing.Size(327, 142);
            this.label_current_turn.TabIndex = 1;
            this.label_current_turn.Text = "Текущий ход:\r\nИгрок 1\r\n";
            this.label_current_turn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.BackColor = System.Drawing.Color.Transparent;
            this.label_score.Font = new System.Drawing.Font("Exo 2", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_score.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_score.Location = new System.Drawing.Point(708, 215);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(211, 71);
            this.label_score.TabIndex = 2;
            this.label_score.Text = "Счёт 0:0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_restart
            // 
            this.button_restart.BackColor = System.Drawing.Color.Transparent;
            this.button_restart.BackgroundImage = global::Pr29.ResourceImages.Button_start;
            this.button_restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_restart.FlatAppearance.BorderSize = 0;
            this.button_restart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_restart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_restart.Font = new System.Drawing.Font("Exo 2", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_restart.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_restart.Location = new System.Drawing.Point(694, 572);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(236, 76);
            this.button_restart.TabIndex = 3;
            this.button_restart.Text = "Начать заново";
            this.button_restart.UseVisualStyleBackColor = false;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // Field_panel
            // 
            this.Field_panel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Field_panel.BackgroundImage = global::Pr29.ResourceImages.CrossAndZero_fieldV2;
            this.Field_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_panel.Controls.Add(this.Field_button7);
            this.Field_panel.Controls.Add(this.Field_button4);
            this.Field_panel.Controls.Add(this.Field_button1);
            this.Field_panel.Controls.Add(this.Field_button8);
            this.Field_panel.Controls.Add(this.Field_button9);
            this.Field_panel.Controls.Add(this.Field_button3);
            this.Field_panel.Controls.Add(this.Field_button6);
            this.Field_panel.Controls.Add(this.Field_button2);
            this.Field_panel.Controls.Add(this.Field_button5);
            this.Field_panel.Location = new System.Drawing.Point(-3, 0);
            this.Field_panel.Name = "Field_panel";
            this.Field_panel.Size = new System.Drawing.Size(640, 686);
            this.Field_panel.TabIndex = 0;
            // 
            // Field_button7
            // 
            this.Field_button7.BackColor = System.Drawing.Color.Transparent;
            this.Field_button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button7.FlatAppearance.BorderSize = 0;
            this.Field_button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button7.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button7.Location = new System.Drawing.Point(69, 479);
            this.Field_button7.Name = "Field_button7";
            this.Field_button7.Size = new System.Drawing.Size(113, 113);
            this.Field_button7.TabIndex = 16;
            this.Field_button7.UseVisualStyleBackColor = false;
            this.Field_button7.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button4
            // 
            this.Field_button4.BackColor = System.Drawing.Color.Transparent;
            this.Field_button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button4.FlatAppearance.BorderSize = 0;
            this.Field_button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button4.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button4.Location = new System.Drawing.Point(69, 349);
            this.Field_button4.Name = "Field_button4";
            this.Field_button4.Size = new System.Drawing.Size(113, 113);
            this.Field_button4.TabIndex = 15;
            this.Field_button4.UseVisualStyleBackColor = false;
            this.Field_button4.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button1
            // 
            this.Field_button1.BackColor = System.Drawing.Color.Transparent;
            this.Field_button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button1.FlatAppearance.BorderSize = 0;
            this.Field_button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button1.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button1.Location = new System.Drawing.Point(69, 221);
            this.Field_button1.Name = "Field_button1";
            this.Field_button1.Size = new System.Drawing.Size(113, 113);
            this.Field_button1.TabIndex = 14;
            this.Field_button1.UseVisualStyleBackColor = false;
            this.Field_button1.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button8
            // 
            this.Field_button8.BackColor = System.Drawing.Color.Transparent;
            this.Field_button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button8.FlatAppearance.BorderSize = 0;
            this.Field_button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button8.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button8.Location = new System.Drawing.Point(199, 479);
            this.Field_button8.Name = "Field_button8";
            this.Field_button8.Size = new System.Drawing.Size(113, 113);
            this.Field_button8.TabIndex = 13;
            this.Field_button8.UseVisualStyleBackColor = false;
            this.Field_button8.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button9
            // 
            this.Field_button9.BackColor = System.Drawing.Color.Transparent;
            this.Field_button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button9.FlatAppearance.BorderSize = 0;
            this.Field_button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button9.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button9.Location = new System.Drawing.Point(326, 479);
            this.Field_button9.Name = "Field_button9";
            this.Field_button9.Size = new System.Drawing.Size(113, 113);
            this.Field_button9.TabIndex = 12;
            this.Field_button9.UseVisualStyleBackColor = false;
            this.Field_button9.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button3
            // 
            this.Field_button3.BackColor = System.Drawing.Color.Transparent;
            this.Field_button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button3.FlatAppearance.BorderSize = 0;
            this.Field_button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button3.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button3.Location = new System.Drawing.Point(326, 221);
            this.Field_button3.Name = "Field_button3";
            this.Field_button3.Size = new System.Drawing.Size(113, 113);
            this.Field_button3.TabIndex = 11;
            this.Field_button3.UseVisualStyleBackColor = false;
            this.Field_button3.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button6
            // 
            this.Field_button6.BackColor = System.Drawing.Color.Transparent;
            this.Field_button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button6.FlatAppearance.BorderSize = 0;
            this.Field_button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button6.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button6.Location = new System.Drawing.Point(326, 349);
            this.Field_button6.Name = "Field_button6";
            this.Field_button6.Size = new System.Drawing.Size(113, 113);
            this.Field_button6.TabIndex = 10;
            this.Field_button6.UseVisualStyleBackColor = false;
            this.Field_button6.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button2
            // 
            this.Field_button2.BackColor = System.Drawing.Color.Transparent;
            this.Field_button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button2.FlatAppearance.BorderSize = 0;
            this.Field_button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button2.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button2.Location = new System.Drawing.Point(199, 221);
            this.Field_button2.Name = "Field_button2";
            this.Field_button2.Size = new System.Drawing.Size(113, 113);
            this.Field_button2.TabIndex = 9;
            this.Field_button2.UseVisualStyleBackColor = false;
            this.Field_button2.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // Field_button5
            // 
            this.Field_button5.BackColor = System.Drawing.Color.Transparent;
            this.Field_button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Field_button5.FlatAppearance.BorderSize = 0;
            this.Field_button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Field_button5.ForeColor = System.Drawing.Color.Transparent;
            this.Field_button5.Location = new System.Drawing.Point(199, 349);
            this.Field_button5.Name = "Field_button5";
            this.Field_button5.Size = new System.Drawing.Size(113, 113);
            this.Field_button5.TabIndex = 8;
            this.Field_button5.UseVisualStyleBackColor = false;
            this.Field_button5.Click += new System.EventHandler(this.Field_buttons_Click);
            // 
            // CrossAndZero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(984, 681);
            this.Controls.Add(this.button_restart);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_current_turn);
            this.Controls.Add(this.Field_panel);
            this.Name = "CrossAndZero";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики нолики";
            this.Field_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Field_panel;
        private System.Windows.Forms.Button Field_button5;
        private System.Windows.Forms.Label label_current_turn;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.Button Field_button7;
        private System.Windows.Forms.Button Field_button4;
        private System.Windows.Forms.Button Field_button1;
        private System.Windows.Forms.Button Field_button8;
        private System.Windows.Forms.Button Field_button9;
        private System.Windows.Forms.Button Field_button3;
        private System.Windows.Forms.Button Field_button6;
        private System.Windows.Forms.Button Field_button2;
    }
}
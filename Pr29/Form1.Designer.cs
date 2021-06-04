namespace Pr29
{
    partial class SelectGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_gameName = new System.Windows.Forms.Label();
            this.label_arrow_left = new System.Windows.Forms.Label();
            this.label_arrow_right = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Exo 2", 54F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор игры";
            // 
            // label_gameName
            // 
            this.label_gameName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_gameName.BackColor = System.Drawing.Color.Transparent;
            this.label_gameName.Font = new System.Drawing.Font("Exo 2", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gameName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_gameName.Location = new System.Drawing.Point(515, 309);
            this.label_gameName.Name = "label_gameName";
            this.label_gameName.Size = new System.Drawing.Size(242, 41);
            this.label_gameName.TabIndex = 1;
            this.label_gameName.Text = "Крестики нолики";
            this.label_gameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_arrow_left
            // 
            this.label_arrow_left.AutoSize = true;
            this.label_arrow_left.BackColor = System.Drawing.Color.Transparent;
            this.label_arrow_left.Font = new System.Drawing.Font("Molot", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_arrow_left.ForeColor = System.Drawing.Color.LightGray;
            this.label_arrow_left.Location = new System.Drawing.Point(441, 300);
            this.label_arrow_left.Name = "label_arrow_left";
            this.label_arrow_left.Size = new System.Drawing.Size(43, 55);
            this.label_arrow_left.TabIndex = 2;
            this.label_arrow_left.Text = "<";
            this.label_arrow_left.Click += new System.EventHandler(this.label_arrow_left_Click);
            this.label_arrow_left.MouseLeave += new System.EventHandler(this.label_arrow_left_MouseLeave);
            this.label_arrow_left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_arrow_left_MouseMove);
            // 
            // label_arrow_right
            // 
            this.label_arrow_right.AutoSize = true;
            this.label_arrow_right.BackColor = System.Drawing.Color.Transparent;
            this.label_arrow_right.Font = new System.Drawing.Font("Molot", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_arrow_right.ForeColor = System.Drawing.Color.LightGray;
            this.label_arrow_right.Location = new System.Drawing.Point(777, 300);
            this.label_arrow_right.Name = "label_arrow_right";
            this.label_arrow_right.Size = new System.Drawing.Size(44, 55);
            this.label_arrow_right.TabIndex = 3;
            this.label_arrow_right.Text = ">";
            this.label_arrow_right.Click += new System.EventHandler(this.label_arrow_right_Click);
            this.label_arrow_right.MouseLeave += new System.EventHandler(this.label_arrow_right_MouseLeave);
            this.label_arrow_right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_arrow_right_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Pr29.ResourceImages.Button_startV2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Exo 2", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(508, 569);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button1.Size = new System.Drawing.Size(234, 85);
            this.button1.TabIndex = 4;
            this.button1.Text = "Let\'s go";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::Pr29.ResourceImages.Circle;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(1006, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 90);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // SelectGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Pr29.ResourceImages.Background_For_WFV2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_arrow_right);
            this.Controls.Add(this.label_arrow_left);
            this.Controls.Add(this.label_gameName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelectGameForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор игры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_gameName;
        private System.Windows.Forms.Label label_arrow_left;
        private System.Windows.Forms.Label label_arrow_right;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}


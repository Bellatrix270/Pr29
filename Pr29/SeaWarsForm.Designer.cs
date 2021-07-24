namespace Pr29
{
    partial class SeaWarsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeaWarsForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PlayerShips_panel = new System.Windows.Forms.Panel();
            this.PlayerField_panel = new System.Windows.Forms.Panel();
            this.button_restartField = new System.Windows.Forms.Button();
            this.label_occupiedCell = new System.Windows.Forms.Label();
            this.button_occupiedCell = new System.Windows.Forms.Button();
            this.label_freeCell = new System.Windows.Forms.Label();
            this.button_freeCell = new System.Windows.Forms.Button();
            this.label_hitCell = new System.Windows.Forms.Label();
            this.button_hitCell = new System.Windows.Forms.Button();
            this.label_missedCell = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_missedCell = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_avtoGenerate = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.PictureBox_SelectedShip = new Pr29.PictureBoxExtender();
            this.pictureBoxExtender1 = new Pr29.PictureBoxExtender();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_SelectedShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.BackgroundImage = global::Pr29.ResourceImages.Background_for_SeaWarsV3;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainPanel.Controls.Add(this.button_restartField);
            this.MainPanel.Controls.Add(this.label_occupiedCell);
            this.MainPanel.Controls.Add(this.button_occupiedCell);
            this.MainPanel.Controls.Add(this.label_freeCell);
            this.MainPanel.Controls.Add(this.button_freeCell);
            this.MainPanel.Controls.Add(this.label_hitCell);
            this.MainPanel.Controls.Add(this.button_hitCell);
            this.MainPanel.Controls.Add(this.label_missedCell);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.PictureBox_SelectedShip);
            this.MainPanel.Controls.Add(this.pictureBoxExtender1);
            this.MainPanel.Controls.Add(this.listBox1);
            this.MainPanel.Controls.Add(this.button_missedCell);
            this.MainPanel.Controls.Add(this.button_start);
            this.MainPanel.Controls.Add(this.button_avtoGenerate);
            this.MainPanel.Controls.Add(this.label_title);
            this.MainPanel.Controls.Add(this.PlayerField_panel);
            this.MainPanel.Controls.Add(this.PlayerShips_panel);
            this.MainPanel.Location = new System.Drawing.Point(0, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1289, 705);
            this.MainPanel.TabIndex = 4;
            // 
            // PlayerShips_panel
            // 
            this.PlayerShips_panel.Location = new System.Drawing.Point(644, 23);
            this.PlayerShips_panel.Name = "PlayerShips_panel";
            this.PlayerShips_panel.Size = new System.Drawing.Size(207, 595);
            this.PlayerShips_panel.TabIndex = 44;
            // 
            // PlayerField_panel
            // 
            this.PlayerField_panel.Location = new System.Drawing.Point(0, 1);
            this.PlayerField_panel.Name = "PlayerField_panel";
            this.PlayerField_panel.Size = new System.Drawing.Size(648, 617);
            this.PlayerField_panel.TabIndex = 43;
            // 
            // button_restartField
            // 
            this.button_restartField.BackgroundImage = global::Pr29.ResourceImages.Button_start;
            this.button_restartField.FlatAppearance.BorderSize = 0;
            this.button_restartField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_restartField.Font = new System.Drawing.Font("Exo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_restartField.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_restartField.Location = new System.Drawing.Point(992, 369);
            this.button_restartField.Name = "button_restartField";
            this.button_restartField.Size = new System.Drawing.Size(235, 46);
            this.button_restartField.TabIndex = 42;
            this.button_restartField.Text = "Сбросить";
            this.button_restartField.UseVisualStyleBackColor = true;
            this.button_restartField.Click += new System.EventHandler(this.button_restartField_Click);
            // 
            // label_occupiedCell
            // 
            this.label_occupiedCell.AutoSize = true;
            this.label_occupiedCell.Location = new System.Drawing.Point(1040, 556);
            this.label_occupiedCell.Name = "label_occupiedCell";
            this.label_occupiedCell.Size = new System.Drawing.Size(87, 13);
            this.label_occupiedCell.TabIndex = 41;
            this.label_occupiedCell.Text = "Занятая ячейка";
            // 
            // button_occupiedCell
            // 
            this.button_occupiedCell.BackColor = System.Drawing.Color.Transparent;
            this.button_occupiedCell.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_occupiedCell.BackgroundImage")));
            this.button_occupiedCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_occupiedCell.FlatAppearance.BorderSize = 0;
            this.button_occupiedCell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_occupiedCell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_occupiedCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_occupiedCell.Location = new System.Drawing.Point(964, 527);
            this.button_occupiedCell.Name = "button_occupiedCell";
            this.button_occupiedCell.Size = new System.Drawing.Size(70, 70);
            this.button_occupiedCell.TabIndex = 40;
            this.button_occupiedCell.UseVisualStyleBackColor = false;
            // 
            // label_freeCell
            // 
            this.label_freeCell.AutoSize = true;
            this.label_freeCell.Location = new System.Drawing.Point(858, 557);
            this.label_freeCell.Name = "label_freeCell";
            this.label_freeCell.Size = new System.Drawing.Size(100, 13);
            this.label_freeCell.TabIndex = 39;
            this.label_freeCell.Text = "Свободная ячейка";
            // 
            // button_freeCell
            // 
            this.button_freeCell.BackColor = System.Drawing.Color.Transparent;
            this.button_freeCell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWars;
            this.button_freeCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_freeCell.FlatAppearance.BorderSize = 0;
            this.button_freeCell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_freeCell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_freeCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_freeCell.Location = new System.Drawing.Point(781, 527);
            this.button_freeCell.Name = "button_freeCell";
            this.button_freeCell.Size = new System.Drawing.Size(70, 70);
            this.button_freeCell.TabIndex = 38;
            this.button_freeCell.UseVisualStyleBackColor = false;
            // 
            // label_hitCell
            // 
            this.label_hitCell.AutoSize = true;
            this.label_hitCell.Location = new System.Drawing.Point(1040, 626);
            this.label_hitCell.Name = "label_hitCell";
            this.label_hitCell.Size = new System.Drawing.Size(63, 13);
            this.label_hitCell.TabIndex = 37;
            this.label_hitCell.Text = "Попадание";
            // 
            // button_hitCell
            // 
            this.button_hitCell.BackColor = System.Drawing.Color.Transparent;
            this.button_hitCell.BackgroundImage = global::Pr29.ResourceImages.hit_cell_for_SWV2;
            this.button_hitCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_hitCell.FlatAppearance.BorderSize = 0;
            this.button_hitCell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_hitCell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_hitCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hitCell.Location = new System.Drawing.Point(967, 597);
            this.button_hitCell.Name = "button_hitCell";
            this.button_hitCell.Size = new System.Drawing.Size(70, 70);
            this.button_hitCell.TabIndex = 36;
            this.button_hitCell.UseVisualStyleBackColor = false;
            // 
            // label_missedCell
            // 
            this.label_missedCell.AutoSize = true;
            this.label_missedCell.Location = new System.Drawing.Point(858, 627);
            this.label_missedCell.Name = "label_missedCell";
            this.label_missedCell.Size = new System.Drawing.Size(46, 13);
            this.label_missedCell.TabIndex = 35;
            this.label_missedCell.Text = "Промах";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "label2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(231, 620);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(212, 56);
            this.listBox1.TabIndex = 21;
            // 
            // button_missedCell
            // 
            this.button_missedCell.BackColor = System.Drawing.Color.Transparent;
            this.button_missedCell.BackgroundImage = global::Pr29.ResourceImages.missed_cell_for_SWV2;
            this.button_missedCell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_missedCell.FlatAppearance.BorderSize = 0;
            this.button_missedCell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_missedCell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_missedCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_missedCell.Location = new System.Drawing.Point(781, 597);
            this.button_missedCell.Name = "button_missedCell";
            this.button_missedCell.Size = new System.Drawing.Size(70, 70);
            this.button_missedCell.TabIndex = 18;
            this.button_missedCell.UseVisualStyleBackColor = false;
            // 
            // button_start
            // 
            this.button_start.BackgroundImage = global::Pr29.ResourceImages.Button_start;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Exo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_start.Location = new System.Drawing.Point(992, 285);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(235, 46);
            this.button_start.TabIndex = 17;
            this.button_start.Text = "Начать";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_avtoGenerate
            // 
            this.button_avtoGenerate.BackgroundImage = global::Pr29.ResourceImages.Button_start;
            this.button_avtoGenerate.FlatAppearance.BorderSize = 0;
            this.button_avtoGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_avtoGenerate.Font = new System.Drawing.Font("Exo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_avtoGenerate.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_avtoGenerate.Location = new System.Drawing.Point(992, 444);
            this.button_avtoGenerate.Name = "button_avtoGenerate";
            this.button_avtoGenerate.Size = new System.Drawing.Size(235, 46);
            this.button_avtoGenerate.TabIndex = 16;
            this.button_avtoGenerate.Text = "Автоматически";
            this.button_avtoGenerate.UseVisualStyleBackColor = true;
            this.button_avtoGenerate.Click += new System.EventHandler(this.button_avtoGenerate_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Exo 2", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_title.Location = new System.Drawing.Point(718, 35);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(467, 57);
            this.label_title.TabIndex = 15;
            this.label_title.Text = "Расставте корабли";
            // 
            // PictureBox_SelectedShip
            // 
            this.PictureBox_SelectedShip.A_RotationImage = null;
            this.PictureBox_SelectedShip.Enabled = false;
            this.PictureBox_SelectedShip.Location = new System.Drawing.Point(861, 471);
            this.PictureBox_SelectedShip.Name = "PictureBox_SelectedShip";
            this.PictureBox_SelectedShip.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.PictureBox_SelectedShip.Rotation = 0F;
            this.PictureBox_SelectedShip.ShipSize = 0;
            this.PictureBox_SelectedShip.Size = new System.Drawing.Size(100, 50);
            this.PictureBox_SelectedShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_SelectedShip.TabIndex = 23;
            this.PictureBox_SelectedShip.TabStop = false;
            // 
            // pictureBoxExtender1
            // 
            this.pictureBoxExtender1.A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            this.pictureBoxExtender1.Image = this.pictureBoxExtender1.Image;
            this.pictureBoxExtender1.Location = new System.Drawing.Point(992, 213);
            this.pictureBoxExtender1.Name = "pictureBoxExtender1";
            this.pictureBoxExtender1.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.pictureBoxExtender1.Rotation = 0F;
            this.pictureBoxExtender1.ShipSize = 0;
            this.pictureBoxExtender1.Size = new System.Drawing.Size(104, 39);
            this.pictureBoxExtender1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxExtender1.TabIndex = 22;
            this.pictureBoxExtender1.TabStop = false;
            this.pictureBoxExtender1.Tag = "2";
            this.pictureBoxExtender1.Click += new System.EventHandler(this.SetSeclectedShip);
            // 
            // SeaWarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1289, 681);
            this.Controls.Add(this.MainPanel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SeaWarsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SeaWarsForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_SelectedShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        private void CreatePlayerMap()
        {
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            for (int i = 1; i <= mapsize*2; i++)
            {
                System.Windows.Forms.Button cell = new System.Windows.Forms.Button();
                if (i % 2 == 0)
                {
                    cell.Location = new System.Drawing.Point((i - 1) * (cellSize / 2) + 45, 0);
                    cell.Text = (i/2).ToString();
                }
                else
                {
                    cell.Location = new System.Drawing.Point(15, (i - 1) * (cellSize / 2) + 56);
                    cell.Text = alphabet[i/2].ToString();
                }
                cell.Size = new System.Drawing.Size(cellSize-10, cellSize-10);
                cell.BackColor = System.Drawing.Color.Transparent;
                cell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWarsV2;
                cell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                cell.FlatAppearance.BorderSize = 0;
                cell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                cell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                //cell.Click += new System.EventHandler( (object sender, System.EventArgs e)=> { isplaying = true; });
                MainPanel.Controls.Add(cell);
            }

            for (int i = 0; i < mapsize; i++)
            {
                for (int j = 0; j < mapsize; j++)
                {
                    playerMap[i, j] = 0;
                    System.Windows.Forms.Button cell = new System.Windows.Forms.Button();
                    cell.Location = new System.Drawing.Point(i*cellSize+67,j*cellSize+50);
                    cell.Size = new System.Drawing.Size(cellSize, cellSize);
                    cell.BackColor = System.Drawing.Color.Transparent;
                    cell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWars;
                    cell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    cell.FlatAppearance.BorderSize = 0;
                    cell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    cell.Click += new System.EventHandler(PlaceShip);
                    cell.MouseMove += new System.Windows.Forms.MouseEventHandler(Cell_mouseMove);
                    ButtonsCell[i, j] = cell;
                    ButtonsLocation.Add(cell.Location);
                    MainPanel.Controls.Add(cell);
                }
            }
        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_avtoGenerate;
        private System.Windows.Forms.Button button_missedCell;
        private PictureBoxExtender pictureBoxExtender1;
        private PictureBoxExtender PictureBox_SelectedShip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_hitCell;
        private System.Windows.Forms.Button button_hitCell;
        private System.Windows.Forms.Label label_missedCell;
        private System.Windows.Forms.Label label_occupiedCell;
        private System.Windows.Forms.Button button_occupiedCell;
        private System.Windows.Forms.Label label_freeCell;
        private System.Windows.Forms.Button button_freeCell;
        private System.Windows.Forms.Button button_restartField;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel PlayerField_panel;
        private System.Windows.Forms.Panel PlayerShips_panel;
    }
}
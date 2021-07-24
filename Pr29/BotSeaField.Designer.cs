using Pr29.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    // Идея partial класса в том что бы избежать повторного создания графических элементов для объектов класса.
    partial class BotSeaField
    {
        public int i = 0;
        protected PictureBoxExtender[] Ships = new PictureBoxExtender[10];

        /// <summary>
        /// Создание графических объектов (кораблей) для класса BotSeaField и его дочерних классов.
        /// </summary>
        /// <param name="panel"> Конторол для добавления короблей на форму SeaWarsForm. </param>
        /// <param name="locationFirstShip"> Положенние первого коробля, относительно которого будут распологаться остальные коробли. </param>
        /// <param name="INDENT_BETWEEN_SHIPS"> Отступ между короблями. </param>
        protected virtual void InitializeShips(System.Windows.Forms.Control panel, System.Drawing.Point locationFirstShip,
                                       int INDENT_BETWEEN_SHIPS)
        {
            panel.SuspendLayout();

            for (int i = 0; i < Ships.Length; i++)
            {
                Ships[i] = new PictureBoxExtender();
                ((System.ComponentModel.ISupportInitialize)(Ships[i])).BeginInit();
                panel.Controls.Add(Ships[i]);
                GC.KeepAlive(Ships[i]);
            }

            #region ship_four_cell
            Ships[0].A_RotationImage = global::Pr29.ResourceImages.Ship4_for_SeaWars;
            Ships[0].Image = ResourceImages.Ship4_for_SeaWars;
            Ships[0].Location = new System.Drawing.Point(locationFirstShip.X, locationFirstShip.Y);
            Ships[0].Name = "ship_four_cell";
            Ships[0].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[0].Rotation = 0F;
            Ships[0].ShipSize = 0;
            Ships[0].Size = new System.Drawing.Size(203, 55);
            Ships[0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[0].TabIndex = 33;
            Ships[0].TabStop = false;
            Ships[0].Tag = "4";
            #endregion

            #region ship_three_cell
            Ships[1].A_RotationImage = global::Pr29.ResourceImages.Ship3_for_SeaWars;
            Ships[1].Image = ResourceImages.Ship3_for_SeaWars;
            Ships[1].Location = new System.Drawing.Point(0, Ships[0].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[1].Name = "ship_three_cell";
            Ships[1].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[1].Rotation = 0F;
            Ships[1].ShipSize = 0;
            Ships[1].Size = new System.Drawing.Size(164, 34);
            Ships[1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[1].TabIndex = 31;
            Ships[1].TabStop = false;
            Ships[1].Tag = "3";
            #endregion

            #region ship_three_cell2
            Ships[2].A_RotationImage = global::Pr29.ResourceImages.Ship3_for_SeaWars;
            Ships[2].Image = ResourceImages.Ship3_for_SeaWars;
            Ships[2].Location = new System.Drawing.Point(0, Ships[1].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[2].Name = "ship_three_cell2";
            Ships[2].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[2].Rotation = 0F;
            Ships[2].ShipSize = 0;
            Ships[2].Size = new System.Drawing.Size(164, 34);
            Ships[2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[2].TabIndex = 32;
            Ships[2].TabStop = false;
            Ships[2].Tag = "3";
            #endregion

            #region ship_two_cell
            Ships[3].A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            Ships[3].Image = ResourceImages.Ship2_for_SeaWars;
            Ships[3].Location = new System.Drawing.Point(0, Ships[2].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[3].Name = "ship_two_cell";
            Ships[3].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[3].Rotation = 0F;
            Ships[3].ShipSize = 0;
            Ships[3].Size = new System.Drawing.Size(104, 39);
            Ships[3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[3].TabIndex = 28;
            Ships[3].TabStop = false;
            Ships[3].Tag = "2";
            #endregion

            #region ship_two_cell2 
            Ships[4].A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            Ships[4].Image = ResourceImages.Ship2_for_SeaWars;
            Ships[4].Location = new System.Drawing.Point(0, Ships[3].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[4].Name = "ship_two_cell2";
            Ships[4].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[4].Rotation = 0F;
            Ships[4].ShipSize = 0;
            Ships[4].Size = new System.Drawing.Size(104, 39);
            Ships[4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[4].TabIndex = 29;
            Ships[4].TabStop = false;
            Ships[4].Tag = "2";
            #endregion

            #region ship_cell_cell3
            Ships[5].A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            Ships[5].Image = ResourceImages.Ship2_for_SeaWars;
            Ships[5].Location = new System.Drawing.Point(0, Ships[4].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[5].Name = "ship_two_cell3";
            Ships[5].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[5].Rotation = 0F;
            Ships[5].ShipSize = 0;
            Ships[5].Size = new System.Drawing.Size(104, 39);
            Ships[5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[5].TabIndex = 30;
            Ships[5].TabStop = false;
            Ships[5].Tag = "2";
            #endregion

            #region ship_one_cell
            Ships[6].A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            Ships[6].Image = ResourceImages.Ship1_for_SeaWars;
            Ships[6].Location = new System.Drawing.Point(0, Ships[5].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[6].Name = "ship_one_cell";
            Ships[6].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[6].Rotation = 0F;
            Ships[6].ShipSize = 0;
            Ships[6].Size = new System.Drawing.Size(50, 26);
            Ships[6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[6].TabIndex = 24;
            Ships[6].TabStop = false;
            Ships[6].Tag = "1";
            #endregion

            #region ship_one_cell2
            Ships[7].A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            Ships[7].Image = ResourceImages.Ship1_for_SeaWars;
            Ships[7].Location = new System.Drawing.Point(0, Ships[6].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[7].Name = "ship_one_cell2";
            Ships[7].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[7].Rotation = 0F;
            Ships[7].ShipSize = 0;
            Ships[7].Size = new System.Drawing.Size(50, 26);
            Ships[7].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[7].TabIndex = 25;
            Ships[7].TabStop = false;
            Ships[7].Tag = "1";
            #endregion

            #region ship_one_cell3
            Ships[8].A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            Ships[8].Image = ResourceImages.Ship1_for_SeaWars;
            Ships[8].Location = new System.Drawing.Point(0, Ships[7].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[8].Name = "ship_one_cell3";
            Ships[8].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[8].Rotation = 0F;
            Ships[8].ShipSize = 0;
            Ships[8].Size = new System.Drawing.Size(50, 26);
            Ships[8].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[8].TabIndex = 26;
            Ships[8].TabStop = false;
            Ships[8].Tag = "1";
            #endregion

            #region ship_one_cell4
            Ships[9].A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            Ships[9].Image = ResourceImages.Ship4_for_SeaWars;
            Ships[9].Location = new System.Drawing.Point(0, Ships[8].Location.Y + INDENT_BETWEEN_SHIPS);
            Ships[9].Name = "ship_one_cell4";
            Ships[9].RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            Ships[9].Rotation = 0F;
            Ships[9].ShipSize = 0;
            Ships[9].Size = new System.Drawing.Size(50, 26);
            Ships[9].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Ships[9].TabIndex = 27;
            Ships[9].TabStop = false;
            Ships[9].Tag = "1";
            #endregion

            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();

            for (int i = 0; i < Ships.Length; i++)
                ((System.ComponentModel.ISupportInitialize)(Ships[i])).EndInit();

        }
    }
}

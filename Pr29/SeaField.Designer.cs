using Pr29.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    // Идея partial класса в том что бы избежать повторного создания графических элементов для объектов класса.
    partial class SeaField
    {
        public int i = 0;
        private PictureBoxExtender[] Ships;
        private PictureBoxExtender ship_four_cell = new PictureBoxExtender();
        private PictureBoxExtender ship_three_cell = new PictureBoxExtender();
        private PictureBoxExtender ship_three_cell2 = new PictureBoxExtender();
        private PictureBoxExtender ship_two_cell = new PictureBoxExtender();
        private PictureBoxExtender ship_two_cell2 = new PictureBoxExtender();
        private PictureBoxExtender ship_two_cell3 = new PictureBoxExtender();
        private PictureBoxExtender ship_one_cell = new PictureBoxExtender();
        private PictureBoxExtender ship_one_cell2 = new PictureBoxExtender();
        private PictureBoxExtender ship_one_cell3 = new PictureBoxExtender();
        private PictureBoxExtender ship_one_cell4 = new PictureBoxExtender();

        /// <summary>
        /// Метод доступен только наследниками класса SeaField (Class Bot)
        /// </summary>
        /// <param name="indexShipOfArray">Индекс коробля от 0 до 9</param>
        /// <returns>Возвращает данные о коробле из массива Ships (Class SeaField)</returns>
        protected PictureBoxExtender getInfoAboutShip(int indexShipOfArray)
        {
            return Ships[indexShipOfArray];
        }

        /// <summary>
        /// Создание графических объектов (кораблей) для класса SeaField.
        /// </summary>
        private void InitializeComponent()
        {
            Ships = new PictureBoxExtender[10];
            Ships[0] = ship_four_cell;
            Ships[1] = ship_three_cell;
            Ships[2] = ship_three_cell2;
            Ships[3] = ship_two_cell;
            Ships[4] = ship_two_cell2;
            Ships[5] = ship_two_cell3;
            Ships[6] = ship_one_cell;
            Ships[7] = ship_one_cell2;
            Ships[8] = ship_one_cell3;
            Ships[9] = ship_one_cell4;

            for (int i = 0; i < Ships.Length; i++)
                panel.Controls.Add(Ships[i]);

            #region ship_four_cell
            this.ship_four_cell.A_RotationImage = global::Pr29.ResourceImages.Ship4_for_SeaWars;
            this.ship_four_cell.Image = ResourceImages.Ship4_for_SeaWars;
            this.ship_four_cell.Location = new System.Drawing.Point(676, 140);
            this.ship_four_cell.Name = "ship_four_cell";
            this.ship_four_cell.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_four_cell.Rotation = 0F;
            this.ship_four_cell.ShipSize = 0;
            this.ship_four_cell.Size = new System.Drawing.Size(203, 55);
            this.ship_four_cell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_four_cell.TabIndex = 33;
            this.ship_four_cell.TabStop = false;
            this.ship_four_cell.Tag = "4";
            #endregion

            #region ship_three_cell
            this.ship_three_cell.A_RotationImage = global::Pr29.ResourceImages.Ship3_for_SeaWars;
            this.ship_three_cell.Image = ResourceImages.Ship3_for_SeaWars;
            this.ship_three_cell.Location = new System.Drawing.Point(676, 257);
            this.ship_three_cell.Name = "ship_three_cell";
            this.ship_three_cell.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_three_cell.Rotation = 0F;
            this.ship_three_cell.ShipSize = 0;
            this.ship_three_cell.Size = new System.Drawing.Size(164, 34);
            this.ship_three_cell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_three_cell.TabIndex = 31;
            this.ship_three_cell.TabStop = false;
            this.ship_three_cell.Tag = "3";
            #endregion

            #region ship_three_cell2
            this.ship_three_cell2.A_RotationImage = global::Pr29.ResourceImages.Ship3_for_SeaWars;
            this.ship_three_cell2.Image = ResourceImages.Ship3_for_SeaWars;
            this.ship_three_cell2.Location = new System.Drawing.Point(676, 209);
            this.ship_three_cell2.Name = "ship_three_cell2";
            this.ship_three_cell2.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_three_cell2.Rotation = 0F;
            this.ship_three_cell2.ShipSize = 0;
            this.ship_three_cell2.Size = new System.Drawing.Size(164, 34);
            this.ship_three_cell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_three_cell2.TabIndex = 32;
            this.ship_three_cell2.TabStop = false;
            this.ship_three_cell2.Tag = "3";
            #endregion

            #region ship_two_cell
            this.ship_two_cell.A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell.Image = ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell.Location = new System.Drawing.Point(676, 411);
            this.ship_two_cell.Name = "ship_two_cell";
            this.ship_two_cell.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_two_cell.Rotation = 0F;
            this.ship_two_cell.ShipSize = 0;
            this.ship_two_cell.Size = new System.Drawing.Size(104, 39);
            this.ship_two_cell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_two_cell.TabIndex = 28;
            this.ship_two_cell.TabStop = false;
            this.ship_two_cell.Tag = "2";
            #endregion

            #region ship_two_cell2 
            this.ship_two_cell2.A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell2.Image = ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell2.Location = new System.Drawing.Point(676, 358);
            this.ship_two_cell2.Name = "ship_two_cell2";
            this.ship_two_cell2.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_two_cell2.Rotation = 0F;
            this.ship_two_cell2.ShipSize = 0;
            this.ship_two_cell2.Size = new System.Drawing.Size(104, 39);
            this.ship_two_cell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_two_cell2.TabIndex = 29;
            this.ship_two_cell2.TabStop = false;
            this.ship_two_cell2.Tag = "2";
            #endregion

            #region ship_cell_cell3
            this.ship_two_cell3.A_RotationImage = global::Pr29.ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell3.Image = ResourceImages.Ship2_for_SeaWars;
            this.ship_two_cell3.Location = new System.Drawing.Point(676, 305);
            this.ship_two_cell3.Name = "ship_two_cell3";
            this.ship_two_cell3.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_two_cell3.Rotation = 0F;
            this.ship_two_cell3.ShipSize = 0;
            this.ship_two_cell3.Size = new System.Drawing.Size(104, 39);
            this.ship_two_cell3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_two_cell3.TabIndex = 30;
            this.ship_two_cell3.TabStop = false;
            this.ship_two_cell3.Tag = "2";
            #endregion

            #region ship_one_cell
            this.ship_one_cell.A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell.Image = ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell.Location = new System.Drawing.Point(676, 464);
            this.ship_one_cell.Name = "ship_one_cell";
            this.ship_one_cell.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_one_cell.Rotation = 0F;
            this.ship_one_cell.ShipSize = 0;
            this.ship_one_cell.Size = new System.Drawing.Size(50, 26);
            this.ship_one_cell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_one_cell.TabIndex = 24;
            this.ship_one_cell.TabStop = false;
            this.ship_one_cell.Tag = "1";
            #endregion

            #region ship_one_cell2
            this.ship_one_cell2.A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell2.Image = ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell2.Location = new System.Drawing.Point(676, 504);
            this.ship_one_cell2.Name = "ship_one_cell2";
            this.ship_one_cell2.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_one_cell2.Rotation = 0F;
            this.ship_one_cell2.ShipSize = 0;
            this.ship_one_cell2.Size = new System.Drawing.Size(50, 26);
            this.ship_one_cell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_one_cell2.TabIndex = 25;
            this.ship_one_cell2.TabStop = false;
            this.ship_one_cell2.Tag = "1";
            #endregion

            #region ship_one_cell3
            this.ship_one_cell3.A_RotationImage = global::Pr29.ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell3.Image = ResourceImages.Ship1_for_SeaWars;
            this.ship_one_cell3.Location = new System.Drawing.Point(676, 544);
            this.ship_one_cell3.Name = "ship_one_cell3";
            this.ship_one_cell3.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_one_cell3.Rotation = 0F;
            this.ship_one_cell3.ShipSize = 0;
            this.ship_one_cell3.Size = new System.Drawing.Size(50, 26);
            this.ship_one_cell3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_one_cell3.TabIndex = 26;
            this.ship_one_cell3.TabStop = false;
            this.ship_one_cell3.Tag = "1";
            #endregion

            #region ship_one_cell4
            this.ship_one_cell4.A_RotationImage = global::Pr29.ResourceImages.Ship4_for_SeaWars;
            this.ship_one_cell4.Image = ResourceImages.Ship4_for_SeaWars;
            this.ship_one_cell4.Location = new System.Drawing.Point(676, 584);
            this.ship_one_cell4.Name = "ship_one_cell4";
            this.ship_one_cell4.RotateFlip = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.ship_one_cell4.Rotation = 0F;
            this.ship_one_cell4.ShipSize = 0;
            this.ship_one_cell4.Size = new System.Drawing.Size(50, 26);
            this.ship_one_cell4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ship_one_cell4.TabIndex = 27;
            this.ship_one_cell4.TabStop = false;
            this.ship_one_cell4.Tag = "1";
            #endregion

            #region EventHandlers

            if (forPlayer)
            {
                for (int i = 0; i < Ships.Length; i++)
                    Ships[i].Click += new System.EventHandler(Event_SetSelectedShip);
            }

            #endregion
        }
    }
}

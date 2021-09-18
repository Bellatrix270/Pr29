using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr29
{
    /// <summary>
    /// Класс со своим игровым полем и кораблями, представляющий поведение игрока.
    /// </summary>
    class Player
    {
        public int LifeShips { get; private set; } = 10;
        public bool IsHit { get; private set; }

        private PlayerSeaField SeaField;
        private Bot TargetMap;

        public ShipCounter CountShip { get; private set; } = new ShipCounter(1,2,3,4);

        public Player(Control panel_ButtonCells, Control panel_Ships, PictureBoxExtender SelectedShip, Bot targetMap)
        {
            SeaField = new PlayerSeaField(10, panel_ButtonCells, panel_Ships, SelectedShip);
            SeaField.CreateMap();
            TargetMap = targetMap;
        }

        public bool[,] GetMap()
        {
            return SeaField.IsShipOnCell;
        }

        public void ChangeImageButtonsCell(System.Drawing.Point CellPoint, System.Drawing.Bitmap Image)
        {
            SeaField.ChangeBackgroundImage(CellPoint, Image);
        }

        public void AvtoPlaceShips ()
        {
            SeaField.AvtoPlaceShips();
        }

        public void RestoreBackgroundCells()
        {
            SeaField.RestoreBackgroundImageField();
        }

        public System.Drawing.Point[] GetPositonButtonsCell ()
        {
            System.Drawing.Point[] Locations = new System.Drawing.Point[SeaField.ButtonsCell.Length];
            int i = 0;
            foreach (var item in SeaField.ButtonsCell)
            {
                Locations[i] = item.Location;
                i++;
            }
            return Locations;
        }

        public void Hit (object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            int index_i = (pressedButton.Location.X - 600) / PlayerSeaField.CELL_SIZE - 1;
            int index_j = pressedButton.Location.Y / PlayerSeaField.CELL_SIZE;

            if (TargetMap.GetMap()[index_i, index_j])
            {
                MessageBox.Show("Есть попадание");
                IsHit = true;
                pressedButton.BackgroundImage = ResourceImages.hit_cell_for_SWV2;
            }
            else
            {
                MessageBox.Show("Промах");
                IsHit = false;
                pressedButton.BackgroundImage = ResourceImages.missed_cell_for_SWV2;
            }

            pressedButton.Enabled = false;
            pressedButton.Click -= new EventHandler(Hit);
            if (!IsHit)
                while (TargetMap.Shot())
                    System.Threading.Thread.Sleep(500);
            //TargetMap.Shot();
        }

    }
}

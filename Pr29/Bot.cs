using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    class Bot
    {
        private int[,] map;
        private int[,] freePointOnMap;
        private int countShip = 10;
        private int lifeShip = 0;

        public Bot(int[,] map)
        {
            this.map = map;
            freePointOnMap = map;
        }

        public void CreateMap()
        {
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            for (int i = 1; i <= mapsize * 2; i++)
            {
                System.Windows.Forms.Button cell = new System.Windows.Forms.Button();
                if (i % 2 == 0)
                {
                    cell.Location = new System.Drawing.Point((i - 1) * (cellSize / 2) + 45, 0);
                    cell.Text = (i / 2).ToString();
                }
                else
                {
                    cell.Location = new System.Drawing.Point(15, (i - 1) * (cellSize / 2) + 56);
                    cell.Text = alphabet[i / 2].ToString();
                }
                cell.Size = new System.Drawing.Size(cellSize - 10, cellSize - 10);
                cell.BackColor = System.Drawing.Color.Transparent;
                cell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWarsV2;
                cell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                cell.FlatAppearance.BorderSize = 0;
                cell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                cell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                panel1.Controls.Add(cell);
            }

            for (int i = 0; i < mapsize; i++)
            {
                for (int j = 0; j < mapsize; j++)
                {
                    playerMap[i, j] = 0;
                    System.Windows.Forms.Button cell = new System.Windows.Forms.Button();
                    cell.Location = new System.Drawing.Point(i * cellSize + 67, j * cellSize + 50);
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
                    panel1.Controls.Add(cell);
                }
            }
        }

        void PlaceShips()
        {
            while (countShip > 0)
            {

            }
        }

        void Shot()
        {

        }
    }
}

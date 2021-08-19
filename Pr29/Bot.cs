using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    /// <summary>
    /// Бот для игры в морской, со своим игровым полем.
    /// </summary>
    class Bot
    {
        public int lifeShip = 10;

        List<Point> FreeCellPosition = new List<Point>();
        new BotSeaField Map;
        BotSeaField targetMap;
        PictureBoxExtender[] ships = new PictureBoxExtender[10];

        public Bot(System.Windows.Forms.Control panel, System.Windows.Forms.ListBox console, PlayerSeaField targetMap)
        {
            Map = new BotSeaField(10, panel, console);
            Map.CreateMap();
            Map.AvtoPlaceShips(new Point(54, -54));
            Map.ActivateButtonsCell();

            this.targetMap = targetMap;

            foreach (var item in this.targetMap.ButtonsCell)
                FreeCellPosition.Add(item.Location);

            //getInfoAboutShip(0);
        }

        private Point ChooseCellOnHit()
        {
            return FreeCellPosition[new Random().Next(FreeCellPosition.Count)];
        }

        public bool Shot()
        {
            bool hit = false;
            Point shotCell = ChooseCellOnHit();
            FreeCellPosition.Remove(shotCell);
            if (targetMap.IsShipOnCell[0,0])
            {
                hit = true;
                targetMap.ChangeBackgroundImage(shotCell, ResourceImages.hit_cell_for_SWV2);
            }
            else
            {
                hit = false;
                targetMap.ChangeBackgroundImage(shotCell, ResourceImages.missed_cell_for_SWV2);
            }

            return hit;
        }

    }
}

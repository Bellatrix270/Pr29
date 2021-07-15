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
    class Bot : SeaField
    {
        public int lifeShip = 10;

        List<Point> FreeCellPosition = new List<Point>();
        SeaField Map;
        SeaField targetMap;
        PictureBoxExtender[] ships;

        public Bot(System.Windows.Forms.Control panel, System.Windows.Forms.ListBox console, SeaField targetMap)
        {
            Map = new SeaField(10, panel, console);
            Map.CreateMap();
            //ships = Ships;
            //Map.AvtoPlaceShips(ships);

            this.targetMap = targetMap;

            foreach (var item in this.targetMap.ButtonsCell)
                FreeCellPosition.Add(item.Location);

            getInfoAboutShip(0);
        }

        public void Shot()
        {
            bool hit = false;
            Point shotCell = FreeCellPosition[new Random().Next(FreeCellPosition.Count)];
            FreeCellPosition.Remove(shotCell);
            targetMap.ChangeBackgroundImage(shotCell, ResourceImages.hit_cell_for_SWV2);
            if (targetMap.Map[0,0] == 1)
            {

            }
        }
    }
}

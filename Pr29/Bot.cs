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

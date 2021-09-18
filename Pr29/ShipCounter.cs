using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    struct ShipCounter
    {
        public int CountFourCellShips;
        public int CountThreeCellShips;
        public int CountTwoCellShips;
        public int CountOneCellShips;

        public int CountLiveShips
        {
            get { return CountFourCellShips + CountThreeCellShips + CountTwoCellShips + CountOneCellShips; }
        }

        public ShipCounter(int countFourCellShips, int countThreeCellShips, int countTwoCellShips, int countOneCellShips)
        {
            CountFourCellShips = countFourCellShips;
            CountThreeCellShips = countThreeCellShips;
            CountTwoCellShips = countTwoCellShips;
            CountOneCellShips = countOneCellShips;
        }

    }
}

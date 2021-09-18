using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr29
{
    enum Difficult
    {
        easy,
        normal,
        hard
    }
    /// <summary>
    /// Бот для игры в морской, со своим игровым полем.
    /// </summary>
    class Bot
    {
        public int lifeShip { get; private set; } = 10;
        private readonly Difficult BotDifficult;
        private List<Point> CellToShoot_Normal = new List<Point>();
        private List<Point> CellFinishingMode = new List<Point>();
        private int Step = 0;
        private bool ModeIsScout = true;
        private int Rotation = -1;
        private bool PreviousShotIsHit;
        private Point AnchorPointFinishingMode;
        private List<Point> ArrayCellsFinishMode = new List<Point>();
        private List<Point>[] CellFinishingModeV2 = new List<Point>[2];

        private delegate void DelegateFullArray();

        List<Point> FreeCellPosition = new List<Point>();
        BotSeaField Map;
        Player Target;
        PictureBoxExtender[] ships = new PictureBoxExtender[10];

        public Bot(System.Windows.Forms.Control panel, System.Windows.Forms.ListBox console, Difficult botDifficult)
        {
            Map = new BotSeaField(10, panel, console);
            BotDifficult = botDifficult;
            CellFinishingModeV2[0] = new List<Point>();
            CellFinishingModeV2[1] = new List<Point>();
            //getInfoAboutShip(0);
        }

        
        public bool Initialize(Player target)
        {
            Map.CreateMap();
            Map.AvtoPlaceShips();
            FullTargetCell();
            Target = target;
            Map.ActivateButtonsCell(Target.Hit);
            FreeCellPosition = Target.GetPositonButtonsCell().ToList();
            if (Target != null)
                return true;
            return false;
        }

        private void FullTargetCell()
        {
            // Массив делегатов.
            DelegateFullArray[] funcsToFullDiagonals = new DelegateFullArray[9];
            funcsToFullDiagonals[0] = new DelegateFullArray(
                delegate 
                {
                    FillDiagonals_I(6);
                }
            );
            funcsToFullDiagonals[1] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_I(2);
                }
            );
            funcsToFullDiagonals[2] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_J(2);
                }
            );
            funcsToFullDiagonals[3] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_J(6);
                }
            );
            funcsToFullDiagonals[4] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_I(0);
                }
            );
            funcsToFullDiagonals[5] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_I(8);
                }
            );
            funcsToFullDiagonals[6] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_I(4);
                }
            );
            funcsToFullDiagonals[7] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_J(8);
                }
            );
            funcsToFullDiagonals[8] = new DelegateFullArray(
                delegate
                {
                    FillDiagonals_J(4);
                }
            );

            List<int> RandomValues = new List<int>();
            for (int i = 0; i < 4; i++)
                RandomValues.Add(i);

            for (int i = 0; i < 4; i++)
            {
                int RandomDiagonal = RandomValues[new Random().Next(RandomValues.Count)];
                RandomValues.Remove(RandomDiagonal);

                funcsToFullDiagonals[RandomDiagonal]();
            }

            for (int i = 4; i < 9; i++)
                RandomValues.Add(i);

            for (int i = 4; i < 9; i++)
            {
                int RandomDiagonal = RandomValues[new Random().Next(RandomValues.Count)];
                RandomValues.Remove(RandomDiagonal);

                funcsToFullDiagonals[RandomDiagonal]();
            }

        }

        private void FillDiagonals_I(int startPosition)
        {
            int j = 0;
            if (new Random().Next(100) > 50)
            {
                for (int i = startPosition; i < 10; i++)
                {
                    CellToShoot_Normal.Add(new Point((i + 1) * PlayerSeaField.CELL_SIZE, j * PlayerSeaField.CELL_SIZE));
                    j++;
                }
            }
            else
            {
                j = 9 - startPosition;
                for (int i = 9; i >= startPosition; i--)
                {
                    CellToShoot_Normal.Add(new Point((i + 1) * PlayerSeaField.CELL_SIZE, j * PlayerSeaField.CELL_SIZE));
                    j--;
                }
            }
        }

        private void FillDiagonals_J(int startPosition)
        {
            int i = 0;
            if (new Random().Next(100) > 50)
            {
                for (int j = startPosition; j < 10; j++)
                {
                    CellToShoot_Normal.Add(new Point((i + 1) * PlayerSeaField.CELL_SIZE, j * PlayerSeaField.CELL_SIZE));
                    i++;
                }
            }
            else
            {
                i = 9 - startPosition;
                for (int j = 9; j >= startPosition; j--)
                {
                    CellToShoot_Normal.Add(new Point((i + 1) * PlayerSeaField.CELL_SIZE, j * PlayerSeaField.CELL_SIZE));
                    i++;
                }
            }
        }

        public bool[,] GetMap()
        {
            return Map.IsShipOnCell;
        }

        private Point ChooseCellOnHit()
        {
            Point pos = new Point();
            if (BotDifficult == Difficult.easy)
            {
                pos = FreeCellPosition[new Random().Next(FreeCellPosition.Count)];
            }
            else if (BotDifficult == Difficult.normal)
            {
                if (Target.CountShip.CountFourCellShips == 1)
                {
                    pos = CellToShoot_Normal[Step++];
                }
            }
            else
            {

            }

            return pos;
        }

        public bool Shot()
        {
            bool hit = false;
            Point shotCell = new Point();

            if (ModeIsScout)
            {
                shotCell = ChooseCellOnHit();
                FreeCellPosition.Remove(shotCell);
            }
            else
            {
                do
                {
                    shotCell = FinishingShip();
                }
                while (ArrayCellsFinishMode.Contains(shotCell));

            }

            int index_i = shotCell.X / PlayerSeaField.CELL_SIZE - 1;
            int index_j = shotCell.Y / PlayerSeaField.CELL_SIZE;

            if (Target.GetMap()[index_i,index_j])
            {
                hit = true;
                if (ModeIsScout)
                {
                    if (index_i + 1 < 10)
                        CellFinishingModeV2[0].Add(new Point((index_i + 2) * PlayerSeaField.CELL_SIZE, index_j * PlayerSeaField.CELL_SIZE));
                    if (index_i - 1 > 0)
                        CellFinishingModeV2[0].Add(new Point((index_i) * PlayerSeaField.CELL_SIZE, index_j * PlayerSeaField.CELL_SIZE));
                    if (index_j + 1 < 10)
                        CellFinishingModeV2[1].Add(new Point((index_i + 1) * PlayerSeaField.CELL_SIZE, (index_j + 1) * PlayerSeaField.CELL_SIZE));
                    if (index_j - 1 > 0)
                        CellFinishingModeV2[1].Add(new Point((index_i + 1) * PlayerSeaField.CELL_SIZE, (index_j - 1) * PlayerSeaField.CELL_SIZE));
                    AnchorPointFinishingMode = shotCell;
                    ModeIsScout = false;
                }
                Target.ChangeImageButtonsCell(shotCell, ResourceImages.hit_cell_for_SWV2);
            }
            else
            {
                hit = false;
                Target.ChangeImageButtonsCell(shotCell, ResourceImages.missed_cell_for_SWV2);
            }

            return hit;
        }

        // 0 - Horizontal, 1 - Vertical.
        private Point FinishingShip()
        {
            Point pos = new Point();

            if (CellFinishingModeV2[0].Count == CellFinishingModeV2[1].Count && Rotation == -1)
                Rotation = new Random().Next(2);   
            else
                Rotation = CellFinishingModeV2[0].Count > CellFinishingModeV2[1].Count ? 1 : 0;

            if (!PreviousShotIsHit && CellFinishingModeV2[Rotation].Count == 0)
            {
                Rotation = Rotation == 1 ? 0 : 1;
            }

            if (PreviousShotIsHit)
            {
                if (Rotation == 0)
                {
                    if (AnchorPointFinishingMode.X > ArrayCellsFinishMode[ArrayCellsFinishMode.Count-1].X) // Какой-то калл.
                    {
                        Point[] FinishingCell = new Point[2];
                        FinishingCell[0] = new Point(AnchorPointFinishingMode.X + PlayerSeaField.CELL_SIZE, AnchorPointFinishingMode.Y);
                        FinishingCell[1] = new Point(ArrayCellsFinishMode[ArrayCellsFinishMode.Count - 1].X - PlayerSeaField.CELL_SIZE, ArrayCellsFinishMode[ArrayCellsFinishMode.Count - 1].Y);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            pos = CellFinishingModeV2[Rotation][new Random().Next(CellFinishingModeV2[Rotation].Count)];
            CellFinishingModeV2[Rotation].Remove(pos);
            ArrayCellsFinishMode.Add(pos);

            return pos;
        }
    }
}

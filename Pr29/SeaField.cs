using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr29
{   /// <summary>
    /// Игровое поле для игры морской бой.
    /// </summary>
    class SeaField
    {
        private int mapSize;
        public int[,] map { get; }
        private int cellSize = 54;
        private bool forPlayer;
        private Control panel;
        private Button[,] ButtonsCell;
        private List<Point> ButtonsLocation = new List<Point>();

        EventHandler PlaceShip;
        MouseEventHandler Cell_mouseMove;

        /// <summary>
        /// Конструктор, инициализирующий объект - игровое поле игрока.
        /// </summary>
        /// <param name="mapSize"></param>
        /// <param name="forPlayer"></param>
        public SeaField(int mapSize, Control panel, 
            EventHandler PlaceShip, MouseEventHandler Cell_mouseMove)
        {
            this.mapSize = mapSize;
            forPlayer = true;
            this.panel = panel;
            map = new int[mapSize, mapSize];
            ButtonsCell = new Button[mapSize, mapSize];

            this.PlaceShip = PlaceShip;
            this.Cell_mouseMove = Cell_mouseMove;
        }
        /// <summary>
        /// Конструктор, инициализирующий объект - игровое поле противника (бота).
        /// </summary>
        /// <param name="mapSize"></param>
        /// <param name="panel"></param>
        public SeaField(int mapSize, Control panel)
        {
            this.mapSize = mapSize;
            forPlayer = false;
            this.panel = panel;
            map = new int[mapSize, mapSize];
            ButtonsCell = new Button[mapSize, mapSize];

        }
        /// <summary>
        /// Создаёт игровое поле из ячеек.
        /// </summary>
        public void CreateMap()
        {
            if (forPlayer)
                CreatePlayerMap();
            else
                CreateEnemyMap();
        }

        public void CreateEnemyMap()
        {
            // Расстановка нумерных ячеек.
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            alphabet.Reverse();
            int countCell = 1;
            for (int i = mapSize * 2; i >= 1; i--)
            {
                Button cell = new Button();
                if (i % 2 == 0)
                {
                    cell.Location = new Point(612 + (i - 1) * (cellSize / 2) + 45, 0);
                    cell.Text = countCell.ToString();
                    countCell++;
                }
                else
                {
                    cell.Location = new Point(1212 + 15, (i - 1) * (cellSize / 2) + 56);
                    cell.Text = alphabet[i / 2].ToString();
                }
                cell.Size = new Size(cellSize - 10, cellSize - 10);
                cell.BackColor = Color.Transparent;
                cell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWarsV2;
                cell.BackgroundImageLayout = ImageLayout.Zoom;
                cell.FlatAppearance.BorderSize = 0;
                cell.FlatStyle = FlatStyle.Flat;
                cell.FlatAppearance.MouseDownBackColor = Color.Transparent;
                cell.FlatAppearance.MouseOverBackColor = Color.Transparent;
                panel.Controls.Add(cell);
            }

            // Расстановка самих, "игровых" ячеек.
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = 0;
                    Button cell = new Button();
                    cell.Location = new Point(1100 + i * (-cellSize) + 67, j * cellSize + 50);
                    cell.Size = new Size(cellSize, cellSize);
                    cell.BackColor = Color.Transparent;
                    cell.BackgroundImage = ResourceImages.Cell_for_SeaWars;
                    cell.BackgroundImageLayout = ImageLayout.Zoom;
                    cell.FlatAppearance.BorderSize = 0;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Click += new EventHandler(PlaceShip);
                    cell.MouseMove += new MouseEventHandler(Cell_mouseMove);
                    ButtonsCell[i, j] = cell;
                    ButtonsLocation.Add(cell.Location);
                    panel.Controls.Add(cell);
                }
            }
        }

        private void CreatePlayerMap()
        {
            // Расстановка нумерных ячеек.
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            for (int i = 1; i <= mapSize * 2; i++)
            {
                Button cell = new Button();
                if (i % 2 == 0)
                {
                    cell.Location = new Point((i - 1) * (cellSize / 2) + 45, 0);
                    cell.Text = (i / 2).ToString();
                }
                else
                {
                    cell.Location = new Point(15, (i - 1) * (cellSize / 2) + 56);
                    cell.Text = alphabet[i / 2].ToString();
                }
                cell.Size = new Size(cellSize - 10, cellSize - 10);
                cell.BackColor = Color.Transparent;
                cell.BackgroundImage = global::Pr29.ResourceImages.Cell_for_SeaWarsV2;
                cell.BackgroundImageLayout = ImageLayout.Zoom;
                cell.FlatAppearance.BorderSize = 0;
                cell.FlatStyle = FlatStyle.Flat;
                cell.FlatAppearance.MouseDownBackColor = Color.Transparent;
                cell.FlatAppearance.MouseOverBackColor = Color.Transparent;
                panel.Controls.Add(cell);
            }

            // Расстановка самих, "игровых" ячеек.
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = 0;
                    Button cell = new Button();
                    cell.Location = new Point(i * cellSize + 67, j * cellSize + 50);
                    cell.Size = new Size(cellSize, cellSize);
                    cell.BackColor = Color.Transparent;
                    cell.BackgroundImage = ResourceImages.Cell_for_SeaWars;
                    cell.BackgroundImageLayout = ImageLayout.Zoom;
                    cell.FlatAppearance.BorderSize = 0;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Click += new EventHandler(PlaceShip);
                    cell.MouseMove += new MouseEventHandler(Cell_mouseMove);
                    ButtonsCell[i, j] = cell;
                    ButtonsLocation.Add(cell.Location);
                    panel.Controls.Add(cell);
                }
            }
        }

        public void RestoreBackgroundImageField()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    ButtonsCell[i, j].BackgroundImage = ResourceImages.Cell_for_SeaWars;
                }
            }
        }

        /// <summary>
        /// Определяет состояное ячеек вокруг. Поворот определяется из свойства ShipRotation.
        /// </summary>
        /// <param name="cell">Начальная точка коробля.</param>
        /// <returns>Возвращяет true, если коробль можно расположить хотябы в одном направлении, в противном случае - false.</returns>
        public bool IsEmptyCellsAround(Point cell, int ShipSize)
        {
            bool isEmptyLeft = false;
            bool isEmptyRight = false;
            bool isEmptyTop = false;
            bool isEmptyBottom = false;

            GetIndexButton(cell, out int i, out int j);

            if (i + (ShipSize - 1) < 9 && ButtonsCell[i + 1, j].Enabled && ButtonsCell[i + (ShipSize - 1), j].Enabled)
                isEmptyLeft = true;

            if (i - (ShipSize - 1) > 0 && ButtonsCell[i - 1, j].Enabled && ButtonsCell[i - (ShipSize - 1), j].Enabled)
                isEmptyRight = true;

            if (j + (ShipSize - 1) < 9 && ButtonsCell[i, j + 1].Enabled && ButtonsCell[i, j + (ShipSize - 1)].Enabled)
                isEmptyTop = true;

            if (j - (ShipSize - 1) > 0 && ButtonsCell[i, j - 1].Enabled && ButtonsCell[i, j - (ShipSize - 1)].Enabled)
                isEmptyBottom = true;

            return isEmptyLeft || isEmptyRight || isEmptyTop || isEmptyBottom;
        }

        /// <summary>
        /// Определяет возможность размещения коробля на поле.
        /// </summary>
        /// <param name="startCellShipPlaced">Точка от которой считается начальное расположение коробля.</param>
        /// <returns>Возвращает true, если по направлению расположения коробля есть пустые ячейки, и он может их занять.</returns>
        public bool IsEmptyCellOnDerection(Point startCellShipPlaced, int ShipRotation, int ShipSize)
        {
            bool IsEmpty = false; // Флаг состояния ячеек.
            int CountCellForChecking = ShipSize - 1; // Колличество ячеек для проверки, не включая текущую.
            // Индекс первого измерения нажатой кнопки в массиве Buttons_cell.
            // Индекс второго измерения нажатой кнопки в массиве Buttons_cell.
            GetIndexButton(startCellShipPlaced, out int i, out int j);
            if (!ButtonsCell[i, j].Enabled)
                return false;

            //if (i + CountCellForChecking > 9 || j + CountCellForChecking > 9 || i - CountCellForChecking < 0 || j - CountCellForChecking < 0)
            //return false;
            if (CountCellForChecking > 0)
            {
                try
                {
                    switch (ShipRotation)
                    {
                        case 0:
                            if (ButtonsCell[i + CountCellForChecking, j].Enabled && ButtonsCell[i + 1, j].Enabled)
                                IsEmpty = true;
                            break;
                        case 90:
                            if (ButtonsCell[i, j + CountCellForChecking].Enabled && ButtonsCell[i, j + 1].Enabled)
                                IsEmpty = true;
                            break;
                        case 180:
                            if (ButtonsCell[i - CountCellForChecking, j].Enabled && ButtonsCell[i - 1, j].Enabled)
                                IsEmpty = true;
                            break;
                        case 270:
                            if (ButtonsCell[i, j - CountCellForChecking].Enabled && ButtonsCell[i, j - 1].Enabled)
                                IsEmpty = true;
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    IsLeaveField(startCellShipPlaced, ShipRotation, ShipSize);
                    IsEmpty = true;
                    // IsEmptyCellOnDerection(cell); Пока не знаю как точно обработать исключение.
                }

            }
            else
                IsEmpty = true;

            return IsEmpty;
        }

        /// <summary>
        /// Определяет выходит ли размещаемый корабля за границы поля.
        /// </summary>
        /// <param name="startCellShipPlaced">Точка от которой считается начальное расположение коробля.</param>
        /// <param name="ShipRotation"></param>
        /// <param name="ShipSize"></param>
        /// <returns>Значение true, если корабль выходит за границы поля.</returns>
        public bool IsLeaveField(Point startCellShipPlaced, int ShipRotation, int ShipSize)
        {
            bool isLeaveField = false;
            int CountCellForChecking = ShipSize - 1; // Колличество ячеек для проверки, не включая текущую.
            // Индекс первого измерения нажатой кнопки в массиве Buttons_cell.
            // Индекс второго измерения нажатой кнопки в массиве Buttons_cell.
            GetIndexButton(startCellShipPlaced, out int i, out int j);
            switch (ShipRotation)
            {
                case 0:
                    if (i + CountCellForChecking > 9)
                        isLeaveField = true;
                    break;
                case 90:
                    if (j + CountCellForChecking > 9)
                        isLeaveField = true;
                    break;
                case 180:
                    if (i - CountCellForChecking < 0)
                        isLeaveField = true;
                    break;
                case 270:
                    if (j - CountCellForChecking < 0)
                        isLeaveField = true;
                    break;
            }

            return isLeaveField;
        }

        /// <summary>
        /// Выбирает случаеное место, подходящие для размещение на нём коробля.
        /// </summary>
        /// <param name="ShipRotation"></param>
        /// <param name="ShipSize"></param>
        /// <returns>Новые координаты стартовой точки</returns>
        public Point SearchEmptyPoint(int ShipRotation, int ShipSize)
        {

            Point newPoint = ButtonsLocation.ElementAt(new Random().Next(0, ButtonsLocation.Count));

            while (!IsEmptyCellsAround(newPoint, ShipSize))
            {
                newPoint = ButtonsLocation.ElementAt(new Random().Next(0, ButtonsLocation.Count));
            }

            while (!IsEmptyCellOnDerection(newPoint, ShipRotation, ShipSize))
            {
                ShipRotation += 90;
            }

            return newPoint;
        }

        /// <summary>
        /// Находит опорные точки. Слева снизу и сверху справа, крайние точки занятой области коробля.
        /// </summary>
        /// <param name="currentPoint"></param>
        /// <param name="ShipRotation"></param>
        /// <param name="ShipSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void FindAnchorPoints(Point currentPoint, int ShipRotation, int ShipSize, out Point start, out Point end)
        {
            #region SearchStartPoint
            if (ShipRotation == 0 || ShipRotation == 90)
                start = new Point(currentPoint.X - cellSize, currentPoint.Y - cellSize);
            else if (ShipRotation == 180)
                start = new Point(currentPoint.X - ShipSize * cellSize, currentPoint.Y - cellSize);
            else
                start = new Point(currentPoint.X - cellSize, currentPoint.Y - ShipSize * cellSize);
            #endregion

            #region SearchEndPoint
            int offsetI = (2 + (ShipSize - 1)) * cellSize;
            int offsetJ = 2 * cellSize;

            if (ShipRotation == 90 || ShipRotation == 270)
            {
                int temp = offsetI;
                offsetI = offsetJ;
                offsetJ = temp;
            }

            end = new Point(start.X + offsetI, start.Y + offsetJ);
            #endregion
        }

        /// <summary>
        /// Заполняет опорные точки.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void FillAnchorPoints(Point start, Point end)
        {
            GetIndexButton(start, out int startIndexI, out int startIndexJ);
            GetIndexButton(end, out int endIndexI, out int endIndexJ);

            for (int i = startIndexI; i <= endIndexI; i++)
            {
                if (i > 9 || i < 0)
                    continue;
                for (int j = startIndexJ; j <= endIndexJ; j++)
                {
                    if (j > 9 || j < 0)
                        continue;
                    ButtonsCell[i, j].Enabled = false;
                    //playerMap[i, j] -= 1;
                    ButtonsCell[i, j].BackgroundImage = ResourceImages.Occupied_cell_for_SW;
                    ButtonsCell[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    ButtonsLocation.Remove(ButtonsCell[i, j].Location);
                }
            }

        }

        /// <summary>
        /// Находит идекс массива кнопок поля.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="indexI"></param>
        /// <param name="indexJ"></param>
        public void GetIndexButton(Point button, out int indexI, out int indexJ)
        {
            if (button.X > 500)
            {
                indexI = button.X / cellSize - 1 - 10;
                indexJ = button.Y / cellSize - 10;
            }

            indexI = button.X / cellSize - 1;
            indexJ = button.Y / cellSize;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr29
{   /// <summary>
    /// Представляет графическое и программное игровое поле для игры морской бой.
    /// Класс может представлять как поле игрока, так и бота.
    /// Содержит данные о ячейках и полях. Имеет методы обработки взаимодействия с полем и короблями.
    /// </summary>
    partial class BotSeaField
    {
        protected int mapSize;
        public int[,] Map { get; protected set; } // Двумерных массив, представляющий собой данные о расположении короблей.
        protected const int CELL_SIZE = 54;
        protected Control panel;
        public Button[,] ButtonsCell;
        protected List<Point> FreeButtonsLocation = new List<Point>(); 

        ListBox console;
        protected int LiveShipCount  // Возвращает колличество не подбитых кораблей.
        {
            get 
            {
                int counter = 0;
                foreach (PictureBoxExtender ship in Ships)
                    if (ship.Image != ResourceImages.Ship4_for_SeaWars || ship.Image != ResourceImages.Ship3_for_SeaWars ||
                        ship.Image != ResourceImages.Ship2_for_SeaWars || ship.Image != ResourceImages.Ship1_for_SeaWars)
                        // В дальнейшем надо заменить на спрайты взорваных короблей.
                        counter++;

                return counter;
            }
        }

        public Button this[int indexI,int indexJ]
        {
            get { return ButtonsCell[indexI, indexJ]; }
            private set { ButtonsCell[indexI, indexJ] = value; }
        }

        public void ChangeBackgroundImage(Point CellPoint, Bitmap Image)
        {
            GetIndexButton(CellPoint, out int indexI, out int indexJ);
            ButtonsCell[indexI, indexJ].BackgroundImage = Image;
        }

        public void ChangeBackgroundImage(Button Cell, Bitmap Image)
        {
            Cell.BackgroundImage = Image;
            i = 2;
        }

        public BotSeaField()
        {

        }

        /// <summary>
        /// Конструктор, инициализирующий объект - игровое поле бота.
        /// </summary>
        /// <param name="mapSize"></param>
        /// <param name="panel"></param>
        public BotSeaField(int mapSize, Control panel, ListBox console)
        {
            this.mapSize = mapSize;
            this.panel = panel;
            Map = new int[mapSize, mapSize];
            ButtonsCell = new Button[mapSize, mapSize];

            this.console = console;

            InitializeShips(this.panel, new Point(0, 75), 75);
        }

        public virtual void CreateMap()
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
                    cell.Location = new Point(612 + (i - 1) * (CELL_SIZE / 2) + 45, 0);
                    cell.Text = countCell.ToString();
                    countCell++;
                }
                else
                {
                    cell.Location = new Point(1212 + 15, (i - 1) * (CELL_SIZE / 2) + 56);
                    cell.Text = alphabet[i / 2].ToString();
                }
                cell.Size = new Size(CELL_SIZE - 10, CELL_SIZE - 10);
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
                    Map[i, j] = 0;
                    Button cell = new Button();
                    cell.Location = new Point(600 + i * CELL_SIZE + 67, j * CELL_SIZE + 50);
                    cell.Size = new Size(CELL_SIZE, CELL_SIZE);
                    cell.BackColor = Color.Transparent;
                    cell.BackgroundImage = ResourceImages.Cell_for_SeaWars;
                    cell.BackgroundImageLayout = ImageLayout.Zoom;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.FlatAppearance.BorderSize = 0;
                    cell.MouseEnter += new EventHandler(CheckInfoPos);
                    ButtonsCell[i, j] = cell;
                    FreeButtonsLocation.Add(cell.Location);
                    panel.Controls.Add(cell);
                }
            }
        }

        private void CheckInfoPos(object sender, EventArgs e)
        {
            Button cell = sender as Button;
            GetIndexButton(cell.Location, out int indexI, out int indexJ);

            console.Items.Clear();
            console.Items.Add($"{cell.Location.X};{cell.Location.Y}");
            console.Items.Add($"{indexI};{indexJ}");
        }

        public void AvtoPlaceShips()
        {
            for (int i = 0; i < Ships.Length; i++)
            {
                //System.Threading.Thread.Sleep(1000);
                int shipRotation = 0;
                int shipSize = Convert.ToInt32(Ships[i].Tag); 
                Ships[i].Location = SearchEmptyPoint(ref shipRotation, shipSize);

                FindAnchorPoints(Ships[i].Location, shipRotation, shipSize, out Point start, out Point end);
                FillAnchorPoints(start, end);

                Ships[i].Rotation = shipRotation;

                switch (shipRotation)
                {
                    case 0:
                        Ships[i].Location= new Point(Ships[i].Location.X, Ships[i].Location.Y + 7);
                        break;
                    case 90:
                        Ships[i].Location= new Point(Ships[i].Location.X + 7, Ships[i].Location.Y);
                        break;
                    case 180:
                        Ships[i].Location = new Point(Ships[i].Location.X - CELL_SIZE * (shipSize - 1), Ships[i].Location.Y + 7);
                        break;
                    default:
                        Ships[i].Location = new Point(Ships[i].Location.X + 7, Ships[i].Location.Y - CELL_SIZE * (shipSize - 1));
                        break;
                }

            }
        }

        /// <summary>
        /// Рапологает корабль на игровом поле, фиксируя занятые кораблём ячейки в отдельный массив int Map.
        /// </summary>
        /// <param name="ShipCount">Количество доступных короблей для расстановки.</param>
        /// <returns>Количество доступных короблей для расстановки, после раположения текущего.</returns>
        //public int PlaceShips(object sender, EventArgs e)
        //{
        //    Point locationPressedButton = (sender as Button).Location;
        //    if (ShipCount > 0)
        //    {
        //        ShipCount--;
        //        // PictureBox устанавливать тег кораблей и в цикле, учитывая поворот, заполнять поле.
        //        for (int i = 0; i < ShipSize; i++)
        //        {
        //            switch (ShipRotation)
        //            {
        //                case 0:
        //                    playerMap[((locationPressedButton.X / cellSize) - 1) + i, locationPressedButton.Y / cellSize] = 1;
        //                    break;
        //                case 90:
        //                    playerMap[(locationPressedButton.X / cellSize) - 1, (locationPressedButton.Y / cellSize) + i] = 1;
        //                    break;
        //                case 180:
        //                    playerMap[((locationPressedButton.X / cellSize) - 1) + (-i), locationPressedButton.Y / cellSize] = 1;
        //                    break;
        //                default:
        //                    playerMap[(locationPressedButton.Location.X / cellSize) - 1, (locationPressedButton.Location.Y / cellSize) + (-i)] = 1;
        //                    break;
        //            }
        //        }
        //        SelectedImg.Location = PictureBox_SelectedShip.Location;
        //        SelectedImg.Rotation = ShipRotation;
        //        SelectedImg = null;
        //        PictureBox_SelectedShip.Image = new Bitmap(1, 1);
        //        PictureBox_SelectedShip.A_RotationImage = new Bitmap(1, 1);
        //        // Есть идея. Вызывать эту функцию до расположения коробля.
        //        playerField.FindAnchorPoints(locationPressedButton, ShipRotation, ShipSize, out Point start, out Point end);
        //        playerField.FillAnchorPoints(start, end);
        //        //SelectedImg.Size = new Size(104, 39);
        //        //ship_four_cell.Location = new Point (pressedButton.Location.X, pressedButton.Location.Y+9);
        //        MessageBox.Show("Player Map" + (locationPressedButton.X / cellSize - 1) + ";" + locationPressedButton.Y / cellSize + "= 1");
        //        return ShipCount--;
        //    }
        //}

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
                    IsEmpty = false;
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
        public Point SearchEmptyPoint(ref int ShipRotation, int ShipSize)
        {

            Point newPoint = FreeButtonsLocation.ElementAt(new Random().Next(0, FreeButtonsLocation.Count));

            while (!IsEmptyCellsAround(newPoint, ShipSize))
            {
                newPoint = FreeButtonsLocation.ElementAt(new Random().Next(0, FreeButtonsLocation.Count));
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
                start = new Point(currentPoint.X - CELL_SIZE, currentPoint.Y - CELL_SIZE);
            else if (ShipRotation == 180)
                start = new Point(currentPoint.X - ShipSize * CELL_SIZE, currentPoint.Y - CELL_SIZE);
            else
                start = new Point(currentPoint.X - CELL_SIZE, currentPoint.Y - ShipSize * CELL_SIZE);
            #endregion

            #region SearchEndPoint
            int offsetI = (2 + (ShipSize - 1)) * CELL_SIZE;
            int offsetJ = 2 * CELL_SIZE;

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
                    FreeButtonsLocation.Remove(ButtonsCell[i, j].Location);
                }
            }

        }

        /// <summary>
        /// Находит идекс кнопки в массиве кнопок поля. Возвращает позицию кнопки в массиве.
        /// </summary>
        /// <param name="button">Позиция кнопки</param>
        /// <param name="indexI">Выходной параметр. Позиция кнопки в первом измерении.</param>
        /// <param name="indexJ">Выходной параметр. Позиция кнопки в второй измерении.</param>
        private void GetIndexButton(Point button, out int indexI, out int indexJ)
        {
            //if (!forPlayer) // Если поле принадлежит боту (расположено справо).
            //{
                //button.X = 1167 + 54 - button.X;
            //    button.X -= 613;
            //}

            indexI = button.X / CELL_SIZE - 1;
            indexJ = button.Y / CELL_SIZE;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr29
{
    public partial class SeaWarsForm : Form
    {
        private const int mapsize = 10;
        int cellSize = 54;
        int[,] playerMap = new int[mapsize, mapsize];
        List<Point> ButtonsLocation = new List<Point>();
        int[,] enemyMap = new int[mapsize, mapsize];
        int ShipSize = 1, ShipCount = 10;
        private int ShipRotation // Local rotation property of the selected ship.
        {
            get {  return (int)PictureBox_SelectedShip.Rotation;  }
            set {  PictureBox_SelectedShip.Rotation = value;  }
        }
        bool isPlaying = false;
        Button[,] ButtonsCell = new Button[mapsize, mapsize];
        PictureBoxExtender SelectedImg = new PictureBoxExtender();
        bool status;
        int CountRotation;
        Point cell;

        public SeaWarsForm()
        {
            InitializeComponent();
            CreatePlayerMap();
            KeyUp += new KeyEventHandler(KeyRotate);

            PictureBox PictureBox_AnyShip = new PictureBox
            {
                Size = PictureBox_SelectedShip.Size,
                BackColor = Color.Transparent,
                Location = new Point(0, 0),
                BackgroundImage = ResourceImages.Ship3_for_SeaWars,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            panel1.Controls.Add(PictureBox_AnyShip);

            //ship_two_cell3.Image = RotateImage(ship_two_cell3.Image, 270, true, false, Color.White);
            //pictureBoxExtender1.Image = RotateImage(pictureBoxExtender1.Image, 90, true, false, Color.Transparent);
        }

        private void KeyRotate(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                ShipRotation += 90;
                //ChageSelectedShipLocation(cell.X, cell.Y);
            }
            if (e.KeyCode == Keys.G)
            {
                label2.Text = ShipRotation.ToString();
                listBox1.Items.Add(Cursor.Position);
                //listBox1.Items.Clear();
                //for (int i = 0; i < mapsize; i++)
                //    for (int j = 0; j < mapsize; j++)
                //        listBox1.Items.Add($"[{i},{j}]:" + playerMap[i, j]);
            }
        }

        private void ChageSelectedShipLocation(int offsetX, int offsetY)
        {
            switch (ShipRotation)
            {  
                case 0: 
                     PictureBox_SelectedShip.Location = new Point(offsetX, offsetY + 7);
                    break;
                case 90:
                    PictureBox_SelectedShip.Location = new Point(offsetX + 7, offsetY);
                    break;
                case 180:
                    PictureBox_SelectedShip.Location = new Point(offsetX - cellSize * (ShipSize - 1), offsetY + 7);
                    break;
                default:
                    PictureBox_SelectedShip.Location = new Point(offsetX + 7, offsetY - cellSize * (ShipSize - 1));
                    break;
            }
        }

        private void SetSeclectedShip(object sender, EventArgs e)
        {
            SelectedImg = sender as PictureBoxExtender; // Перемещение PictureBox в переменную.
            SelectedImg.A_RotationImage = SelectedImg.Image;
            PictureBox_SelectedShip.Image = SelectedImg.Image;
            PictureBox_SelectedShip.A_RotationImage = SelectedImg.Image;
            // Для оптимизации можно попробовать сделать получение данных, как в методе PlaceShip.
            // Свойство Tag можно перевести в int в Designer.cs.
            ShipSize = Convert.ToInt32(sender.GetType().GetProperty("Tag").GetValue(sender));
        }

        private void PlaceShip(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (!isPlaying && ShipCount > 0)
            {
                ShipCount--;
                pressedButton.Enabled = false;
                // PictureBox устанавливать тег кораблей и в цикле, учитывая поворот, заполнять поле.
                for (int i = 0; i < ShipSize; i++)
                {
                    switch (ShipRotation)
                    {
                        case 0:
                            playerMap[((pressedButton.Location.X / cellSize) - 1) + i, pressedButton.Location.Y / cellSize] = 1;
                            break;
                        case 90:
                            playerMap[(pressedButton.Location.X / cellSize) - 1, (pressedButton.Location.Y / cellSize) + i] = 1;
                            break;
                        case 180:
                            playerMap[((pressedButton.Location.X / cellSize) - 1) + (-i), pressedButton.Location.Y / cellSize] = 1;
                            break;
                        default:
                            playerMap[(pressedButton.Location.X / cellSize) - 1, (pressedButton.Location.Y / cellSize) + (-i)] = 1;
                            break;
                    }
                }
                SelectedImg.Location = PictureBox_SelectedShip.Location;
                SelectedImg.Rotation = ShipRotation;
                SelectedImg = null;
                PictureBox_SelectedShip.Image = new Bitmap(1,1);
                PictureBox_SelectedShip.A_RotationImage = new Bitmap(1,1);
                // Есть идея. Вызывать эту функцию до расположения коробля.
                FindAnchorPoints(pressedButton.Location, out Point start, out Point end);
                FillAnchorPoints(start, end);
                //SelectedImg.Size = new Size(104, 39);
                //ship_four_cell.Location = new Point (pressedButton.Location.X, pressedButton.Location.Y+9);
                MessageBox.Show("Player Map" + (pressedButton.Location.X / cellSize - 1) + ";" + pressedButton.Location.Y / cellSize + "= 1");
            }
        }

        private void Cell_mouseMove(object sender, MouseEventArgs e)
        {
            cell = (Point)sender.GetType().GetProperty("Location").GetValue(sender);
            ChageSelectedShipLocation(cell.X, cell.Y);
            ProtectedLeavingField(cell);


            if (!IsEmptyCellsAround(cell))
            {
                Point newCell = SearchEmptyPoint();
                int newRotation = GetRandom(0,90,180,270);

                PictureBox_SelectedShip.Location = newCell;
                

                listBox1.Items.Add(newCell);
                listBox1.Items.Add(GetIndexButton(newCell, 0));
                listBox1.Items.Add(GetIndexButton(newCell, 1));

                Cursor.Position = PointToScreen(new Point(ButtonsCell[GetIndexButton(newCell,0),GetIndexButton(newCell,1)].Location.X + 7,
                                            ButtonsCell[GetIndexButton(newCell, 0), GetIndexButton(newCell, 1)].Location.Y + 7));

                listBox1.Items.Add("Позиция курсора" + Cursor.Position);
            }

            if (!IsEmptyCellOnDerection(cell)) // Упростить функцию на две, для лучший читабельности. 
                                                               // Проверка ячеек и защита от выхода за границы поля.
            {
                ShipRotation += 90;
            }
        }
        /// <summary>
        /// Определяет состояное ячеек вокруг. Поворот определяется из свойства ShipRotation.
        /// </summary>
        /// <param name="cell">Начальная точка коробля.</param>
        /// <returns>Возвращяет true, если коробль можно расположить хотябы в одном направлении, в противном случае - false.</returns>
        private bool IsEmptyCellsAround(Point cell)
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

        private Point SearchEmptyPoint()
        {

            Point newPoint = ButtonsLocation.ElementAt(new Random().Next(0, ButtonsLocation.Count));

            while (!IsEmptyCellsAround(newPoint))
            {
                newPoint = ButtonsLocation.ElementAt(new Random().Next(0, ButtonsLocation.Count));
            }

            while (!IsEmptyCellOnDerection(newPoint))
            {
                ShipRotation += 90;
            }

            return newPoint;
        }
        /// <summary>
        /// Возвращает случайное значение.
        /// </summary>
        /// <param name="arr">Массив случайных значений</param>
        /// <returns>Возвращает случайное целое число из указанного массива</returns>
        private int GetRandom(params int[] arr)
        {
            return arr[new Random().Next(arr.Length)];
        }

        private void FullNearCell(int i, int j)
        {
            if (playerMap[i - 1, j] == 0)
            {
                playerMap[i - 1, j] = 2;
                ButtonsCell[i - 1, j].Enabled = false;
            }
            if (playerMap[i, j - 1] == 0)
            {
                playerMap[i, j - 1] = 2;
                ButtonsCell[i, j - 1].Enabled = false;
            }
            if (playerMap[i, j + 1] == 0)
            {
                playerMap[i, j + 1] = 2;
                ButtonsCell[i, j + 1].Enabled = false;
            }
            if (playerMap[i + 1, j] == 0)
            {
                playerMap[i + 1, j] = 2;
                ButtonsCell[i + 1, j].Enabled = false;
            }
        }

        private void FindAnchorPoints(Point currentPoint, out Point start, out Point end)
        {
            #region SearchStartPoint
            if (ShipRotation == 0 || ShipRotation == 90)
                start = new Point(currentPoint.X - cellSize, currentPoint.Y - cellSize);
            else if (ShipRotation == 180)
                start = new Point(currentPoint.X - ShipSize * cellSize, currentPoint.Y - cellSize );
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

            end = new Point(start.X + offsetI,start.Y + offsetJ);
            #endregion
        }


        private void FillAnchorPoints(Point start, Point end)
        {

            int startIndexI = GetIndexButton(start, 0), starIdenxJ = GetIndexButton(start, 1);
            int endIndexI = GetIndexButton(end, 0), endIndexJ = GetIndexButton(end, 1);

            for (int i = startIndexI; i <= endIndexI; i++)
            {
                if (i > 9 || i < 0)
                    continue;
                for (int j = starIdenxJ; j <= endIndexJ; j++)
                {
                    if ( j > 9 || j < 0)
                        continue;
                    ButtonsCell[i, j].Enabled = false;
                    playerMap[i, j] -= 1;
                    ButtonsCell[i, j].BackgroundImage = ResourceImages.Occupied_cell_for_SW;
                    ButtonsCell[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    ButtonsLocation.Remove(ButtonsCell[i, j].Location);
                }
            }

        }
        /// <summary>
        /// Находит идекс массива кнопок поля.
        /// </summary>
        /// <param name="button">Позиция кнопки</param>
        /// <param name="demension">Индекс измерения</param>
        /// <returns>Возвращает индекс первого измерения, если входной параметр равен 0 и индекс второго измерения, если идекс равен 1.</returns>
        private int GetIndexButton (Point button, int demension)
        {
            int indexI = button.X / cellSize - 1;
            int indexJ = button.Y / cellSize;

            return (demension == 0) ? indexI  : indexJ;
        }

        private void GetIndexButton(Point button, out int indexI, out int indexJ)
        {
            indexI = button.X / cellSize - 1;
            indexJ = button.Y / cellSize;

        }
        /// <summary>
        /// Определяет возможность размещения коробля на поле.
        /// </summary>
        /// <param name="startCellShipPlaced">Точка от которой считается начальное расположение коробля.</param>
        /// <returns>Возвращает true, если по направлению расположения коробля есть пустые ячейки, и он может их занять.</returns>
        private bool IsEmptyCellOnDerection(Point startCellShipPlaced)
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
                    ProtectedLeavingField(cell);
                    IsEmpty = true;
                    // IsEmptyCellOnDerection(cell); Пока не знаю как точно обработать исключение.
                }
                
            }
            else
                IsEmpty = true;

            return IsEmpty;
        }
        /// <summary>
        /// Изменяет поворот коробля есть от вышел на границы поля.
        /// </summary>
        /// <param name="startCellShipPlaced">Точка от которой считается начальное расположение коробля.</param>
        private void ProtectedLeavingField(Point startCellShipPlaced)
        {
            int CountCellForChecking = ShipSize - 1; // Колличество ячеек для проверки, не включая текущую.
            // Индекс первого измерения нажатой кнопки в массиве Buttons_cell.
            // Индекс второго измерения нажатой кнопки в массиве Buttons_cell.
            GetIndexButton(startCellShipPlaced, out int i, out int j);
            switch (ShipRotation)
            {
                case 0:
                    if (i + CountCellForChecking > 9)
                        ShipRotation += 90;
                    break;
                case 90:
                    if (j + CountCellForChecking > 9)
                        ShipRotation += 90;
                    break;
                case 180:
                    if (i - CountCellForChecking < 0)
                        ShipRotation += 90;
                    break;
                case 270:
                    if (j - CountCellForChecking < 0)
                        ShipRotation += 90;
                    break;
            }
        }

        private void ship_four_cell_MouseMove(object sender, MouseEventArgs e)
        {
            //if (status)
            //ship_four_cell.Location = new Point((Cursor.Position.X - this.Location.X), (Cursor.Position.Y - this.Location.Y));
        }

        private void ship_four_cell_MouseUp(object sender, MouseEventArgs e)
        {
            status = false;
        }

        private void ship_four_cell_MouseDown(object sender, MouseEventArgs e)
        {
            status = true;
        }
    }

}

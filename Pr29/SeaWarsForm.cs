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

        SeaField playerField;

        public SeaWarsForm()
        {
            InitializeComponent();
            //CreatePlayerMap();
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

            playerField = new SeaField(10, panel1, PlaceShip, Cell_mouseMove);
            //playerField.CreateMap();
            playerField.CreateEnemyMap();

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
                playerField.FindAnchorPoints(pressedButton.Location,ShipRotation, ShipSize, out Point start, out Point end);
                playerField.FillAnchorPoints(start, end);
                //SelectedImg.Size = new Size(104, 39);
                //ship_four_cell.Location = new Point (pressedButton.Location.X, pressedButton.Location.Y+9);
                MessageBox.Show("Player Map" + (pressedButton.Location.X / cellSize - 1) + ";" + pressedButton.Location.Y / cellSize + "= 1");
            }
        }

        private void Cell_mouseMove(object sender, MouseEventArgs e)
        {
            cell = (Point)sender.GetType().GetProperty("Location").GetValue(sender);
            ChageSelectedShipLocation(cell.X, cell.Y);

            if(playerField.IsLeaveField(cell, ShipRotation, ShipSize))
                ShipRotation += 90;

            if (!playerField.IsEmptyCellsAround(cell,ShipSize))
            {
                Point newCell = playerField.SearchEmptyPoint(ShipRotation, ShipSize);
                int newRotation = GetRandom(0,90,180,270);

                PictureBox_SelectedShip.Location = newCell;
                

                listBox1.Items.Add(newCell);
                listBox1.Items.Add(GetIndexButton(newCell, 0));
                listBox1.Items.Add(GetIndexButton(newCell, 1));

                Cursor.Position = PointToScreen(newCell);

                listBox1.Items.Add("Позиция курсора" + Cursor.Position);
            }

            if (!playerField.IsEmptyCellOnDerection(cell, ShipRotation, ShipSize)) // Упростить функцию на две, для лучший читабельности. 
                                                               // Проверка ячеек и защита от выхода за границы поля.
            {
                ShipRotation += 90;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (ShipCount > 0)
            {
                MessageBox.Show("Поставте все корабли", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Начать игру?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    #region delete tutorial buttons
                    panel1.Controls.Remove(button_freeCell);
                    panel1.Controls.Remove(button_occupiedCell);
                    panel1.Controls.Remove(button_missedCell);
                    panel1.Controls.Remove(button_hitCell);
                    panel1.Controls.Remove(label_freeCell);
                    panel1.Controls.Remove(label_occupiedCell);
                    panel1.Controls.Remove(label_missedCell);
                    panel1.Controls.Remove(label_hitCell);
                    button_freeCell.Dispose();
                    button_occupiedCell.Dispose();
                    button_missedCell.Dispose();
                    button_hitCell.Dispose();
                    label_freeCell.Dispose();
                    label_occupiedCell.Dispose();
                    label_missedCell.Dispose();
                    label_hitCell.Dispose();
                    #endregion

                    #region restore background image cell
                    playerField.RestoreBackgroundImageField();
                    #endregion

                    #region initialization bot

                    #endregion
                }
            }
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

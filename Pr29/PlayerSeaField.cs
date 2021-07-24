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
    class PlayerSeaField : BotSeaField
    {
        private PictureBoxExtender PictureBox_SelectedShip;
        PictureBoxExtender SelectedImg;
        Point cell;
        private int ShipSize;
        private int ShipCount = 10; // Количество не раставленных кораблей.
        private int ShipRotation // Local rotation property of the selected ship.
        {
            get { return (int)PictureBox_SelectedShip.Rotation; }
            set { PictureBox_SelectedShip.Rotation = value; }
        }

        public override void CreateMap()
        {
            // Расстановка нумерных ячеек.
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К' };
            for (int i = 1; i <= mapSize * 2; i++)
            {
                Button cell = new Button();
                if (i % 2 == 0)
                {
                    cell.Location = new Point((i - 1) * (CELL_SIZE / 2) + 45, 0);
                    cell.Text = (i / 2).ToString();
                }
                else
                {
                    cell.Location = new Point(15, (i - 1) * (CELL_SIZE / 2) + 56);
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
                    cell.Location = new Point(i * CELL_SIZE + 67, j * CELL_SIZE + 50);
                    cell.Size = new Size(CELL_SIZE, CELL_SIZE);
                    cell.BackColor = Color.Transparent;
                    cell.BackgroundImage = ResourceImages.Cell_for_SeaWars;
                    cell.BackgroundImageLayout = ImageLayout.Zoom;
                    cell.FlatAppearance.BorderSize = 0;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Click += new EventHandler(PlaceShip);
                    cell.MouseMove += new MouseEventHandler(Cell_mouseMove);
                    ButtonsCell[i, j] = cell;
                    FreeButtonsLocation.Add(cell.Location);
                    panel.Controls.Add(cell);
                }
            }
        }

        protected override void InitializeShips(Control panel, Point locationFirstShip, int INDENT_BETWEEN_SHIPS)
        {
            base.InitializeShips(panel, locationFirstShip, INDENT_BETWEEN_SHIPS);

            for (int i = 0; i < Ships.Length; i++)
                Ships[i].Click += new System.EventHandler(SetSelectedShip);
        }

        /// <summary>
        /// Конструктор, инициализирующий объект - игровое поле игрока.
        /// </summary>
        /// <param name="mapSize"> Размер игрового поля. </param>
        /// <param name="panel"> Контрол поля на форме. </param>
        /// <param name="Ships_panel"> Контрол для выгрузки PictureBox_Extender с короблями на форму. </param>
        /// <param name="PlaceShip"> Событие при нажатие на коробль. </param>
        /// <param name="Cell_mouseMove"> Событие при навидение на ячейку поля. </param>
        public PlayerSeaField(int mapSize, Control panel, Control Ships_panel, PictureBoxExtender PictureBox_SelectedShip)
        {
            this.mapSize = mapSize;
            this.panel = panel;
            Map = new int[mapSize, mapSize];
            ButtonsCell = new Button[mapSize, mapSize];

            this.PictureBox_SelectedShip = PictureBox_SelectedShip;

            InitializeShips(Ships_panel, new Point(0, 75), 75);

        }

        void SetSelectedShip(object sender, EventArgs e)
        {
            SelectedImg = sender as PictureBoxExtender; // Перемещение ссылки на PictureBox в переменную.
            SelectedImg.A_RotationImage = SelectedImg.Image;
            PictureBox_SelectedShip.Image = SelectedImg.Image;
            PictureBox_SelectedShip.A_RotationImage = SelectedImg.Image;
            // Для оптимизации можно попробовать сделать получение данных, как в методе PlaceShip.
            // Свойство Tag можно перевести в int в Designer.cs.
            ShipSize = Convert.ToInt32(sender.GetType().GetProperty("Tag").GetValue(sender));
        }

        public void PlaceShip(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (ShipCount > 0)
            {
                ShipCount--;
                pressedButton.Enabled = false;
                // PictureBox устанавливать тег кораблей и в цикле, учитывая поворот, заполнять поле.
                for (int i = 0; i < ShipSize; i++)
                {
                    switch (ShipRotation)
                    {
                        case 0:
                            Map[((pressedButton.Location.X / CELL_SIZE) - 1) + i, pressedButton.Location.Y / CELL_SIZE] = 1;
                            break;
                        case 90:
                            Map[(pressedButton.Location.X / CELL_SIZE) - 1, (pressedButton.Location.Y / CELL_SIZE) + i] = 1;
                            break;
                        case 180:
                            Map[((pressedButton.Location.X / CELL_SIZE) - 1) + (-i), pressedButton.Location.Y / CELL_SIZE] = 1;
                            break;
                        default:
                            Map[(pressedButton.Location.X / CELL_SIZE) - 1, (pressedButton.Location.Y / CELL_SIZE) + (-i)] = 1;
                            break;
                    }
                }
                SelectedImg.Location = PictureBox_SelectedShip.Location;
                SelectedImg.Rotation = ShipRotation;
                SelectedImg = null;
                PictureBox_SelectedShip.Image = new Bitmap(1, 1);
                PictureBox_SelectedShip.A_RotationImage = new Bitmap(1, 1);
                // Есть идея. Вызывать эту функцию до расположения коробля.
                FindAnchorPoints(pressedButton.Location, ShipRotation, ShipSize, out Point start, out Point end);
                FillAnchorPoints(start, end);
                //SelectedImg.Size = new Size(104, 39);
                //ship_four_cell.Location = new Point (pressedButton.Location.X, pressedButton.Location.Y+9);
                MessageBox.Show("Player Map" + (pressedButton.Location.X / CELL_SIZE - 1) + ";" + pressedButton.Location.Y / CELL_SIZE + "= 1");
            }
        }

        public void RestoreBackgroundImageField()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    ButtonsCell[i, j].BackgroundImage = ResourceImages.Cell_for_SeaWars;
                    ButtonsCell[i, j].Click -= new EventHandler(PlaceShip);
                    ButtonsCell[i, j].MouseMove -= new MouseEventHandler(Cell_mouseMove);
                }
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
                    PictureBox_SelectedShip.Location = new Point(offsetX - CELL_SIZE * (ShipSize - 1), offsetY + 7);
                    break;
                default:
                    PictureBox_SelectedShip.Location = new Point(offsetX + 7, offsetY - CELL_SIZE * (ShipSize - 1));
                    break;
            }
        }

        private void Cell_mouseMove(object sender, MouseEventArgs e)
        {
            cell = (Point)sender.GetType().GetProperty("Location").GetValue(sender);
            ChageSelectedShipLocation(cell.X, cell.Y);

            if (IsLeaveField(cell, ShipRotation, ShipSize))
                ShipRotation += 90;

            if (!IsEmptyCellsAround(cell, ShipSize))
            {
                int rotation = ShipRotation;
                Point newCell = SearchEmptyPoint(ref rotation, ShipSize);
                ShipRotation = rotation;

                PictureBox_SelectedShip.Location = newCell;


                //listBox1.Items.Add(newCell);
                //listBox1.Items.Add(GetIndexButton(newCell, 0)); // ListBox1 выполняет роль консоли.
                //listBox1.Items.Add(GetIndexButton(newCell, 1));

                Cursor.Position = panel.PointToScreen(newCell);

                //listBox1.Items.Add("Позиция курсора" + Cursor.Position);
            }

            if (!IsEmptyCellOnDerection(cell, ShipRotation, ShipSize)) // Упростить функцию на две, для лучший читабельности. 
                                                                                   // Проверка ячеек и защита от выхода за границы поля.
            {
                ShipRotation += 90;
            }
        }
    }
}

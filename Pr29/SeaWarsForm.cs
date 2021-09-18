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
        int ShipSize = 2, ShipCount = 10;
        private int ShipRotation // Local rotation property of the selected ship.
        {
            get {  return (int)PictureBox_SelectedShip.Rotation;  }
            set {  PictureBox_SelectedShip.Rotation = value;  }
        }
        bool isPlaying = false;
        Button[,] ButtonsCell = new Button[mapsize, mapsize];
        PictureBoxExtender SelectedImg = new PictureBoxExtender();
        PictureBoxExtender[] Ships = new PictureBoxExtender[10];
        bool status;
        int CountRotation;
        Point cell;

        Player Player;
        Bot Bot;

        public SeaWarsForm()
        {
            InitializeComponent();
            Bot = new Bot(MainPanel, listBox1, Difficult.normal);

            KeyUp += new KeyEventHandler(KeyRotate);

            PictureBox PictureBox_AnyShip = new PictureBox
            {
                Size = PictureBox_SelectedShip.Size,
                BackColor = Color.Transparent,
                Location = new Point(0, 0),
                BackgroundImage = ResourceImages.Ship3_for_SeaWars,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            MainPanel.Controls.Add(PictureBox_AnyShip);

            Player = new Player(PlayerField_panel, PlayerShips_panel, SelectedImg, Bot);

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

        private void button_start_Click(object sender, EventArgs e)
        {
            if (ShipCount < 0)
            {
                MessageBox.Show("Поставте все корабли", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Начать игру?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    #region delete tutorial buttons
                    MainPanel.Controls.Remove(PlayerShips_panel);
                    MainPanel.Controls.Remove(button_freeCell);
                    MainPanel.Controls.Remove(button_occupiedCell);
                    MainPanel.Controls.Remove(button_missedCell);
                    MainPanel.Controls.Remove(button_hitCell);
                    MainPanel.Controls.Remove(label_freeCell);
                    MainPanel.Controls.Remove(label_occupiedCell);
                    MainPanel.Controls.Remove(label_missedCell);
                    MainPanel.Controls.Remove(label_hitCell);
                    MainPanel.Controls.Remove(label_title);
                    MainPanel.Controls.Remove(button_start);
                    MainPanel.Controls.Remove(button_restartField);
                    MainPanel.Controls.Remove(button_avtoGenerate);
                    PlayerShips_panel.Dispose();
                    button_freeCell.Dispose();
                    button_occupiedCell.Dispose();
                    button_missedCell.Dispose();
                    button_hitCell.Dispose();
                    label_freeCell.Dispose();
                    label_occupiedCell.Dispose();
                    label_missedCell.Dispose();
                    label_hitCell.Dispose();
                    label_title.Dispose();
                    button_start.Dispose();
                    button_restartField.Dispose();
                    button_avtoGenerate.Dispose();
                    #endregion

                    #region restore background image cell
                    Player.RestoreBackgroundCells();
                    #endregion

                    #region initialization bot
                    //PictureBoxExtender[] botShips = new PictureBoxExtender[Ships.Length];
                    //for (int i = 0; i < Ships.Length; i++)
                    //{
                    //    botShips[i] = (PictureBoxExtender)Ships[i].Clone();
                    //    panel1.Controls.Add(botShips[i]);
                    //}
                    Bot.Initialize(Player);
                    Bot.Shot();
                    //playerField[0,0];
                    #endregion
                }
            }
        }

        private void button_restartField_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button_avtoGenerate_Click(object sender, EventArgs e)
        {
            Player.AvtoPlaceShips();
            ShipCount = 0;
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

    }

}

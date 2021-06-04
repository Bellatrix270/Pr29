using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr29
{
    public partial class SelectGameForm : Form
    {
        private string[] GameNames = {"Крестики нолики", "Морской бой", "Пятнашки"};
        private int currentGameName = 0;
        private Image[] backgroundImages =
            {
                ResourceImages.Background_For_WFV2,
                ResourceImages.Background2_1_For_WF,
                ResourceImages.Background3_For_WF
            };

        private int CurrentGameName
        {
            get { return currentGameName; }
            set 
            {
                if (value > GameNames.Length - 1)
                    currentGameName = GameNames.Length - 1;
                else if (value < 0)
                    currentGameName = 0;
                else
                    currentGameName = value;
            }
        }
        public SelectGameForm()
        {
            InitializeComponent();
        }

        private void label_arrow_right_Click(object sender, EventArgs e)
        {
            CurrentGameName++;
            BackgroundImage = backgroundImages[CurrentGameName];
            label_gameName.Text = GameNames[CurrentGameName];
        }

        private void label_arrow_left_Click(object sender, EventArgs e)
        {
            CurrentGameName--;
            label_gameName.Text = GameNames[CurrentGameName];
            BackgroundImage = backgroundImages[CurrentGameName];
        }

        private void label_arrow_right_MouseMove(object sender, MouseEventArgs e)
        {
            label_arrow_right.ForeColor = Color.White;
        }

        private void label_arrow_right_MouseLeave(object sender, EventArgs e)
        {
            label_arrow_right.ForeColor = Color.LightGray;
        }

        private void label_arrow_left_MouseMove(object sender, MouseEventArgs e)
        {
            label_arrow_left.ForeColor = Color.White;
        }

        private void label_arrow_left_MouseLeave(object sender, EventArgs e)
        {
            label_arrow_left.ForeColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new CrossAndZero()).Show();
            this.Hide();
        }
    }
}

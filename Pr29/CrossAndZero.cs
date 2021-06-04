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
    public partial class CrossAndZero : Form
    {
        int turnPlayer = 1, score_cross, score_circle;
        string message_win;

        FieldStates[,] fields = new FieldStates [3, 3]
        {
            {FieldStates.Emmpty, FieldStates.Emmpty, FieldStates.Emmpty},
            {FieldStates.Emmpty, FieldStates.Emmpty, FieldStates.Emmpty},
            {FieldStates.Emmpty, FieldStates.Emmpty, FieldStates.Emmpty}
        };

        Button[,] btnOnField;

        public CrossAndZero()
        {
            InitializeComponent();

            btnOnField = new Button[3, 3]
            {
                {Field_button1, Field_button2, Field_button3},
                {Field_button4, Field_button5, Field_button6},
                {Field_button7, Field_button8, Field_button9}
            };

            foreach (Button btn in btnOnField)
                btn.Tag = 0;

        }

        private void Field_buttons_Click(object sender, EventArgs e)
        {

            if (turnPlayer == 1)
            {
                sender.GetType().GetProperty("BackgroundImage").SetValue(sender, ResourceImages.Cross);
                sender.GetType().GetProperty("Tag").SetValue(sender, (int)FieldStates.Cross);
                turnPlayer = 2;
                label_current_turn.Text = "Текущий ход:\nИгрок 1";
            }
            else
            {
                sender.GetType().GetProperty("BackgroundImage").SetValue(sender, ResourceImages.Circle);
                sender.GetType().GetProperty("Tag").SetValue(sender, (int)FieldStates.Circle);
                turnPlayer = 1;
                label_current_turn.Text = "Текущий ход:\nИгрок 2";
            }

            sender.GetType().GetProperty("Enabled").SetValue(sender, false);

            getCurrentIndex();

            if (isWin() || HasEmptyField())
            {
                if (MessageBox.Show (
                    message_win + "\nСыграть ещё раз?\n \"Нет\" - выход в главное меню",
                    "Итоги игры", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    RestartGame();
                }
                else
                {
                    new SelectGameForm().Show();
                    Hide();
                }
            }

        }

        private bool HasEmptyField()
        {
            foreach (Button btn in btnOnField)
            {
                if (btn.BackgroundImage == null)
                {
                    return false;
                }

            }

            message_win = "Ничья";
            return true;
        }

        private bool isWin()
        {
            //int countRepeats = 1;

            for (int i = 0; i < 3; i++) // Check line
            {
                
                if (fields[i,0] == fields[i,1] && fields[i,0] == fields[i, 2] && fields[i,0] != FieldStates.Emmpty)
                {
                    AddScore(fields[i, 0]);
                    return true;
                }

                if (fields[0, i] == fields[1, i] && fields[0, i] == fields[2, i] && fields[0, i] != FieldStates.Emmpty)
                {
                    AddScore(fields[0, i]);
                    return true;
                }

            }

            if (fields[0, 0] == fields[1, 1] && fields[0, 0] == fields[2, 2] && fields[0, 0] != FieldStates.Emmpty)
            {
                AddScore(fields[0, 0]);
                return true;
            }

            if (fields[0, 2] == fields[1, 1] && fields[0, 2] == fields[2, 0] && fields[0, 2] != FieldStates.Emmpty)
            {
                AddScore(fields[0, 2]);
                return true;
            }

            //if ( k < 1 && field[k,m] == field[k+1,m] )
            //{
            //    countRepeats++;
            //    if (k == 0 && field[k + 1, m] == field[k + 2, m])
            //    {
            //        countRepeats++;
            //    }
            //}

            return false;
        }

        private void getCurrentIndex ()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Convert.ToInt32(btnOnField[i, j].Tag) == (int)FieldStates.Cross)
                    {
                        btnOnField[i, j].Tag = 0;
                        fields[i, j] = FieldStates.Cross;
                    }
                    else if (Convert.ToInt32(btnOnField[i, j].Tag) == (int)FieldStates.Circle)
                    {
                        btnOnField[i, j].Tag = 0;
                        fields[i, j] = FieldStates.Circle;
                    }

                }
            }

        }

        private void RestartGame ()
        {
            foreach (Button btn in btnOnField)
            {
                btn.BackgroundImage = null;
                btn.Enabled = true;
            }

            for (int i = 0; i < fields.GetLength(0); i++)
                for (int j = 0; j < fields.GetLength(1); j++)
                    fields[i, j] = FieldStates.Emmpty;

            turnPlayer = 1;
            label_current_turn.Text = "Текущий ход:\nИгрок 1";
        }

        private void AddScore(FieldStates field)
        {
            if (field == FieldStates.Cross)
            {
                score_cross++;
                message_win = "Победил игрок 1";
            }
            else
            {
                score_circle++;
                message_win = "Победил игрок 2";
            }

            label_score.Text = $"Счёт {score_cross}:{score_circle}";
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

    }



    enum FieldStates
    {
        Emmpty,
        Cross,
        Circle
    }
}

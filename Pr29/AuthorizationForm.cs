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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void EnterButton_MouseEnter(object sender, EventArgs e)
        {
            EnterButton.BackColor = Color.LavenderBlush;
            EnterButton.BackColorAdditional = Color.Lavender;
            EnterButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            EnterButton.BorderColor = System.Drawing.SystemColors.WindowFrame;
        }

        private void EnterButton_MouseLeave(object sender, EventArgs e)
        {
            EnterButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            EnterButton.BackColorAdditional = System.Drawing.SystemColors.WindowFrame;
            EnterButton.ForeColor = Color.LavenderBlush;
            EnterButton.BorderColor = Color.LavenderBlush;
        }

        private void labelReg_MouseEnter(object sender, EventArgs e)
        {
            labelReg.ForeColor = Color.WhiteSmoke;
        }

        private void labelReg_MouseLeave(object sender, EventArgs e)
        {
            labelReg.ForeColor = Color.Silver;
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Test@mail.ru...")
                textBoxEmail.Clear();
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if(textBoxEmail.TextLength == 0)
                textBoxEmail.Text = "Test@mail.ru...";
        }

        private void checkBoxShowPass_Click(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Focus();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            MySqlConnector.MySqlConnection ConnectionDB =
                new MySqlConnector.MySqlConnection(
                    System.Configuration.ConfigurationManager.ConnectionStrings["HOST_DB_connection_string"].ConnectionString);
             ConnectionDB.Open();
        }
    }
}

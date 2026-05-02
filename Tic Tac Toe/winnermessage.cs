using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class winner : Form
    {
        public winner(TicTacToe ParentForm, string WinnerName = "")
        {
            InitializeComponent();
            FormLayout(ParentForm);
            ThemeSetting(ParentForm, WinnerName);

        }
        private void FormLayout(TicTacToe parentForm)
        {
            this.Size = parentForm.Size;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ThemeSetting(TicTacToe form, string WinnerName="")
        {
            if (WinnerName == "")
            {
                label1.Text = "";
                this.BackgroundImage = form.draw;

            }
            else
            {
                label1.Text = WinnerName + " is the Champion!";
                this.BackgroundImage = form.winner;
            }
            label1.ForeColor = Color.White;
            label1.UseCompatibleTextRendering = true;
            label1.Font = form.button3.Font;
            label1.TextAlign = ContentAlignment.MiddleCenter;

            button1.UseCompatibleTextRendering = true;
            button1.BackColor = form.button3.BackColor;
            button1.ForeColor = form.button3.ForeColor;
            button1.Font = form.button3.Font;
        }
        private void winnermessage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

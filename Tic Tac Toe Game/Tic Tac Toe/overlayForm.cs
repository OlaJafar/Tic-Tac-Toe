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
    public partial class overlayForm : Form
    {
        TicTacToe mainform;
        public overlayForm(TicTacToe parent)
        {
            InitializeComponent();
            mainform = parent;
        }

        private void overlayForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform.button1.Visible = true;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainform.button1.Visible = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Mute") button5.Text = "Unmute";
            else button5.Text = "Mute";
        }
    }
}

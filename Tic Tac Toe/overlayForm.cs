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
            init(parent);
        }
        private void init(TicTacToe parent)
        {
            mainform = parent;
            button7.UseCompatibleTextRendering = true;
            button7.Font = new Font(mainform.pfc.Families[0], 6, FontStyle.Regular);
            if (!mainform.isMuted) button5.Text = "Mute";
            else button5.Text = "UnMute";
        }
        private void PlaySound(bool visible=false)
        {
            if (!mainform.isMuted) mainform.clickSound.Play();
            panel1.Visible = visible;
        }

        private void overlayForm_Load(object sender, EventArgs e)
        {

        }
        //Resume Button
        private void button1_Click(object sender, EventArgs e)
        {
            PlaySound();
            mainform.button1.Visible = true;
            this.Close();
        }
        //Cancel Button
        private void button2_Click(object sender, EventArgs e)
        {
            PlaySound();
            mainform.button1.Visible = true;
            this.Close();
        }
        //Mute Button
        private void button5_Click(object sender, EventArgs e)
        {
            PlaySound();
            if (mainform.isMuted) button5.Text = "Mute";
            else button5.Text = "UnMute";
            mainform.isMuted = !mainform.isMuted;
        }
        //Themes Buttons
        private void button6_Click(object sender, EventArgs e)
        {
            PlaySound(!panel1.Visible);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PlaySound();
            mainform.currentTheme.PixelArt(mainform);
            mainform.button1.Visible = true;
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PlaySound();
            mainform.currentTheme.Citadel(mainform);
            mainform.button1.Visible = true;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PlaySound();
            mainform.currentTheme.DarkMode(mainform);
            mainform.button1.Visible = true;
            this.Close();
        }
        //History Button
        private void button3_Click(object sender, EventArgs e)
        {

            PlaySound();
            WindowsFormsApp1.Form1 historyWindow = new WindowsFormsApp1.Form1();

            historyWindow.lblHistory2.Text = string.Join(Environment.NewLine, mainform.gameHistory);
            historyWindow.Size = mainform.Size;
            historyWindow.StartPosition = FormStartPosition.CenterParent;
            historyWindow.Text = "History";
            historyWindow.ShowDialog();
        }

        //Exit Button
        private void button4_Click(object sender, EventArgs e)
        {
            PlaySound();
            Application.Exit();
        }
    }
}

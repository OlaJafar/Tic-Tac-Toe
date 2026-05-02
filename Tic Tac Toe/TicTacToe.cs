using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Media;
using System.IO;

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        public PrivateFontCollection pfc = new PrivateFontCollection();
        public Piece[,] board = new Piece[3, 3];
        int xScore = 0, oScore = 0, role = 0;
        public themes currentTheme = new themes();
        public Color Colorx = new Color(), Coloro = new Color(), cellColor = new Color();
        public Image Imagex = null, Imageo = null, bg = null, winner = null,draw=null;
        public String Textx = "", Texto = "";
        public bool isMuted = false, doubleCheck = false;
        public List<string> gameHistory = new List<string>();
        public int roundCounter = 1;
        string winnerName="";
        public SoundPlayer clickSound,winSound,errorSound,xSound,oSound,startSound;

        public TicTacToe()
        {
            InitializeComponent();
            InitCustomFont();
            intial();
            currentTheme.PixelArt(this);
            drawScore();

            
        }

        public void PlayGeneralClick()
        {
            if(!isMuted)
                clickSound.Play();
        }

        private void InitCustomFont()
        {
            byte[] fontData = Properties.Resources.pixelArtFont;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            pfc.AddMemoryFont(fontPtr, fontData.Length);
        }

        private void intial()
        {
            int boardSize = 300;
            int startX = (this.ClientSize.Width - boardSize) / 2;
            int startY = 20;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Piece(startX + (j * 100), startY + (i * 100));
                    board[i, j].Click += play;
                    board[i, j].Cursor = Cursors.Hand;
                    board[i, j].UseCompatibleTextRendering = true;
                    Controls.Add(board[i, j]);
                }
            }
            button3.UseCompatibleTextRendering = true;
            button4.UseCompatibleTextRendering = true;
            clickSound = new SoundPlayer(Properties.Resources.click);
            winSound = new SoundPlayer(Properties.Resources.victory);
            errorSound = new SoundPlayer(Properties.Resources.error);
            xSound = new SoundPlayer(Properties.Resources.x__1_);
            oSound = new SoundPlayer(Properties.Resources.o1);
            startSound = new SoundPlayer(Properties.Resources.start);
        }

        public void drawScore()
        {
            void SetLabel(Label lbl, string text, Color foreColor, float fontSize, Image bgImage = null)
            {
                lbl.Text = text;
                lbl.ForeColor = foreColor;
                lbl.Font = new Font(pfc.Families[0], fontSize, FontStyle.Bold);
                lbl.BackgroundImage = bgImage;
                lbl.BackgroundImageLayout = ImageLayout.Stretch;
                lbl.UseCompatibleTextRendering = true;
            }
            panel2.BackColor = panel3.BackColor = cellColor;
            SetLabel(label1, Textx, Colorx, 25, Imagex);
            SetLabel(label2, "Player 1:", Color.Black, 10);
            SetLabel(label3, xScore.ToString(), Color.Black, 27);
            SetLabel(label6, Texto, Coloro, 25, Imageo);
            SetLabel(label5, "Player 2:", Color.Black, 10);
            SetLabel(label4, oScore.ToString(), Color.Black, 27);
        }

        private void play(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int boardSize = 300;
            int startX = (this.ClientSize.Width - boardSize) / 2;
            int startY = 20;
            int i = (btn.Top - startY) / 100;
            int j = (btn.Left - startX) / 100;

            if (board[i, j].state == States.F)
            {
                board[i, j].Font = new Font(pfc.Families[0], 40, FontStyle.Regular);
                if (role % 2 == 0)
                {
                    if(!isMuted)
                        xSound.Play();
                    board[i, j].ForeColor = Colorx;
                    board[i, j].BackgroundImage = Imagex;
                    board[i, j].Text = Textx;
                    board[i, j].state = States.X;
                    panel4.BackColor = Color.White;
                    panel1.BackColor = Color.Transparent;
                }
                else
                {
                    if(!isMuted)
                        oSound.Play();
                    board[i, j].ForeColor = Coloro;
                    board[i, j].BackgroundImage = Imageo;
                    board[i, j].Text = Texto;
                    board[i, j].state = States.O;
                    panel1.BackColor = Color.White;
                    panel4.BackColor = Color.Transparent;
                }

                role += 1;
                checkWinner();

                if (role == 9)
                {
                    if (winnerName == "")
                    {
                        gameHistory.Add($"Round {roundCounter}: DRAW!");
                        roundCounter++;
                    }
                    panel1.BackColor = Color.White;
                    panel4.BackColor = Color.Transparent;
                    winner winForm = new winner(this, "");
                    winForm.StartPosition = FormStartPosition.CenterParent;
                    winForm.ShowDialog();
                    reset();
                }
            }
            else
            {
                if(!isMuted)
                    errorSound.Play();
                async void illegal()
                {
                    board[i, j].BackColor = Color.Red;
                    await Task.Delay(1000);
                    board[i, j].BackColor = cellColor;
                }
                illegal();
            }
        }

        

        private void win(int i, int j)
        {
            if(!isMuted)
                winSound.Play();
            if (board[i, j].state == States.X)
            {
                xScore += 1;
                label3.Text = xScore.ToString();
                gameHistory.Add($"Round {roundCounter}: X Wins!");
                winnerName = "Player 1";
            }
            else
            {
                oScore += 1;
                label4.Text = oScore.ToString();
                gameHistory.Add($"Round {roundCounter}: O Wins!");
                winnerName = "Player 2";
            }
            roundCounter++;
            winner winForm = new winner(this, winnerName);
            winForm.StartPosition = FormStartPosition.CenterParent;
            winForm.ShowDialog();
            reset();
        }
        //reset game
        void reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i, j].Image = null;
                    board[i, j].BackgroundImage = null;
                    board[i, j].Text = "";
                    board[i, j].state = States.F;
                }
            panel1.BackColor = Color.White;
            panel4.BackColor = Color.Transparent;
            role = 0;
            PlayGeneralClick();
            winnerName = "";
        }
        //settings button
        private void button1_Click(object sender, EventArgs e)
        {
            PlayGeneralClick();
            overlayForm frm = new overlayForm(this);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Size = this.Size;
            frm.button2.Location = button1.Location;
            button1.Visible = false;
            frm.ShowDialog();
        }
        //new game button
        private async void button3_Click(object sender, EventArgs e)
        {
            PlayGeneralClick();
            if (!doubleCheck)
            {
                button3.Text = "Sure?";
                button3.BackColor = Color.Red;
                button3.ForeColor = Color.White;
                doubleCheck = true;
                await Task.Delay(3000);
                button3.Text = "New Game";
                button3.BackColor = button4.BackColor;
                doubleCheck = false;
                button3.ForeColor = button4.ForeColor;
            }
            else
            {
                reset();
                doubleCheck = false;
                button3.Text = "New Game";
                button3.BackColor = button4.BackColor;
                button3.ForeColor = button4.ForeColor;
                label3.Text = "0";
                label4.Text = "0";
                xScore = oScore = 0;
            }
        }
        //scoreboard button
        private void button4_Click(object sender, EventArgs e)
        {
            PlayGeneralClick();
            panel2.Visible = !panel2.Visible;
            panel3.Visible = !panel3.Visible;
            panel1.Visible = !panel1.Visible;
            panel4.Visible = !panel4.Visible;
        }

        private void checkWinner()
        {
            for (int i = 0; i < 3; i++)
                if (board[i, 1].state == board[i, 0].state && board[i, 1].state == board[i, 2].state && board[i, 1].state != States.F)
                { win(i, 1); return; }

            for (int j = 0; j < 3; j++)
                if (board[1, j].state == board[0, j].state && board[1, j].state == board[2, j].state && board[1, j].state != States.F)
                { win(1, j); return; }

            if (board[0, 0].state == board[1, 1].state && board[1, 1].state == board[2, 2].state && board[1, 1].state != States.F)
                win(1, 1);
            else if (board[0, 2].state == board[1, 1].state && board[1, 1].state == board[2, 0].state && board[1, 1].state != States.F)
                win(1, 1);

        }
        private void TicTacToe_Load(object sender, EventArgs e)
        {
            if(!isMuted)
                startSound.Play();
        }
    }
}
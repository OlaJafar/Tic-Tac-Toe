using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing.Text; // مهم جداً


namespace Tic_Tac_Toe

{

    public partial class TicTacToe : Form

    {

        Piece[,] board = new Piece[3, 3];



        int xScore = 0, oScore = 0, role = 0;



        Label lblScore = new Label();
        PrivateFontCollection pfc = new PrivateFontCollection();
        Font pixelFont;

        public TicTacToe()

        {

            InitializeComponent();
            InitCustomFont();
            intial();
            

        }



        private void intial()

        {

            int boardSize = 300; // حجم الجريد كامل (3 مربعات * 100 بكسل)

            // حساب نقطة البداية عشان الجريد يكون في النص
            int startX = (this.ClientSize.Width - boardSize) / 2;
            int startY = 20;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    // نجمع startX و startY على مكان المربع
                    board[i, j] = new Piece(startX + (j * 100), startY + (i * 100));

                    board[i, j].Click += play;
                    board[i, j].Cursor = Cursors.Hand;
                    board[i, j].UseCompatibleTextRendering = true;
                    board[i, j].BackColor = Color.Thistle;
                    Controls.Add(board[i, j]);
                }
            }
            button3.UseCompatibleTextRendering = true;
            button3.Font= new Font(pfc.Families[0], 10, FontStyle.Regular);
            button4.UseCompatibleTextRendering = true;
            button4.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);

            drawScore();

        }



        private void drawScore()

        {

            lblScore.Location = new Point(this.ClientSize.Width/2-150, 0);

            lblScore.Width = 300;
            lblScore.Height = 100;

            lblScore.TextAlign = ContentAlignment.MiddleCenter;

            lblScore.Text = "Player1 : 0 VS Player 2 : 0";
            lblScore.UseCompatibleTextRendering = true;
            lblScore.Font= new Font(pfc.Families[0], 10, FontStyle.Regular);

            Controls.Add(lblScore);

        }


// تعريف متغيرات الخط على مستوى الكلاس


    private void InitCustomFont()
    {
        // تحويل ملف الخط من الريسورسز إلى مصفوفة بايتات
        byte[] fontData = Properties.Resources.pixelArtFont;
        IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
        System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

        // إضافة الخط لمجموعة الخطوط الخاصة بالبرنامج
        pfc.AddMemoryFont(fontPtr, fontData.Length);

        // إنشاء الفونت بحجم 16 مثلاً
        pixelFont = new Font(pfc.Families[0], 40, FontStyle.Regular);
    }

    private void play(object sender, EventArgs e)

        {

            Button btn = (Button)sender;
            int boardSize = 300;
            int startX = (this.ClientSize.Width - boardSize) / 2;
            int startY = 20;

            // طرح نقطة البداية قبل القسمة عشان نطلع الـ Index الصح
            int i = (btn.Top - startY) / 100;
            int j = (btn.Left - startX) / 100;


            if (board[i, j].state == States.F)

            {

                //if role true, it's X Player Role, else it's O role
                board[i, j].Font = pixelFont;
                board[i, j].ForeColor = Color.Black;
                if (role % 2 == 0)

                {

                    board[i, j].Text = "X";
                    
                    board[i, j].state = States.X;
                    board[i, j].ForeColor = Color.Purple;


                }

                else

                {
                    board[i, j].Text = "O";

                    board[i, j].ForeColor = Color.HotPink;

                    board[i, j].state = States.O;

                }

                role += 1;

                checkWinner();

                if (role == 9) reset();

            }

            else

            {

                MessageBox.Show("This Place Not Correct");

            }

        }



        private void checkWinner()

        {

            //check rows

            for (int i = 0; i < 3; i++)

                if (board[i, 1].state == board[i, 0].state

                    && board[i, 1].state == board[i, 2].state

                    && board[i, 1].state != States.F)

                {

                    win(i, 1);

                    return;

                }



            //check cols

            for (int j = 0; j < 3; j++)

                if (board[1, j].state == board[0, j].state

                    && board[1, j].state == board[2, j].state

                    && board[1, j].state != States.F)

                {

                    win(1, j);

                    return;

                }



            //check diagonals

            if (board[0, 0].state == board[1, 1].state

                && board[1, 1].state == board[2, 2].state

                && board[1, 1].state != States.F)

                win(1, 1);

            else if (board[0, 2].state == board[1, 1].state

                && board[1, 1].state == board[2, 0].state

                && board[1, 1].state != States.F)

                win(1, 1);

        }



        private void TicTacToe_Load(object sender, EventArgs e)

        {



        }
        private void button1_Click(object sender, EventArgs e)
        {

            overlayForm frm = new overlayForm(this);

            // 1. لازم نغير الـ StartPosition لـ Manual عشان الويندوز يسمح لنا نحدد المكان يدوي
            frm.StartPosition = FormStartPosition.CenterParent;

            // 2. نحسب النقطة اللي تحت الزرار بالظبط
            // بنجيب مكان الزرار (0,0) ونحوله لإحداثيات الشاشة
            Point btnLocationOnScreen = button1.PointToScreen(Point.Empty);
            // 3. نحدد مكان الفورم الجديدة
            // X هو نفس بداية الزرار بالعرض
            // Y هو بداية الزرار بالطول + طول الزرار نفسه (عشان تنزل تحته)
            frm.Size = this.Size;
            //frm.Location = new Point(this.Location.X, btnLocationOnScreen.Y + button1.Height);
            frm.button2.Location = button1.Location;
            button1.Visible = false;
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void win(int i, int j)

        {

            if (board[i, j].state == States.X) xScore += 1;

            else oScore += 1;

            lblScore.Text = "PlX : " + xScore.ToString() + " - PlO : " + oScore;

            reset();

        }



        void reset()

        {

            for (int i = 0; i < 3; i++)

                for (int j = 0; j < 3; j++)

                {

                    board[i, j].Image = null;
                    board[i, j].Text = "";

                    board[i, j].state = States.F;

                }

            role = 0;

        }



    }

}
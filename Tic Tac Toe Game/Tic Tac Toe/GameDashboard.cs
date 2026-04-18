using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class GameDashboard : Panel
    {
        // العناصر اللي هنحتاجها بره عشان نحدث السكور
        public Label lblXScore = new Label();
        public Label lblOScore = new Label();
        public Button btnNewGame = new Button();

        public GameDashboard()
        {
            // إعدادات البانل نفسها
            this.Location = new Point(310, 0);
            this.BorderStyle = BorderStyle.FixedSingle;
            // 1. اختيار الصورة من الريسورسيز (افترضي إن اسم الصورة bg_image)
            //this.BackgroundImage = Properties.Resources.bg;

            // 2. ضبط طريقة عرض الصورة (مهم جداً عشان الشكل)
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 3. (اختياري) لو عايزة تلغي اللون القديم وتعتمدي عالصورة بس
            this.BackColor = Color.Transparent;
            SetupLayout();
        }

        private void SetupLayout()
        {
            // Player X - الصورة والاسم
            PictureBox picX = new PictureBox();
            picX.Image = Properties.Resources.X; // تأكدي إن الصورة موجودة في الـ Resources
            picX.SizeMode = PictureBoxSizeMode.Zoom;
            picX.Size = new Size(40, 40);
            picX.Location = new Point(10, 20);

            Label lblXName = new Label { Text = "Player X:", Location = new Point(60, 20), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            lblXScore.Text = "0";
            lblXScore.Location = new Point(60, 40);
            lblXScore.Font = new Font("Arial", 12);

            // Player O - الصورة والاسم
            PictureBox picO = new PictureBox();
            picO.Image = Properties.Resources.O;
            picO.SizeMode = PictureBoxSizeMode.Zoom;
            picO.Size = new Size(40, 40);
            picO.Location = new Point(10, 100);

            Label lblOName = new Label { Text = "Player O:", Location = new Point(60, 100), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            lblOScore.Text = "0";
            lblOScore.Location = new Point(60, 120);
            lblOScore.Font = new Font("Arial", 12);

            // زرار New Game
            btnNewGame.Text = "New Game";
            btnNewGame.Size = new Size(120, 40);
            btnNewGame.Location = new Point(40, 220);
            btnNewGame.BackColor = Color.LightSkyBlue;
            btnNewGame.FlatStyle = FlatStyle.Flat;

            // إضافة كل حاجة للبانل
            this.Controls.Add(picX);
            this.Controls.Add(lblXName);
            this.Controls.Add(lblXScore);
            this.Controls.Add(picO);
            this.Controls.Add(lblOName);
            this.Controls.Add(lblOScore);
            this.Controls.Add(btnNewGame);
        }
    }
}
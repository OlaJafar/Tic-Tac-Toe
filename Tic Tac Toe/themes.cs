using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class themes
    {
        public void SetOldColors(TicTacToe form)
        {
            for (int i = 0; i < form.board.GetLength(0); i++)
            {
                for (int j = 0; j < form.board.GetLength(1); j++)
                {
                    form.board[i, j].BackColor = form.cellColor;
                    if (form.board[i, j].state == States.X)
                    {
                        form.board[i, j].Text = form.Textx;
                        form.board[i, j].ForeColor = form.Colorx;
                        form.board[i, j].BackgroundImage = form.Imagex;
                    }
                    else if (form.board[i, j].state == States.O)
                    {
                        form.board[i, j].Text = form.Texto;
                        form.board[i, j].ForeColor = form.Coloro;
                        form.board[i, j].BackgroundImage = form.Imageo;

                    }
                }
            }
            form.drawScore();

        }
        private void SetVariables(TicTacToe form,Color ColorX,Color ColorO
            ,String TextX,String TextO,Image ImageX,Image ImageO,Image WinnerBg,Image DrawBg
            ,Image BG,Color CellColor,Color FontColor,int FontSize, String FontName)
        {
            form.Coloro = ColorO;
            form.Colorx = ColorX;
            form.Textx = TextX;
            form.Texto = TextO;
            form.Imagex = ImageX;
            form.Imageo = ImageO;
            form.winner = WinnerBg;
            form.draw = DrawBg;
            form.BackgroundImage = BG;
            form.cellColor = form.button3.BackColor = form.button4.BackColor = CellColor;
            form.button3.ForeColor = form.button4.ForeColor = FontColor;
            if(FontName=="")
                 form.button3.Font = form.button4.Font= new Font(form.pfc.Families[0], FontSize, FontStyle.Bold);
            else
                form.button3.Font = form.button4.Font = new Font(FontName, FontSize, FontStyle.Bold);
            SetOldColors(form);
        }

        public void PixelArt(TicTacToe form)
        {
            SetVariables(form: form, ImageX: null, ImageO: null, 
                WinnerBg: Properties.Resources.pixelartwinner,DrawBg:Properties.Resources.pixelartdraw,
                BG: Properties.Resources.tictactoebg, ColorX: Color.Purple,
                ColorO: Color.HotPink,CellColor: Color.Thistle, 
                FontColor: Color.DarkMagenta, TextX: "X", TextO: "O", 
                FontName: "", FontSize: 10);
            form.button3.Font = form.button4.Font = new Font(form.pfc.Families[0], 8, FontStyle.Bold);
        }

        public void Citadel(TicTacToe form)
        {
            SetVariables(form: form, ImageX: Properties.Resources.citadelx,
                ImageO: Properties.Resources.citadelo,
                WinnerBg: Properties.Resources.citadelwinner, DrawBg: Properties.Resources.citadeldraw,
                BG: Properties.Resources.citadelbg, ColorX: Color.Transparent,
                ColorO: Color.Transparent, CellColor: Color.DarkSeaGreen,
                FontColor: Color.SaddleBrown, TextX: "", TextO: "",
                FontName: "Curlz MT", FontSize: 14);
        }
        public void DarkMode(TicTacToe form)
        {
            SetVariables(form: form, ImageX: Properties.Resources.darkmodex,
                ImageO: Properties.Resources.darkmodeo,
                WinnerBg: Properties.Resources.darkmodewinner, DrawBg: Properties.Resources.darkmodedraw,
                BG: Properties.Resources.DarkModebg, ColorX: Color.Transparent,
                ColorO: Color.Transparent, CellColor: Color.DarkGray,
                FontColor: Color.Black, TextX: "", TextO: "",
                FontName: "Bauhaus 93", FontSize: 14);
        }
    }
}

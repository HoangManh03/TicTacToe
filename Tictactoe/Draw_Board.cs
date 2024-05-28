using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi.Models;

namespace Tictactoe
{
    public class Draw_Board
    {
        public Panel Board;
        public Draw_Board(Panel board) {
            this.Board = board;
        }


        List<Player> Players = new List<Player>()
        {
            new Player("AnhPham", Image.FromFile(Application.StartupPath + "\\o.png")),
            new Player("HoangManh", Image.FromFile(Application.StartupPath + "\\x.png")),
        };
        int CurrentPlayer = 0;

        public List<List<Button>> Matrix;

        public void DrawChessBoard()
        {

            Board.Controls.Clear();

            Matrix = new List<List<Button>>();
       
            Button preButton = new Button() { Width = 0, Height = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
            {
                List<Button> row = new List<Button>();
                for (int j = 0; j < Constant.CHESS_BOARD_WIDTH + 1; j++)
                {
                    Button new_button = new Button()
                    {
                        Width = Constant.CHESS_WIDTH,
                        Height = Constant.CHESS_HEIGTH,
                        Location = new Point(preButton.Location.X + preButton.Width, preButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    new_button.Click += new_button_Click; //nếu click vào button thì tiếp tục gọi đến hàm new_button_Click

                    Board.Controls.Add(new_button);
                    preButton = new_button;
                    row.Add(new_button);
                }
                Matrix.Add(row);
                preButton.Location = new Point(0, preButton.Location.Y + Constant.CHESS_HEIGTH);
                preButton.Width = 0;
                preButton.Height = 0;
            }
        }
  
        

        void new_button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.BackgroundImage != null)//Nếu button vừa click không null thì trả về rỗng
                return;
            //nếu click vào button rỗng thì sẽ đổi ảnh
            //của button đó thành ảnh của player
            button.BackgroundImage = Players[CurrentPlayer].Mark;
            
            //Kiểm tra thắng thua tại vị trí button vừa được click
            EndGame isEndgame = new EndGame(button, Matrix);

            if (isEndgame.isEndgame(button, Matrix) == 1)//Nếu có player thắng thì trả về 1
            {
                if (MessageBox.Show(Players[CurrentPlayer].Name + " win", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    DrawChessBoard();

                }
            }
            if (isEndgame.isEndgame(button, Matrix) == 0)//Nếu không còn button null mà không có ai thắng thì trả về 0 (Hòa)
            {
                if (MessageBox.Show("Tie", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    DrawChessBoard();

                }
            }
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

        }

        /*internal void Showdialog()
        {
            throw new NotImplementedException();
        }

        public static implicit operator Draw_Board(Matrix v)
        {
            throw new NotImplementedException();
        }*/
    }
    
}

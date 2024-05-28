using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    internal class EndGame
    {
        Player p = null;
        Button button;
        public EndGame(Button button1, List<List<Button>> matrix) {
            this.button = button1;
        }

        public int nullButton(List<List<Button>> matrix)
        {
            int nullButton = 0;
            for (int i = 0; i < Constant.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Constant.CHESS_BOARD_WIDTH; j++)
                {
                    if (matrix[i][j].BackgroundImage == null)
                    {
                        nullButton++;

                    }
                }
            }
            return nullButton;
        }

        public int isEndgame(Button button1, List<List<Button>> matrix)
        {           

            if(Constant.CHESS_BOARD_WIDTH < 5)
            {
                if (Endgame_Horizon(button1, matrix) == Constant.CHESS_BOARD_WIDTH || Endgame_Vertical(button1, matrix) == Constant.CHESS_BOARD_WIDTH ||
                Endgame_Diagonal_2(button1, matrix) == Constant.CHESS_BOARD_WIDTH || Endgame_Diagonal_1(button1, matrix) == Constant.CHESS_BOARD_WIDTH)
                {
                    return 1;
                }
                else if (nullButton(matrix) == 0)
                {
                    return 0;
                }
            }
            if(Endgame_Horizon(button1, matrix) >= 5 || Endgame_Vertical(button1, matrix) >=5 ||
                Endgame_Diagonal_2(button1, matrix) >= 5 || Endgame_Diagonal_1(button1, matrix) >= 5)
            {
                return 1;
            }
            else if (nullButton(matrix) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /*public void Endgame()
        {
            if (MessageBox.Show("Exit now?", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            {
                Gameplay f = new Gameplay();
                f.newgame();               
           
            }
        }*/

        public int Endgame_Horizon(Button button1, List<List<Button>> matrix)
        {
            /*Console.WriteLine(button.Location.X);
            Console.WriteLine(button.Location.Y);*/

            int left = 0;
            for (int i = button1.Location.X; i >= 0; i -= Constant.CHESS_WIDTH)
            {

                if (matrix[button1.Location.Y/Constant.CHESS_WIDTH][i/Constant.CHESS_WIDTH].BackgroundImage == button1.BackgroundImage)
                {                    
                    left++;
                }
                else
                    break;
            }
            
            int right = 0;
            for (int i = button1.Location.X + Constant.CHESS_WIDTH; i < Constant.CHESS_BOARD_WIDTH * Constant.CHESS_WIDTH; i += Constant.CHESS_WIDTH)
            {
                if (matrix[button1.Location.Y/Constant.CHESS_WIDTH][i/Constant.CHESS_WIDTH].BackgroundImage == button1.BackgroundImage)
                {
        
                    right++;
                }
                else
                    break;
            }
            return left + right;
        }
        public int Endgame_Vertical(Button button1, List<List<Button>> matrix)
        {
            int above = 0;
            for (int i = button1.Location.Y; i >= 0; i -= Constant.CHESS_WIDTH)
            {      

                if (matrix[i / Constant.CHESS_WIDTH][button1.Location.X / Constant.CHESS_WIDTH].BackgroundImage == button1.BackgroundImage)
                {
                    above++;
                }
                else
                    break;
            }

            int under = 0;
            for (int i = button1.Location.Y + Constant.CHESS_WIDTH; i < Constant.CHESS_BOARD_HEIGHT * Constant.CHESS_WIDTH; i += Constant.CHESS_WIDTH)
            {

                if (matrix[i / Constant.CHESS_WIDTH][button1.Location.X / Constant.CHESS_WIDTH].BackgroundImage == button1.BackgroundImage)
                {
                    under++;
                }
                else
                    break;
            }
            return under + above;
        }
        public int Endgame_Diagonal_1(Button button1, List<List<Button>> matrix)
        {
            int above = 0;
           
            for (int i = 0; i <= button1.Location.X/Constant.CHESS_WIDTH; i ++)
            {
                if(button1.Location.X / Constant.CHESS_WIDTH - i < 0 || button1.Location.Y/Constant.CHESS_WIDTH - i < 0)
                {
                    break;
                }

                if (matrix[button1.Location.Y / Constant.CHESS_WIDTH - i][button1.Location.X / Constant.CHESS_WIDTH - i ].BackgroundImage == button1.BackgroundImage)
                {
                  
                    above++;
                    
                }
                else
                    break;
            }

            int under = 0;

            for (int i = 1; i <= Constant.CHESS_BOARD_WIDTH - (button1.Location.X / Constant.CHESS_WIDTH); i++)
            {
                if (button1.Location.X / Constant.CHESS_WIDTH + i >= Constant.CHESS_BOARD_WIDTH || button1.Location.Y / Constant.CHESS_WIDTH + i >= Constant.CHESS_BOARD_HEIGHT)
                {
                    break;
                }
  
                if (matrix[button1.Location.Y / Constant.CHESS_WIDTH + i][button1.Location.X / Constant.CHESS_WIDTH + i].BackgroundImage == button1.BackgroundImage)
                {

                    under++;

                }
                else
                    break;
            }
            return above + under;
        }
        public int Endgame_Diagonal_2(Button button1, List<List<Button>> matrix)
        {

            int above = 0;

            for (int i = 0; i <= Constant.CHESS_BOARD_WIDTH - (button1.Location.X / Constant.CHESS_WIDTH); i++)
            {
                if (button1.Location.X / Constant.CHESS_WIDTH + i > Constant.CHESS_BOARD_WIDTH || button1.Location.Y / Constant.CHESS_WIDTH - i < 0)
                {
                    break;
                }

                if (matrix[button1.Location.Y / Constant.CHESS_WIDTH - i][button1.Location.X / Constant.CHESS_WIDTH + i].BackgroundImage == button1.BackgroundImage)
                {

                    above++;

                }
                else
                    break;
            }

            int under = 0;

            for (int i = 1; i <= button1.Location.X / Constant.CHESS_WIDTH; i++)
            {
                if (button1.Location.X / Constant.CHESS_WIDTH - i < 0 || (button1.Location.Y / Constant.CHESS_WIDTH) + i >= Constant.CHESS_BOARD_HEIGHT)
                {
                   
                    break;
                }

                if (matrix[button1.Location.Y / Constant.CHESS_WIDTH + i][button1.Location.X / Constant.CHESS_WIDTH - i].BackgroundImage == button1.BackgroundImage)
                {

                    under++;

                }
                else
                    break;
            }
            return above + under;
        }
    }

    
}

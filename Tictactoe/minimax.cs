using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Services.WebApi;

namespace Tictactoe
{
    internal class minimax
    {
        public void Bot_Move1(List<List<Button>> matrix, List<Player> player)
        {
            int x = 0;
            int y = 0;
            int bestScore = -999;
            for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
            {
                for(int j = 0; j < Constant.CHESS_BOARD_WIDTH; j++)
                {                                                         
                    if (matrix[i][j].BackgroundImage == null)
                    {
                        matrix[i][j].BackgroundImage = player[1].Mark;                     
                        int score = minimax1(matrix[i][j], matrix, false, player);
                        
                        matrix[i][j].BackgroundImage = null;

                        if(score > bestScore)
                        {
                            
                            bestScore = score;
                            x = i;
                            y = j;
                         
                        }
                    }
                }
            }
            matrix[x][y].BackgroundImage = player[1].Mark;

            EndGame isEndgame = new EndGame(matrix[x][y], matrix);

            if (isEndgame.isEndgame(matrix[x][y], matrix) == 1)
            {
                if (MessageBox.Show("You Lose", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    Gameplay g = new Gameplay();
                    g.newgame();
                }
            }
            if (isEndgame.isEndgame(matrix[x][y], matrix) == 0)
            {
                if (MessageBox.Show("Tie", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    Gameplay g = new Gameplay();
                    g.newgame();
                }
                return;
            }
        }

        public void Bot_Move2(List<List<Button>> matrix, List<Player> player)
        {
            int x = 0;
            int y = 0;
            int bestScore = -999;
            for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
            {
                for (int j = 0; j < Constant.CHESS_BOARD_WIDTH; j++)
                {
                    if (matrix[i][j].BackgroundImage == null)
                    {
                        matrix[i][j].BackgroundImage = player[1].Mark;
                        int score = 1;

                        matrix[i][j].BackgroundImage = null;

                        if (score > bestScore)
                        {

                            bestScore = score;
                            x = i;
                            y = j;

                        }
                    }
                }
            }
            matrix[x][y].BackgroundImage = player[1].Mark;

            EndGame isEndgame = new EndGame(matrix[x][y], matrix);

            if (isEndgame.isEndgame(matrix[x][y], matrix) == 1)
            {
                if (MessageBox.Show("You Lose", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    Gameplay g = new Gameplay();
                    g.newgame();
                }
                return;
            }
            if (isEndgame.isEndgame(matrix[x][y], matrix) == 0)
            {
                if (MessageBox.Show("Tie", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    Gameplay g = new Gameplay();
                    g.newgame();
                }
                return;
            }
        }

        int score = 0;
        public int minimax1(Button btn, List<List<Button>> matrix, bool isBot, List<Player> player)
        {
            
            EndGame isEndgame = new EndGame(btn, matrix);
            if(isEndgame.isEndgame(btn, matrix) == 0)//Nếu hòa thì trả về score = 0;
            {
                score = 0;
                return score;
            }
            if (isEndgame.isEndgame(btn, matrix) == 1)
            {
                if(btn.BackgroundImage == player[0].Mark)//Nếu người chơi thắng thì score = -10
                {
                    score = -10;                    
                }
                if (btn.BackgroundImage == player[1].Mark)//Nếu Bot thắng thì score = 10
                {
                    score = 10;
                }
                return score;
            }

            if (isBot)
            {
                int bestScore = -999;
                for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
                {
                    for (int j = 0; j < Constant.CHESS_BOARD_WIDTH; j++)
                    {
                        if (matrix[i][j].BackgroundImage == null)
                        {
                            matrix[i][j].BackgroundImage = player[1].Mark;
                            score = minimax1(matrix[i][j], matrix, false, player);
                            matrix[i][j].BackgroundImage = null;
                            if (score > bestScore)
                            {
                                bestScore = score;                               

                            }
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 999;
                for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
                {
                    for (int j = 0; j < Constant.CHESS_BOARD_WIDTH; j++)
                    {
                        if (matrix[i][j].BackgroundImage == null)
                        {
                            matrix[i][j].BackgroundImage = player[0].Mark;
                            score = minimax1(matrix[i][j], matrix, true, player);
                            matrix[i][j].BackgroundImage = null;
                            if (score < bestScore)
                            {
                                bestScore = score;

                            }
                        }
                    }
                }
                return bestScore;
            }
            
        }
        
    }
}

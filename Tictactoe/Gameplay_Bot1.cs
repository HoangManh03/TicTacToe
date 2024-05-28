using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class Gameplay_Bot1 : Form
    {
        public Gameplay_Bot1()
        {
            InitializeComponent();
            newgame();
        }


        List<Player> Players = new List<Player>()
        {
            new Player("You", Image.FromFile(Application.StartupPath + "\\o.png")),
            new Player("Computer", Image.FromFile(Application.StartupPath + "\\x.png")),
        };
        int CurrentPlayer = 0;

        public List<List<Button>> Matrix;

        public void DrawChessBoard()
        {

            panel1.Controls.Clear();

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
                    new_button.Click += new_button_Click;

                    panel1.Controls.Add(new_button);
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

            if (button.BackgroundImage != null)
                return;

            button.BackgroundImage = Players[CurrentPlayer].Mark;
            
            EndGame isEndgame = new EndGame(button, Matrix);

            if (isEndgame.isEndgame(button, Matrix) == 1)
            {
                if (MessageBox.Show("You win", "Notification", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    DrawChessBoard();
                }
            }
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            minimax mini = new minimax();
            mini.Bot_Move2(Matrix, Players);
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }      

        public int nullButton(List<List<Button>> matrix)
        {
            int nullButton = 0;
            for (int i = 0; i < Constant.CHESS_BOARD_HEIGTH; i++)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Size = new Size(Constant.CHESS_WIDTH * Constant.CHESS_BOARD_WIDTH, Constant.CHESS_HEIGTH * Constant.CHESS_BOARD_HEIGTH);

            
        }

        private void Gameplay_Bot_Load(object sender, EventArgs e)
        {
            Size = new Size(Constant.CHESS_WIDTH * Constant.CHESS_BOARD_WIDTH + 40, Constant.CHESS_HEIGTH * Constant.CHESS_BOARD_HEIGTH + 100);
        }

        private void Gameplay_Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();          
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void newgame()
        {
            DrawChessBoard();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();
        }
        public void quit()
        {
            if (MessageBox.Show("Exit now?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu f = new Menu();
            f.ShowDialog();
        }
    }
}

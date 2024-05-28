using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tictactoe
{
    public partial class Gameplay : Form
    {
        
        public Gameplay()
        {
            InitializeComponent();
            ///Vẽ bàn cờ
            newgame();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(Constant.CHESS_WIDTH * Constant.CHESS_BOARD_WIDTH + 40, Constant.CHESS_HEIGTH * Constant.CHESS_BOARD_HEIGTH + 100);
        }

        public void newgame()
        {
            Draw_Board draw = new Draw_Board(panel);
            draw.DrawChessBoard();
        }
        public void quit()
        {
            if(MessageBox.Show("Exit now?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();
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
        

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.Size = new Size(Constant.CHESS_WIDTH * Constant.CHESS_BOARD_WIDTH, Constant.CHESS_HEIGTH * Constant.CHESS_BOARD_HEIGTH);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Gameplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel_Click(object sender, EventArgs e)
        {

        }

        private void panel_Click_1(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

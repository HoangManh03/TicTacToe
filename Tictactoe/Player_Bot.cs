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
    public partial class Player_Bot : Form
    {
        public Player_Bot()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Constant.CHESS_WIDTH = 60;
            Constant.CHESS_HEIGHT = 60;
            Constant.CHESS_BOARD_WIDTH = 3;
            Constant.CHESS_BOARD_HEIGHT = 3;
            Gameplay_Bot1 g = new Gameplay_Bot1();            
            g.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Constant.CHESS_WIDTH = 60;
            Constant.CHESS_HEIGHT = 60;
            Constant.CHESS_BOARD_WIDTH = 3;
            Constant.CHESS_BOARD_HEIGHT = 3;
            Gameplay_Bot2 g = new Gameplay_Bot2();
            g.ShowDialog();
        }

        private void Player_Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}

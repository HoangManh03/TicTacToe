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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gameplay f = new Gameplay();
            f.ShowDialog();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Player_Bot p = new Player_Bot();
            p.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit now?", "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

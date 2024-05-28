using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe
{
    public class Player
    {
        public string Name;
        public Image Mark;

       public Player(string name, Image mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }
}

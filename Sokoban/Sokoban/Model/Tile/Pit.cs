using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Pit : Tile
    {
        public int ChestMoves { get; set; }

        public Pit()
        {
            this.ChestMoves = 3;
        }

        public override string ToString()
        {
            if (ChestMoves < 1)
            {
                return " ";
            }
            return "~";
        }
    }
}

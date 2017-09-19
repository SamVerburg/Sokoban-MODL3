using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Puzzle
    {
        private Tile[,] tileArray;
        private Forklift forkLift;

        public Puzzle(Tile[,] tileArray, Forklift forkLift)
        {
            this.tileArray = tileArray;
            this.forkLift = forkLift;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Puzzle
    {
        private Tile[][] tileArray;
        
        public Puzzle(Tile[][] tileArray)
        {
            this.tileArray = tileArray;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class Tile
    {
        private bool IsWalkable { get; set; }
        private int LocX { get; set; }
        private int LocY { get; set; }

        public Tile(bool isWalkable, int locX, int locY)
        {
            IsWalkable = isWalkable;
            LocX = locX;
            LocY = locY;
        }
    }
}

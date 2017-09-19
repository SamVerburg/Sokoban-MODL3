using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Forklift
    {
        public int LocX { get; set; }
        public int LocY { get; set; }

        public Forklift(int locX, int locY)
        {
            this.LocX = locX;
            this.LocY = locY;
        }
    }
}

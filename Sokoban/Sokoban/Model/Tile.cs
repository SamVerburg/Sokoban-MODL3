using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class Tile
    {
        protected bool IsWalkable { get; set; }
        protected int LocX { get; set; }
        protected int LocY { get; set; }
        public bool hasChest { get; set; }
        public override string ToString()
        {
            string print = "";
            if (this is Wall)
            {
                print = "#";
            }
            else if (this is Floor)
            {
                if (this.hasChest)
                {
                    print = "o";
                }
                else
                {
                    print = ".";
                }
            }
            else if (this is Destination)
            {
                print = "x";
            }
            return print;
        }
    }
}

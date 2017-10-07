using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class MovableObject
    {
        public Tile Tile { get; set; }
        public abstract void Move(int direction);

        protected MovableObject(Tile loc)
        {
            this.Tile = loc;
        }

        protected Tile GetAdjacentTile(int direction)
        {
            switch(direction)
            {
                case 0:
                    return Tile.Up;
                case 1:
                    return Tile.Right;
                case 2:
                    return Tile.Down;
                case 3:
                    return Tile.Left;
            }
            return null;
        }
    }
}

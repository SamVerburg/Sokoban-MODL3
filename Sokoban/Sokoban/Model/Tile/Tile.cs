using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class Tile
    {
        public Tile Left { get; set; }

        public Tile Right { get; set; }

        public Tile Up { get; set; }

        public Tile Down { get; set; }

        public MovableObject MovableObject { get; set; }
        
        public bool IsWalkable()
        {
            return MovableObject == null && !(this is Wall);
        }

        public Tile GetAdjacentTile(int direction)
        {
            switch (direction)
            {
                case 0:
                    return Up;
                case 1:
                    return Right;
                case 2:
                    return Down;
                case 3:
                    return Left;
            }
            return null;
        }
    }
}

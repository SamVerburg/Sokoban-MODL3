using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Chest : MovableObject
    {
        public Chest(Tile loc) : base(loc) { }
        public override void Move(int direction)
        {
            Tile adjacentTile = GetAdjacentTile(direction);
            if (GetAdjacentTile(direction).IsWalkable())
            {
                if (adjacentTile is Pit)
                {
                    Pit pit = (Pit)adjacentTile;
                    if (pit.ChestMoves > 0)
                    {
                        adjacentTile.MovableObject = this;
                        pit.ChestMoves--;
                    }
                    Tile.MovableObject = null;
                    Tile = adjacentTile;
                }
                else
                {
                    adjacentTile.MovableObject = this;
                    Tile.MovableObject = null;
                    Tile = adjacentTile;
                }
            }
        }

        public bool IsOnDestination()
        {
            return Tile is Destination;
        }

        public override string ToString()
        {
            if(Tile is Destination)
            {
                return "ø";
            }
            return "o";
        }
    }
}

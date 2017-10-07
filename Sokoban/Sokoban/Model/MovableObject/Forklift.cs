using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Forklift : MovableObject
    {
        public Forklift(Tile loc) : base(loc) { }

        public override void Move(int direction)
        {
            Tile adjacentTile = GetAdjacentTile(direction);
            if (adjacentTile.MovableObject is Chest && adjacentTile.GetAdjacentTile(direction).IsWalkable())
            {
                adjacentTile.MovableObject.Move(direction);
                adjacentTile.MovableObject = this;
                Tile.MovableObject = null;
                Tile = adjacentTile;
            }
            else if (GetAdjacentTile(direction).IsWalkable())
            {
                adjacentTile.MovableObject = this;
                Tile.MovableObject = null;
                Tile = adjacentTile;
            }
            else if(adjacentTile.MovableObject is Employee)
            {
                Employee emp = (Employee)adjacentTile.MovableObject;
                emp.IsSleeping = false;
            }
        }

        public override string ToString()
        {
            return "@";
        }
    }
}

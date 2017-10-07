using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Employee : MovableObject
    {
        public bool IsSleeping { get; set; }

        public Employee(Tile loc) : base(loc) { }

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
            else if (GetAdjacentTile(direction).MovableObject is Forklift)
            {
                if (adjacentTile.GetAdjacentTile(direction).MovableObject is Chest)
                {
                    GetAdjacentTile(direction).MovableObject.Move(direction);
                    adjacentTile.MovableObject = this;
                    Tile.MovableObject = null;
                    Tile = adjacentTile;
                }
                else if (adjacentTile.GetAdjacentTile(direction).IsWalkable())
                {
                    GetAdjacentTile(direction).MovableObject.Move(direction);
                    adjacentTile.MovableObject = this;
                    Tile.MovableObject = null;
                    Tile = adjacentTile;
                }
            }
        }

        public void TryMove()
        {
            Random r = new Random();
            if (IsSleeping && r.Next(10) == 0)
            {
                IsSleeping = false;
                return;
            }

            if (r.Next(4) == 0)
            {
                IsSleeping = true;
            }

            if (!IsSleeping)
            {
                Move(r.Next(4));
            }
        }

        public override string ToString()
        {
            if (IsSleeping)
            {
                return "Z";
            }
            return "$";
        }
    }
}

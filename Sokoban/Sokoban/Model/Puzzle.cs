using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Puzzle
    {
        public bool IsPlaying { get; set; } = true;
        public Tile[,] TileArray { get; set; }
        public Forklift ForkLift { get; set; }
        public List<Tile> Destinations { get; set; }

        public Puzzle(Tile[,] tileArray, Forklift forkLift, List<Tile> destinations)
        {
            this.TileArray = tileArray;
            this.ForkLift = forkLift;
            this.Destinations = destinations;
        }

        public void MoveForklift(int dirX, int dirY)
        {
            int newX = ForkLift.LocY + dirX;
            int newY = ForkLift.LocX - dirY;

            if (TileArray[newY, newX].HasChest)
            {
                if (TileArray[newY - dirY, newX + dirX].IsWalkable && !TileArray[newY - dirY, newX + dirX].HasChest)
                {
                    TileArray[newY, newX].HasChest = false;
                    TileArray[newY - dirY, newX + dirX].HasChest = true;
                    ForkLift.LocY += dirX;
                    ForkLift.LocX -= dirY;
                }
            }
            else if (TileArray[newY, newX] is Wall == false)
            {
                ForkLift.LocY += dirX;
                ForkLift.LocX -= dirY;
            }
            CheckWon();
        }

        public void CheckWon()
        {
            bool stillPlaying = false;
            foreach (Tile t in Destinations)
            {
                if (!t.HasChest)
                {
                    stillPlaying = true;
                    break;
                }
            }
            IsPlaying = stillPlaying;
        }
    }
}

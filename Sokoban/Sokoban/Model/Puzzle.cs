using System.Collections.Generic;
namespace Sokoban.Model
{
    internal class Puzzle
    {
        public Puzzle(Tile[,] tileArray, Forklift forkLift, List<Tile> destinations)
        {
            this.TileArray = tileArray;
            this.ForkLift = forkLift;
            this.Destinations = destinations;
        }
        public bool IsPlaying { get; set; } = true;

        public Tile[,] TileArray { get; set; }

        public Forklift ForkLift { get; set; }

        public List<Tile> Destinations { get; set; }

        public void MoveForklift(int dirY, int dirX)
        {
            int newY = this.ForkLift.LocX + dirY; 
            int newX = this.ForkLift.LocY + dirX;

            Tile nextTile = this.TileArray[newY, newX];
            if (nextTile.HasChest)
            {
                //If the next tile has a chest
                //Checks if the chest can be moved one position further
                Tile secondNextTile = this.TileArray[newY + dirY, newX + dirX];
                if (secondNextTile.IsWalkable
                    && !secondNextTile.HasChest)
                {
                    nextTile.HasChest = false;
                    secondNextTile.HasChest = true;
                    this.ForkLift.LocY += dirX;
                    this.ForkLift.LocX += dirY;
                }
            }
            else if (nextTile.IsWalkable)
            {
                this.ForkLift.LocY += dirX;
                this.ForkLift.LocX += dirY;
            }
            this.CheckWon();
        }

        public void CheckWon()
        {
            var stillPlaying = false;
            foreach (var t in this.Destinations)
                if (!t.HasChest)
                {
                    stillPlaying = true;
                    break;
                }
            this.IsPlaying = stillPlaying;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.View
{
    class OutputView
    {
        public void ShowPuzzle(Puzzle puzzle)
        {
            Tile[,] tileArray = puzzle.TileArray;
            Forklift forkLift = puzzle.ForkLift;
            //PRINTING CURRENT PUZZLE
            Console.Clear();
            Console.WriteLine();
            
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (forkLift.LocX == x && forkLift.LocY == y)
                    {
                        Console.Write("@");
                    }
                    else if (tileArray[x, y] != null)
                    {
                        Console.Write(tileArray[x, y].ToString());
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("Gebruik de pijltjestoetsen om de heftruk te bewegen");
            Console.WriteLine("Druk op 's' om te stoppen");
        }
    }
}

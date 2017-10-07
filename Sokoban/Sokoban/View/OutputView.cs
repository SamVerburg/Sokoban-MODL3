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
            //PRINTING CURRENT PUZZLE
            Console.Clear();
            Console.WriteLine();

            for (Tile y = puzzle.First; y != null; y = y.Down)
            {
                for (Tile x = y; x != null; x = x.Right)
                {
                    if (x.MovableObject != null)
                    {
                        Console.Write(x.MovableObject.ToString());
                    }
                    else
                    { 
                        Console.Write(x.ToString());
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Gebruik de pijltjestoetsen om de heftruk te bewegen");
            Console.WriteLine("Druk op 's' om te stoppen");
        }
    }
}

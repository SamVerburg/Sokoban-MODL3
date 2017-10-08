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
        
        public void StartupMessage()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║ Welkom bij Sokoban                               ║");
            Console.WriteLine("╠═════════════════════════════╦════════════════════╣");
            Console.WriteLine("║ betekenis van de symbolen   ║ doel van het spel  ║");
            Console.WriteLine("║                             ║                    ║");
            Console.WriteLine("║ spatie : outerspace         ║ duw met de truck   ║");
            Console.WriteLine("║      █ : muur               ║ de krat(ten)       ║");
            Console.WriteLine("║      · : vloer              ║ naar de bestemming ║");
            Console.WriteLine("║      o : krat               ║                    ║");
            Console.WriteLine("║      ø : krat op bestemming ║                    ║");
            Console.WriteLine("║      x : bestemming         ║                    ║");
            Console.WriteLine("║      @ : truck              ║                    ║");
            Console.WriteLine("╚═════════════════════════════╩════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("> Kies een doolhof (1 - 6), s = stop");
        }
    }
}

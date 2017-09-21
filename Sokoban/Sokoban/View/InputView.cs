using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Controller;

namespace Sokoban.View
{
    class InputView
    {
        private bool isPlaying = true;
        private GameController gc { get; set; } = new GameController();
        public InputView()
        {
            while (isPlaying)
            {
                StartupMessage();
                PuzzleSelect();
                PlayPuzzle();
            }
        }

        private void StartupMessage()
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
            Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");
        }

        private void PuzzleSelect()
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                int number;
                if (input == "s")
                {
                    isPlaying = false;
                    return;
                }
                else if (Int32.TryParse(input, out number))
                {
                    if (number > 0 && number < 5)
                    {
                        gc.SelectAndShowPuzzle(number);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Dit nummer is niet tussen 1 - 4");
                    }
                }
                else
                {
                    Console.WriteLine("Dit is geen geldige input");
                }
            }
            
        }

        private void PlayPuzzle()
        {
            while (gc.game.CurrentPuzzle.IsPlaying)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        gc.MoveForklift(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        gc.MoveForklift(0, 1);
                        break;
                    case ConsoleKey.UpArrow:
                        gc.MoveForklift(-1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        gc.MoveForklift(1, 0);
                        break;
                    case ConsoleKey.S:
                        return;
                }
                gc.ShowCurrentPuzzle();
            }
        }
    }
}

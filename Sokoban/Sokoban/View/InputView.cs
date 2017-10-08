using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Controller;
using Sokoban.Model;

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
                gc.OutputView.StartupMessage();
                PuzzleSelect();
                PlayPuzzle();
            }
        }


        private void PuzzleSelect()
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                int number;
                if (Int32.TryParse(input, out number))
                {
                    if (number > 0 && number < 7)
                    {
                        gc.SelectAndShowPuzzle(number);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Dit nummer is niet tussen 1 - 6");
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
            Forklift forklift = gc.Game.CurrentPuzzle.ForkLift;
            Employee employee = gc.Game.CurrentPuzzle.Employee;

            while (gc.Game.CurrentPuzzle.IsPlaying)
            {
                bool action = false;
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        forklift.Move(3);
                        action = true;
                        break;
                    case ConsoleKey.RightArrow:
                        forklift.Move(1);
                        action = true;
                        break;
                    case ConsoleKey.UpArrow:
                        forklift.Move(0);
                        action = true;
                        break;
                    case ConsoleKey.DownArrow:
                        forklift.Move(2);
                        action = true;
                        break;
                    case ConsoleKey.S:
                        return;
                }
                if (action && employee != null)
                {
                    employee.TryMove();
                }

                gc.Game.CurrentPuzzle.CheckWon();
                gc.ShowCurrentPuzzle();
            }
        }
    }
}

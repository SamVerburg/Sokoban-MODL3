using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;
using Sokoban.Model;


namespace Sokoban.Controller
{
    class GameController
    {
        public OutputView OutputView { get; set; }
        public Game Game { get; set; }
        public GameController()
        {
            OutputView = new OutputView();
            Game = new Game();
        }

        public void SelectAndShowPuzzle(int puzzleNr)
        {
            Game.SelectPuzzle(puzzleNr);
            OutputView.ShowPuzzle(Game.CurrentPuzzle);
        }

        public void ShowCurrentPuzzle()
        {
            OutputView.ShowPuzzle(Game.CurrentPuzzle);
        }
    }
}

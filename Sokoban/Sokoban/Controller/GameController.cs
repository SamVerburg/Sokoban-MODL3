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
        public OutputView outputView { get; set; }
        public Game game { get; set; }
        public GameController()
        {
            outputView = new OutputView();
            game = new Game();
        }

        public void SelectAndShowPuzzle(int puzzleNr)
        {
            game.SelectPuzzle(puzzleNr);
            outputView.ShowPuzzle(game.CurrentPuzzle);
        }

        public void ShowCurrentPuzzle()
        {
            outputView.ShowPuzzle(game.CurrentPuzzle);
        }

        public void MoveForklift(int dirX, int dirY)
        {
            game.CurrentPuzzle.MoveForklift(dirX,dirY);
        }
    }
}

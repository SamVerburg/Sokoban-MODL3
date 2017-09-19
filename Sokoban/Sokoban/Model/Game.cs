
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Game
    {
        private List<Object> Objects { get; set; }
        private Puzzle CurrentPuzzle { get; set; }
        private FileReader FileReader { get; set; }
        
        public Game()
        {

        }

        public void SelectPuzzle(int puzzleNr)
        {
            this.CurrentPuzzle = FileReader.ReadTextFile(puzzleNr);
        }
    }
}

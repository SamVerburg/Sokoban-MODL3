
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Game
    {
        public List<Object> Objects { get; set; }
        public Puzzle CurrentPuzzle { get; set; }
        public FileReader FileReader { get; set; }

        public void SelectPuzzle(int puzzleNr)
        {
            this.FileReader = new FileReader();
            this.CurrentPuzzle = this.FileReader.ReadTextFile(puzzleNr);
        }
    }
}

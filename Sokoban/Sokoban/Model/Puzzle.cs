using System.Collections.Generic;
namespace Sokoban.Model
{
    internal class Puzzle
    {
        public bool IsPlaying { get; set; } = true;

        public Tile First { get; set; }

        public Forklift ForkLift { get; set; }

        public Employee Employee { get; set; }

        public List<Chest> Chests { get; set; }

        public Puzzle(Tile first, Forklift forkLift, Employee employee, List<Chest> chests)
        {
            this.First = first;
            this.ForkLift = forkLift;
            this.Employee = employee;
            this.Chests = chests;
        }

        public void CheckWon()
        {
            foreach (Chest c in Chests)
            {
                if (!c.IsOnDestination())
                {
                    this.IsPlaying = true;
                    return;
                }
            }
            this.IsPlaying = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Floor : Tile
    {
        public Floor(Boolean hasChest)
        {
            this.IsWalkable = true;
            this.HasChest = hasChest;
        }

        public override string ToString()
        {
            if (this.HasChest)
            {
                return "o";
            }
            return "·";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Wall : Tile
    {
        public Wall()
        {
            this.IsWalkable = false;
        }
    }
}

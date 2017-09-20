using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class Tile
    {
        public bool IsWalkable { get; set; }

        public bool HasChest { get; set; }
    }
}

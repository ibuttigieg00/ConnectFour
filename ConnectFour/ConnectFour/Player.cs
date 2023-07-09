using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConnectFour.Grid;

namespace ConnectFour
{
    internal class Player
    {
        public string Name { get; set; }
        public GridPosition Piece { get; set; }

        public Player (string name, GridPosition piece)
        {
            Name = name;
            Piece = piece;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameField : Cell
    {
        public BigCell[] BigCells { get; set; }
        public GameField()
        {
            BigCells = new BigCell[9];
            for (int i = 0; i < 9; i++)
            {
                BigCells[i] = new BigCell(i);
            }
        }
        
    }
}

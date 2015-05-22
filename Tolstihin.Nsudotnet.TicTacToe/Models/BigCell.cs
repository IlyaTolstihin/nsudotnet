using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BigCell : Cell
    {
        public SmallCell[] SmallCells { get; set; }
        public BigCell(int index)
        {
            Index = index;
            SmallCells = new SmallCell[9];
            for (int i = 0; i < 9; i++)
            {
                SmallCells[i] = new SmallCell(i);
            }
        }
        
    }
}

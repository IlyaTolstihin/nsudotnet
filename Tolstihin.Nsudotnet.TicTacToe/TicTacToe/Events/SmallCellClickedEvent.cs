using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Events
{
    public class SmallCellClickedEvent
    {
        public int Index;
        public int Parent;
        public SmallCellClickedEvent(int index, int parent)
        {
            Index = index;
            Parent = parent;
        } 
    }
}

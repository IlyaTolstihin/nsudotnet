using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public interface IGameLogic
    {
        GameField GetField();
        void Click(int bigCellIdx, int smallCellIdx);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public class TicTacToeLogic : IGameLogic
    {
        private readonly GameField _field = new GameField();

        private class Counter
        {
            private Char _nextSymbol = 'X';
            public Char NextSymbol
            {
                get
                {
                    if (_nextSymbol == 'X')
                    {
                        _nextSymbol = 'O';
                        return 'X';
                    }
                    _nextSymbol = 'X';
                    return 'O';
                }
                private set { }
            }
        }

        private Counter _counter = new Counter();

        public GameField GetField()
        {
            return _field;
        }

        public void Click(int bigCellIdx, int smallCellIdx)
        {
            BigCell[] bigCells = _field.BigCells;
            BigCell clickedBigCell = bigCells[bigCellIdx];
            SmallCell clickedSmalCell = clickedBigCell.SmallCells[smallCellIdx];
            if (clickedSmalCell.Symbol == '\0' && clickedSmalCell.Available)
            {
                clickedSmalCell.Symbol = _counter.NextSymbol;
                if (clickedBigCell.Symbol == '\0' && Check(clickedBigCell.SmallCells, clickedSmalCell.Symbol))
                {
                    clickedBigCell.Symbol = clickedSmalCell.Symbol;
                    if (Check(bigCells, clickedBigCell.Symbol))
                    {
                        _field.Symbol = clickedBigCell.Symbol;
                    }
                }
                BigCell availableBigCell = bigCells[smallCellIdx];
                int Available = 0;
                foreach (SmallCell curCell in availableBigCell.SmallCells)
                {
                    if (curCell.Symbol == '\0')
                    {
                        curCell.Available = true;
                        Available++;
                    }
                    else
                    {
                        curCell.Available = false;
                    }
                }
                Boolean availableValue = false;
                if (Available == 0)
                {
                    availableValue = true;
                }
                for (int i = 0; i < 9; i++)
                {
                    if (i != smallCellIdx)
                    {
                        BigCell curBigCell = bigCells[i];
                        foreach (SmallCell curSmallCell in curBigCell.SmallCells)
                        {
                            if (curSmallCell.Symbol == '\0')
                            {
                                curSmallCell.Available = availableValue;
                            }
                            else
                            {
                                curSmallCell.Available = false;
                            }
                        }
                    }
                }
            }
        }

        private bool Check(Cell[] array, Char c)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (array[i * 3 + j].Symbol != c)
                    {
                        break;
                    }
                }
                if (j == 3)
                {
                    return true;
                }
            }

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (array[i + j * 3].Symbol != c)
                    {
                        break;
                    }
                }
                if (j == 3)
                {
                    return true;
                }
            }

            for (i = 0; i < 3; i++)
            {
                if (array[i * 3 + i].Symbol != c)
                {
                    break;
                }
            }
            if (i == 3)
            {
                return true;
            }

            for (i = 0; i < 3; i++)
            {
                if (array[i * 3 + (2 - i)].Symbol != c)
                {
                    break;
                }
            }
            if (i == 3)
            {
                return true;
            }
            return false;
        }
    }
}

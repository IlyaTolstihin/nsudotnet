using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Events;
using Models;

namespace TicTacToe.ViewModels
{
    public class BigCellViewModel : PropertyChangedBase
    {
        public int Index { get; private set; }
        private Char _symbol;
        public Char Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                NotifyOfPropertyChange(() => Symbol);
            }
        }
        public BindableCollection<SmallCellViewModel> SmallCells { get; set; }
        public BigCellViewModel(IEventAggregator events, int index)
        {
            Index = index;
            SmallCells = new BindableCollection<SmallCellViewModel>();
            for (int i = 0; i < 9; i++)
            {
                SmallCells.Add(new SmallCellViewModel(events, i, Index));
            }
        }
        public void Update(BigCell bigCell)
        {
            if (bigCell.Symbol != '\0')
            {
                Symbol = bigCell.Symbol;
            }
            int i = 0;
            SmallCell[] modelSmallCells = bigCell.SmallCells;
            foreach (SmallCellViewModel smallCell in SmallCells)
            {
                smallCell.Update(modelSmallCells[i]);
                i++;
            }
        }
    }
}

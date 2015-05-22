using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Events;
using Models;

namespace TicTacToe.ViewModels
{
    public class SmallCellViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _events;
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

        public int Index { get; private set; }
        public int Parent { get; private set; }

        public SmallCellViewModel(IEventAggregator events, int index, int parent)
        {
            _events = events;
            Index = index;
            Parent = parent;
        }

        public void Click()
        {
            _events.Publish(new SmallCellClickedEvent(Index, Parent));
        }
        private bool _canClick = true;
        public bool CanClick
        {
            get { return _canClick; }
            set
            {
                _canClick = value;
                NotifyOfPropertyChange(() => CanClick);
            }
        }
        public void Update(SmallCell smallCell)
        {
            if (smallCell.Symbol != '\0')
            {
                Symbol = smallCell.Symbol;
            }
            CanClick = smallCell.Available;
        }
    }
}

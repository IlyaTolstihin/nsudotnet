using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using TicTacToe.Events;
using Logic;
using Models;
using System.Windows;

namespace TicTacToe.ViewModels
{
    [Export(typeof(MainViewModel))]
    public class MainViewModel : PropertyChangedBase, IHandle<SmallCellClickedEvent>
    {
        private readonly IEventAggregator _events;
        private IGameLogic _logic = new TicTacToeLogic();
        private string _foreground;
        public string Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                NotifyOfPropertyChange(() => Foreground);
            }
        }
        public BindableCollection<BigCellViewModel> BigCells { get; set; }
        [ImportingConstructor]
        public MainViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            BigCells = new BindableCollection<BigCellViewModel>();
            for (int i = 0; i < 9; i++)
            {
                BigCells.Add(new BigCellViewModel(events, i));
            }
        }

        public void Handle(SmallCellClickedEvent message)
        {
            _logic.Click(message.Parent, message.Index);
            GameField field = _logic.GetField();
            if (field.Symbol != '\0')
            {
                Foreground = (string)Application.Current.FindResource(field.Symbol.ToString());
            }
            BigCell[] modelBigCells = field.BigCells;
            int i=0;
            foreach (BigCellViewModel bigCell in BigCells)
            {
                bigCell.Update(modelBigCells[i]);
                i++;
            }
        }
        
    }
}

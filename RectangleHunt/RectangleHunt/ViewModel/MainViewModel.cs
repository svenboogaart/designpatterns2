using GalaSoft.MvvmLight;
using RectangleHunt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleHunt.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Game _game;
        public Game Game
        {
            get { return _game; }
            set
            {
                _game = value;
                RaisePropertyChanged("Game");
            }
        }
        public MainViewModel()
        {
            Game = new Game();
        }
    }
}

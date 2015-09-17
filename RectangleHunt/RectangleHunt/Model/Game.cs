using GalaSoft.MvvmLight;
using RectangleHunt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RectangleHunt.Model
{
    public class Game : ObservableObject
    {
        ObservableCollection<RectItem> _rectangles;
        public ObservableCollection<RectItem> Rectangles
        {
            get { return _rectangles; }
            set
            {
                _rectangles = value;
                RaisePropertyChanged("Rectangles");
            }
        }
        private bool Running { get; set; }
        private Thread thread;

        public Game()
        {
            
            Rectangles = new ObservableCollection<RectItem>();
            Rectangles.Add(new RectItem() { X = 5, Y = 5, Height = 50, Width = 50 });
            Start();
        }

        public void Start()
        {
            Running = true;
            thread = new Thread(GameRun);
            thread.Start();
        }
        
        public void GameRun()
        {
            while(Running)
            {
                GameUpdate();
                Thread.Sleep(20);
            }            
        }

        public void GameUpdate()
        {
            foreach (RectItem rectItem in Rectangles)
            {
                Console.WriteLine(rectItem.X);
                rectItem.Step();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameDP2
{
    class Game
    {
        int Score { get; set; }
        Location LocationMouse { get; set; }
        Target Targ { get; set; }
        bool Running;
        Canvas Canvas{get;set;}

        BackgroundWorker bw;

        public Game(Canvas canvas)
        {
            Canvas = canvas;
            Targ = new Target();
            Running = true;
        }



        public void Start()
        {

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            GameRender();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Running)
            {
                GameUpdate();
                //GameRender();
                bw.ReportProgress(1);        
                //repaint();   
                try
                {
                    Thread.Sleep(10);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "");
                }


            }
        }

        public void GameUpdate()
        {
            //get location
            if (Targ != null)
            {
                if (Targ.checkHit(LocationMouse))
                {
                    Score++;
                    Targ = new Target();
                }
            }
            Targ.Step();
            if (Targ.checkWalls())
            {
                Targ = new Target();
            }
        }

        public void GameRender()
        {
            Canvas.Children.Clear();

            Rectangle ding2 = new Rectangle();
            ding2.Width = 500;
            ding2.Height = 500;
            ding2.Fill = Brushes.Peru;

            Rectangle ding = new Rectangle();
            ding.Width = Targ.Width;
            ding.Height = Targ.Height;
            ding.Fill = Brushes.Azure;

            Canvas.Children.Add(ding2);
            Canvas.Children.Add(ding);
            Canvas.SetTop(ding, Targ.Location.Y);
            Canvas.SetLeft(ding, Targ.Location.X);

        }

    }
}



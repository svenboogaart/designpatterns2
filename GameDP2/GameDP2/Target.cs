using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDP2
{
    class Target
    {
        public Location Location { get; set; }
        Boolean Hit { get; set; }
        Random rnd = new Random();
        static int BounderyX = 400;
        static int BounderyY = 500;

        public int Width { get; set; }
        public int Height { get; set; }
        public bool DirectionUp { get; set; }

        public Target()
        {
            Hit = false;
            Location = new Location(0, rnd.Next(1, BounderyY));
            Width = rnd.Next(5, 50);
            Height = rnd.Next(5, 50);
            int RandomNumb = rnd.Next(0, 100);
            Console.WriteLine(RandomNumb);
            if (RandomNumb == 50)
                DirectionUp = false;
            else
                DirectionUp = true;
        }


        public Boolean checkHit(Location toCheck)
        {
            if (Location == toCheck)
                return true;
            return false;
        }

        public Boolean checkWalls()
        {
            if (Location.X > BounderyX)
                    return true;
            return false;
        }

        public void Step()
        {            

           if(Location != null){
               Location.X++;  
           }
           if (DirectionUp == true)
           {
               Location.Y--;
               if (Location.Y <= 0)
               {
                   DirectionUp = false;
               }
           }
           else
           {
               Location.Y++;
               if (Location.Y  + Height >= BounderyY)
               {
                   DirectionUp = true;
               }
               else
               {
                   //System.Console.WriteLine(Location.Y + " - " +Height);
               }
           }

        }

    
    }
}

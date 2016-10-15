using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;


namespace GameServer
{
    public class ZoneProcessor
    {
        public bool end = false;
        public int ZoneID = 0;
        public Zone zone = new Zone();

        private GameTimer gameTimer = new GameTimer();

        /// <summary>
        /// A game loop sub process, should run on own thread.
        /// </summary>
        public void Run()
        {
            TakeOwnershipOfEntities();
            gameTimer.Start();

            while (!end)
            {
                for (int i = 0; i < Settings.QuickLocatorSize; i++)
                {
                    if (!end)
                    {
                        if (QuickLocator.entities[i].Handler == ZoneID)
                        {
                            //temp stuff
                            if (gameTimer.Elapsed() - QuickLocator.entities[i].TimeStamp > 0.1d)
                            {

                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Find all entities in this zone processors boundaries and declare that it is the server that will handle the entity.
        /// </summary>
        public void TakeOwnershipOfEntities()
        {
            for (int i = 0; i < Settings.QuickLocatorSize; i++)
            {
                if (zone.boundary.IntersectsWith(new GRect(QuickLocator.entities[i].X,QuickLocator.entities[i].Y,0,0)))
                {
                    QuickLocator.entities[i].Handler = ZoneID;
                }
            }
        }
    }
}

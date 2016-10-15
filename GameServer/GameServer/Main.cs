using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace GameServer
{
    public class Main
    {
        private bool _shutDown = false;
        private EventLog _eventLog = new EventLog();
        

        public Main()
        {
            _eventLog.Source = "GameServer";
        }

        public void OnStart()
        {
            GameServerInitialize();
            GameLoop();
        }
        public void OnStop()
        {
            _shutDown = true;
        }



        public void GameServerInitialize()
        {
            RandomizeEntities();
            return;
        }

        /// <summary>
        /// Create random locations for entities
        /// </summary>
        private void RandomizeEntities()
        {
            int i = 0;
            foreach(QuickLocation locator in QuickLocator.entities)
            {
                locator.EntityId = ++i;
                
                locator.X = i;
                locator.Y = i;
                locator.Enabled = true;
            }
            return;
        }


        public void GameLoop()
        {



            //initialize
            _eventLog.WriteEntry("Initializing game.");

            //run loop
            while (!_shutDown)
            {
                Thread.Sleep(500);

                

            }

            //cleanup
            _eventLog.WriteEntry("Ending game.");
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace GameServer
{
    /// <summary>
    /// Static class used for quick entity location information.
    /// </summary>
    public static class QuickLocator
    {
        public static QuickLocation[] entities = new QuickLocation[0];

        static QuickLocator()
        {
            //Interlocked.CompareExchange(ref points[i], new mypoint(i, i), points[i]);
            Array.Resize(ref entities, Settings.QuickLocatorSize);

            for (int i = 0; i < Settings.QuickLocatorSize; i++)
                entities[i] = new QuickLocation();
        }

        /// <summary>
        /// Change information about the entity in the quicklocator.  
        /// </summary>
        public static void ChangeEntity(int entityIndex, decimal x, decimal y, double timeStamp, int handler)
        {
            QuickLocation newEntity = new GameServer.QuickLocation(entityIndex, x, y, timeStamp, handler);
            if (Interlocked.CompareExchange(ref entities[entityIndex], newEntity, entities[entityIndex]) != entities[entityIndex])
            {
                var spinner = new SpinWait();
                do
                {
                    spinner.SpinOnce();
                } while (Interlocked.CompareExchange(ref entities[entityIndex], newEntity, entities[entityIndex]) != entities[entityIndex]);

            }
        }
    }
}

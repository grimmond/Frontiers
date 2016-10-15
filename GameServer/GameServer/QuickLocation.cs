using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class QuickLocation : GVec2
    {
        public int EntityId;
        public double TimeStamp;
        public bool Enabled;
        public int Handler;

        public QuickLocation() : base(0,0)
        {
            Enabled = false;
        }
        /// <summary>
        /// Fast lookup record for zone's mobile entities.
        /// </summary>
        /// <param name="entityId">Game entity identifier</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="timeStamp">last time updated</param>
        /// <param name="handler">which thread is handing this entity</param>
        public QuickLocation(int entityId, decimal x, decimal y, double timeStamp, int handler)
            : base(x, y)
        {
            this.EntityId = entityId;
            this.TimeStamp = timeStamp;
            this.Handler = handler;
            Enabled = true;
        }
    }
}

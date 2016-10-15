using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Common
{
    public class QuickLocation : Location
    {
        public int EntityId;
        public long TimeStamp;
        public bool Enabled;
        public int Handler;

        public QuickLocation() : base()
        {
            Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId">Game entity identifier</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="z">z position</param>
        /// <param name="timeStamp">last time updated</param>
        /// <param name="handler">which thread is handing this entity</param>
        public QuickLocation(int entityId, decimal x, decimal y, decimal z, long timeStamp, int handler)
            : base(x, y, z)
        {
            this.EntityId = entityId;
            this.TimeStamp = timeStamp;
            this.Handler = handler;
            Enabled = true;
        }
    }
}

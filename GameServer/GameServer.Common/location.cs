using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Common
{
    public class Location
    {
        public decimal X = 0;
        public decimal Y = 0;
        public decimal Z = 0;

        public Location()
        {

        }

        public Location(decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

    }
}

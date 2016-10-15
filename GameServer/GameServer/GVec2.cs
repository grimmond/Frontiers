using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class GVec2
    {
        public decimal X = 0;
        public decimal Y = 0;

        public GVec2(decimal X, decimal Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static GVec2 operator +(GVec2 v1, GVec2 v2)
        {
            return new GameServer.GVec2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(Helper.ConvertDecimalToBytes(X));
            bytes.AddRange(Helper.ConvertDecimalToBytes(Y));
            return bytes.ToArray();
        }

    }
}

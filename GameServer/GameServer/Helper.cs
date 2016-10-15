using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public static class Helper
    {
        public static byte[] ConvertDecimalToBytes(decimal num)
        {
            Int32[] bits = decimal.GetBits(num);
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < 4; i++)
            {
                bytes.AddRange(BitConverter.GetBytes(bits[i]));
            }
            return bytes.ToArray();
        }

        public static decimal ConcertBytesToDecimal(byte[] bytes)
        {
            Int32[] bits = new Int32[4];
            for (int i = 0; i <= 15; i += 4)
            {
                bits[i / 4] = BitConverter.ToInt32(bytes, i);
            }

            return new decimal(bits);
        }
    }
}

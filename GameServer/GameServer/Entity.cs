using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class Entity
    {
        public int Id { get; set; }
        public GVec2 Location { get; set; }
        public GVec2 Velocity { get; set; }

        public Entity () {  }

        public Entity(byte[] bytes)
        {            
            Id = BitConverter.ToInt32(bytes,0);
            Location.X = Helper.ConcertBytesToDecimal(bytes.Skip(4).Take(16).ToArray());
            Location.Y = Helper.ConcertBytesToDecimal(bytes.Skip(4).Take(16).ToArray());
        }

        public void MoveEntity()
        {
            Location += Velocity;
        }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(Id));
            bytes.AddRange(Location.GetBytes());
            
            return bytes.ToArray();
        }

    }
}

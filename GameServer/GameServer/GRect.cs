using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class GRect
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal SizeX { get; set; }
        public decimal SizeY { get; set; }

        public GVec2 Location
        {
            get
            {
                return new GVec2(this.X, this.Y);
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public GRect() {}

        public GRect(decimal X, decimal Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public GRect(decimal X, decimal Y, decimal SizeX, decimal SizeY)
        {
            this.X = X;
            this.Y = Y;
            this.SizeX = X;
            this.SizeY = Y;
        }
        public GRect(GVec2 location)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Location = location;
        }
        public GRect(GVec2 location, decimal SizeX, decimal SizeY)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
        }
        public GRect(GVec2 upperRight, GVec2 lowerLeft)
        {
            this.X = upperRight.X;
            this.Y = upperRight.Y;
            this.SizeX = upperRight.X - lowerLeft.X;
            this.SizeY = upperRight.Y - lowerLeft.Y;
        }

        public bool IntersectsWith(GVec2 point)
        {
            if (this.X < point.X && this.X + this.SizeX > point.X &&
                this.Y < point.Y && this.Y + this.SizeY > point.Y)
                return true;
            return false;
        }
        public bool IntersectsWith(GRect rect)
        {
            if (this.X < rect.X + rect.SizeX && this.X + this.SizeX > rect.X &&
                this.Y < rect.Y + rect.SizeY && this.Y + this.SizeY > rect.Y)
                return true;

            return false;
        }


    }
}

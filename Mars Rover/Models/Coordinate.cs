using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Models
{
    public class Coordinate
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public string direction { get; set; } // should be an enum

        public Coordinate(int xCoord, int yCoord, string direction)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.direction = direction;
        }

         /*
         * Returns the current position as a string
         */
        public override string ToString()
        {
            return xCoord + " " + yCoord + " " + direction.ToUpper();
        }
    }
}

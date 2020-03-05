using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Models
{
    public class Plateau
    {
        public int xCoordMax;
        public int yCoordMax;

        public Plateau(string xCoord, string yCoord)
        {
            if(int.TryParse(yCoord, out yCoordMax) == false || int.TryParse(xCoord, out xCoordMax) == false)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override bool Equals(object o)
        {
            return o is Plateau 
                && ((Plateau)o).xCoordMax == this.xCoordMax 
                && ((Plateau)o).yCoordMax == this.yCoordMax;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}

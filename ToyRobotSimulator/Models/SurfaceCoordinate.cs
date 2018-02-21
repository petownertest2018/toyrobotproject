using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class SurfaceCoordinate 
    {
        public int X_Position { get; set; }
        public int Y_Position { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SurfaceCoordinate p = (SurfaceCoordinate)obj;
            return (X_Position == p.X_Position) && (Y_Position == p.Y_Position);
        }
        public override int GetHashCode()
        {
            return X_Position ^ X_Position;
        }
    }
}

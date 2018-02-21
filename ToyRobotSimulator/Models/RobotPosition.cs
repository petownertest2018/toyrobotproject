using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class RobotPosition
    {
        public Direction Direction { get; set; }
        public SurfaceCoordinate Coordinate { get; set; }
        
        public RobotPosition(Direction direction, SurfaceCoordinate coordinate)
        {
            Direction = direction;
            Coordinate = coordinate;
        }

       
    }
}

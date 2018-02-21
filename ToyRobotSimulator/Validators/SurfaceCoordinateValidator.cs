using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class SurfaceCoordinateValidator : ISurfaceCoordinateValidator
    {
        private  const int MIN_X = 0;
        private const int MIN_Y = 0;
        private const int MAX_X = 4;
        private const int MAX_Y = 4;
        public bool Validate(SurfaceCoordinate pos)
        {
            return pos.X_Position >= MIN_X && pos.X_Position <= MAX_X
                && pos.Y_Position >= MIN_Y && pos.Y_Position <= MAX_Y; 
        }
    }
}

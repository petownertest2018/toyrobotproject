using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.Models
{
    public class Robot
    {
        public Robot(int id, string name, ISurfaceCoordinateValidator surfaceCoordinateValidator)
        {
            this.Id = id;
            this.Name = name;
            _surfaceCoordinateValidator = surfaceCoordinateValidator;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        private RobotPosition _robotPosition;
        private ISurfaceCoordinateValidator _surfaceCoordinateValidator;

        public RobotPosition RobotPosition { get { return _robotPosition; } }
        public void UpdatePosition(RobotPosition position)
        {
            if(position.Direction == Direction.UNKNOWN || !_surfaceCoordinateValidator.Validate(position.Coordinate))
            {
                throw new ArgumentException("Invalid position to update to robot!");
            }
            _robotPosition = position;
        }
    }
}

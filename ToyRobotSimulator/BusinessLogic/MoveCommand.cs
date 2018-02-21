using System;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class MoveCommand : ICommand
    {
        private ICommandParam _commandParam;
        private ISurfaceCoordinateValidator _coordinateValidator;
       
        public MoveCommand(ICommandParam commandParam, ISurfaceCoordinateValidator validator)
        {
            _commandParam = commandParam;
            _coordinateValidator = validator;
            
        }

        public ICommandParam CommandParam { get => _commandParam; set => _commandParam = value; }
     
        public bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition)
        {
            if (!(_commandParam is MoveCommandParam))
                throw new ArgumentException("Incorrect command received for Move Command!");
            
            robotPosition = null;

            if (originalPosition == null)
                return false;

            var pos = new SurfaceCoordinate() { X_Position = originalPosition.Coordinate.X_Position, Y_Position   = originalPosition.Coordinate.Y_Position};
            var xIncr = originalPosition.Direction == Direction.EAST ? 1
                     :((originalPosition.Direction == Direction.WEST ? -1 : 0));
            pos.X_Position += xIncr;

            var yIncr = originalPosition.Direction == Direction.NORTH ? 1
                    : ((originalPosition.Direction == Direction.SOUTH ? -1 : 0));
            pos.Y_Position += yIncr;

            var valid = _coordinateValidator.Validate(pos);
            if (valid)
            {
                robotPosition = new RobotPosition(originalPosition.Direction, pos);
                return true;
            }
            return false ; 
        }
    }
}
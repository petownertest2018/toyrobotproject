using System;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class RightCommand : ICommand
    {
        private ICommandParam _commandParam;
        
        public RightCommand(ICommandParam commandParam)
        {
            _commandParam = commandParam;
        }

        public ICommandParam CommandParam { get => _commandParam; set => _commandParam = value; }

        public bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition)
        {

            if (!(_commandParam is RightCommandParam))
                throw new ArgumentException("Incorrect command received for Right Command!");

            robotPosition = null;

            if (originalPosition == null)
                return false;

            Direction dir;
            if (originalPosition.Direction == Direction.WEST)
                dir = Direction.NORTH;
            else
                dir = originalPosition.Direction + 1;
            

            robotPosition = new RobotPosition(dir, originalPosition.Coordinate);
            return true;           
        }
    }
}
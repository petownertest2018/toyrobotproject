using System;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class LeftCommand : ICommand
    {
        private ICommandParam _commandParam;
       
        public LeftCommand(ICommandParam commandParam)
        {
            _commandParam = commandParam;            
        }

        public ICommandParam CommandParam { get => _commandParam; set => _commandParam = value; }
      
        public bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition)
        {
            if (!(_commandParam is LeftCommandParam))
                throw new ArgumentException("Incorrect command received for Left Command!");

            robotPosition = null;
          
            if (originalPosition == null)
                return false;

            Direction dir;
            if (originalPosition.Direction == Direction.NORTH)
                dir = Direction.WEST;
            else
                dir = originalPosition.Direction - 1;

            robotPosition = new RobotPosition(dir, originalPosition.Coordinate);
            return true;           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator
{
    public class PlaceCommand : ICommand
    {
        private ICommandParam _commandParam;
        private ISurfaceCoordinateValidator _surfaceCoordinateValidator;
        public PlaceCommand(ICommandParam commandParam, ISurfaceCoordinateValidator surfaceCoordinateValidator)
        {
            _commandParam = commandParam;
            _surfaceCoordinateValidator = surfaceCoordinateValidator;
        }

        public ICommandParam CommandParam { get => _commandParam; set => _commandParam = value; }
        
        public bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition)
        {
            if (!(_commandParam is PlaceCommandParam))
                throw new ArgumentException("Incorrect command received for Place Command!");

            robotPosition = null;

            var param = (PlaceCommandParam)_commandParam;

            if (_surfaceCoordinateValidator.Validate(param.SurfaceCoordinate))
            {
                robotPosition = new RobotPosition(param.Direction, param.SurfaceCoordinate);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}

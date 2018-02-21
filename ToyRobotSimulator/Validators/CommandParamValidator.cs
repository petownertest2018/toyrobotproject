using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    public class CommandParamValidator : ICommandParamValidator
    {
        private ISurfaceCoordinateValidator _surfaceCoordinateValidator;//= new SurfaceCoordinateValidator();
        private IDirectionValidator _directionValidator;//= new DirectionValidator();
        

        public CommandParamValidator(ISurfaceCoordinateValidator surfaceCoordinateValidator, IDirectionValidator directionValidator)
        {
            _surfaceCoordinateValidator = surfaceCoordinateValidator;
            _directionValidator = directionValidator;
        }

        public ISurfaceCoordinateValidator CoordinateValidator => _surfaceCoordinateValidator;

        public ICommandParam ValidateCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return null;
            if (IsPlaceCommand(command, out Direction direction, out SurfaceCoordinate surfaceCoordinate))
            {
                var cmd = new PlaceCommandParam(direction, surfaceCoordinate);
                return cmd;
            }else if (IsMoveCommand(command))
            {
                var cmd = new MoveCommandParam();
                return cmd;
            }
            else if (IsLeftCommand(command))
            {
                var cmd = new LeftCommandParam();
                return cmd;
            }
            else if (IsRightCommand(command))
            {
                var cmd = new RightCommandParam();
                return cmd;
            }
            else if (IsReportCommand(command))
            {
                var cmd = new ReportCommandParam();
                return cmd;
            }
            return null;
        }
        private bool IsLeftCommand(string command)
        {
            return command.ToUpper() == CommandType.LEFT.ToString().ToUpper();
        }
        private bool IsReportCommand(string command)
        {
            return command.ToUpper() == CommandType.REPORT.ToString().ToUpper();
        }
        private bool IsRightCommand(string command)
        {
            return command.ToUpper() == CommandType.RIGHT.ToString().ToUpper();
        }
        private bool IsMoveCommand(string command)
        {
            return command.ToUpper() == CommandType.MOVE.ToString().ToUpper();
        }
        private bool IsPlaceCommand(string command, out Direction direction, out SurfaceCoordinate coordinate)
        {
            var splitParam = command?.Split(' ');
            direction =  Direction.UNKNOWN;
            coordinate = null;
            if (splitParam.Count() == 3)
            {
                var placeCommand = splitParam[0].ToUpper();
                var surfaceCoordinate = splitParam[1].Split(',');
                var directionTemp = splitParam[2].ToUpper();
                var validCoordinate = false;
                if(surfaceCoordinate.Length == 2)
                {
                    var parse_x = int.TryParse(surfaceCoordinate[0], out int x);
                    var parse_y = int.TryParse(surfaceCoordinate[1], out int y);
                    if (parse_x && parse_y)
                    {
                        coordinate = new SurfaceCoordinate { X_Position = x, Y_Position = y };
                        validCoordinate = _surfaceCoordinateValidator.Validate(coordinate);
                    }
                }
                if (placeCommand == CommandType.PLACE.ToString().ToUpper() && validCoordinate && _directionValidator.IsValid(directionTemp,out direction))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    public class CommandManager : ICommandManager
    {
        private ICommandParamValidator _paramValidator;
        private IReportDisplay _reportDisplay;
        public CommandManager(ICommandParamValidator paramValidator, IReportDisplay reportDisplay)
        {
            _paramValidator = paramValidator;
            _reportDisplay = reportDisplay;
        }

        public ICommand ChooseCommand(string rawcommand)
        {
            var result = _paramValidator.ValidateCommand(rawcommand);
            if (result is PlaceCommandParam)
            {
                ICommand cmd = new PlaceCommand(result, _paramValidator.CoordinateValidator);
                return cmd;
            }
            else if (result is MoveCommandParam)
            {
                ICommand cmd = new MoveCommand(result, _paramValidator.CoordinateValidator);
                return cmd;
            }
            else if (result is LeftCommandParam)
            {
                ICommand cmd = new LeftCommand(result);
                return cmd;
            }
            else if (result is RightCommandParam)
            {
                ICommand cmd = new RightCommand(result);
                return cmd;
            }
            else if (result is ReportCommandParam)
            {
                ICommand cmd = new ReportCommand(result, _reportDisplay);
                return cmd;
            }
            return null;
        }
    }
}

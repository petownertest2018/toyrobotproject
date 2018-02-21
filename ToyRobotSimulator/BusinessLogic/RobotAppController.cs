using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.BusinessLogic
{
    public class RobotAppController
    {
        private Robot _robot;
        private ICommandManager _commandManager;
        private ICommandReader _commandReader;
        private IReportDisplay _reportDisplay;
        public RobotAppController(Robot robot, ICommandManager commandManager, ICommandReader commandReader, IReportDisplay reportDisplay)
        {
            _robot = robot;
            _commandManager = commandManager;
            _commandReader = commandReader;
            _reportDisplay = reportDisplay;
        }
        public void ReportRobot()
        {
            _reportDisplay.ShowRobot(_robot);
        }
        public void ProcessCommand()
        {
            var rawcommand = _commandReader.GetCommand();
            var command = _commandManager.ChooseCommand(rawcommand);
            Console.WriteLine($"Valid command received: {command!=null}");

            if (command != null)
            {
                RobotPosition position = null;
                var result = command.GetCommandResult(_robot.RobotPosition , out position);
                Console.WriteLine($"Command performed by robot: {result}");
                if (result)
                {
                    if (command is PlaceCommand || command is LeftCommand || command is RightCommand || command is MoveCommand)
                    {
                        _robot.UpdatePosition(position);
                    }else if (command is ReportCommand)
                    {
                        _reportDisplay.ShowRobot(_robot);
                    }
                }
            }
        }

    }
}

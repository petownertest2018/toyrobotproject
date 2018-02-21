using System;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    public class ReportCommand : ICommand
    {
        private ICommandParam _commandParam;
        private Robot _robot;
        private IReportDisplay _reportDisplay;
        public ReportCommand(ICommandParam commandParam, IReportDisplay reportDisplay)
        {
            var param = (ReportCommandParam) commandParam;
            _commandParam = param;
            _robot = param.Robot;
            _reportDisplay = reportDisplay;
        }

        public ICommandParam CommandParam { get => _commandParam; set => _commandParam = value; }
       
        public bool GetCommandResult(RobotPosition originalPosition, out RobotPosition robotPosition)
        {
            robotPosition = null;
            return true;          
        }
        public void Display(Robot robot)
        {
            _reportDisplay.ShowRobot(robot);
        }
    }
}
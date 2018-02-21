using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.BusinessLogic;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class ReportCommandTest
    {
        [TestMethod]
        public void Report_command_should_report_robot_position()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.EAST, originalPos);
            var surfaceCoordinateValidator = new SurfaceCoordinateValidator();
            var robot = new Robot(0, "test",surfaceCoordinateValidator);
            robot.UpdatePosition(robotPosition);
            var param = new ReportCommandParam();
            var reportDisplay = new ReportConsoleDisplay();
            var cmd = new ReportCommand(param, reportDisplay);

            cmd.Display(robot);
           
        }

    }
}

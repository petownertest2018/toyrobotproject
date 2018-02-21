using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.BusinessLogic;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class ReportConsoleDisplayTest
    {
        [TestMethod]
        public void Report_console_display_should_report_successfully()
        {
            var reportDisplay = new ReportConsoleDisplay();
            var surfaceCoordinateValidator = new SurfaceCoordinateValidator();
            SurfaceCoordinate coordinate = new SurfaceCoordinate() { X_Position = 0 , Y_Position = 1 };
            var pos = new RobotPosition(Direction.NORTH, coordinate);
            var robot = new Robot(0,"test", surfaceCoordinateValidator);
            robot.UpdatePosition(pos);
            reportDisplay.ShowRobot(robot);
        }
    }
}

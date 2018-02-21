using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class LeftCommandTest
    {
        [TestMethod]
        public void Left_command_should_move_robot_in_north_to_west()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.NORTH, originalPos);

            var param = new LeftCommandParam();
            var cmd = new LeftCommand(param);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };

            Assert.AreEqual<Direction>(Direction.WEST, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }

        [TestMethod]
        public void Left_command_should_move_robot_in_south_to_east()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.SOUTH, originalPos);

            var param = new LeftCommandParam();
            var cmd = new LeftCommand(param);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };

            Assert.AreEqual<Direction>(Direction.EAST, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }
    }
}

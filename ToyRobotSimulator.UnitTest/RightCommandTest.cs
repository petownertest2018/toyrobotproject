using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class RightCommandTest
    {
        [TestMethod]
        public void Right_command_should_move_robot_in_east_to_south()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.EAST, originalPos);

            var param = new RightCommandParam();
            var cmd = new RightCommand(param);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };

            Assert.AreEqual<Direction>(Direction.SOUTH, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }

        [TestMethod]
        public void Right_command_should_move_robot_in_west_to_north()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.WEST, originalPos);

            var param = new RightCommandParam();
            var cmd = new RightCommand(param);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };

            Assert.AreEqual<Direction>(Direction.NORTH, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }
    }
}

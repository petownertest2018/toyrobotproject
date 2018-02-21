using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestMethod]
        public void Move_command_should_move_robot_in_0_0_North_to_0_1_North()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.NORTH, originalPos);
            var validator = new SurfaceCoordinateValidator();
            var param = new MoveCommandParam();
            var cmd = new MoveCommand(param, validator);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 1 };
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.NORTH, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }

        [TestMethod]
        public void Move_command_should_not_move_robot_in_0_0_South_to_anywhere()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.SOUTH, originalPos);
            var validator = new SurfaceCoordinateValidator();
            var param = new MoveCommandParam();
            var cmd = new MoveCommand(param, validator);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
           
            Assert.AreEqual<bool>(false, actual);
            Assert.AreEqual<RobotPosition>(null, actualPosition);
        }
    }
}

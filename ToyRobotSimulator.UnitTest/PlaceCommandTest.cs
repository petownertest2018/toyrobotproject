using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class PlaceCommandTest
    {
        [TestMethod]
        public void Place_command_should_palce_robot_in_0_0_North()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var validator = new SurfaceCoordinateValidator();
            var param = new PlaceCommandParam(Direction.NORTH, originalPos);

            var cmd = new PlaceCommand(param, validator);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(null, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.NORTH, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }

        [TestMethod]
        public void Place_command_should_not_move_robot_in_0_0_South_to_anywhere()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 5 };
            RobotPosition robotPosition = null;
            var validator = new SurfaceCoordinateValidator();
            var param = new PlaceCommandParam(Direction.NORTH, originalPos);
            var cmd = new PlaceCommand(param, validator);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
           
            Assert.AreEqual<bool>(false, actual);
            Assert.AreEqual<RobotPosition>(null, actualPosition);
        }
        [TestMethod]
        public void Place_command_throw_arguent_exception_for_incorrect_command_param()
        {
            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.SOUTH, originalPos);
            var validator = new SurfaceCoordinateValidator();
            var param = new MoveCommandParam();
            var cmd = new PlaceCommand(param, validator);

            RobotPosition actualPosition = null;
            //var actual = cmd.GetCommandResult(out actualPosition);
            Assert.ThrowsException<ArgumentException>(() => cmd.GetCommandResult(null, out actualPosition));
        }
    }
    
}

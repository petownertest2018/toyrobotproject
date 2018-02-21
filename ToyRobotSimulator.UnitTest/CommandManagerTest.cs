using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class CommandManagerTest
    {
        [TestMethod]
        public void Command_Manager_should_return_place_command_when_place_0_1_north_is_given()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var paramValidator = new CommandParamValidator(coordinateValidator,directionValidator);
            var mgr = new CommandManager(paramValidator, null);
            PlaceCommand cmd = (PlaceCommand) mgr.ChooseCommand("PLACE 0,1 NORTH");

            var coordinate = new SurfaceCoordinate { X_Position = 0, Y_Position = 1 };

            PlaceCommandParam actualParam = (PlaceCommandParam)cmd.CommandParam;
            Assert.AreEqual<CommandType>(CommandType.PLACE, actualParam.CommandParamType);
            Assert.AreEqual<Direction>(Direction.NORTH, actualParam.Direction);
            Assert.AreEqual<SurfaceCoordinate>(coordinate, actualParam.SurfaceCoordinate);

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(null, out actualPosition);

            Assert.AreEqual<bool>(true, actual);

            Assert.AreEqual<Direction>(Direction.NORTH, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(coordinate, actualPosition.Coordinate);
        }

        [TestMethod]
        public void Command_Manager_should_return_move_command_when_move_is_given()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var paramValidator = new CommandParamValidator(coordinateValidator, directionValidator);

            var originalPos = new SurfaceCoordinate { X_Position = 0, Y_Position = 0 };
            var robotPosition = new RobotPosition(Direction.EAST, originalPos);

            var mgr = new CommandManager(paramValidator,null);            
            
            var cmd = (MoveCommand)mgr.ChooseCommand("MOVE");

            RobotPosition actualPosition = null;
            var actual = cmd.GetCommandResult(robotPosition, out actualPosition);
            var expectedCoordinate = new SurfaceCoordinate { X_Position = 1, Y_Position = 0 };

            Assert.AreEqual<Direction>(Direction.EAST, actualPosition.Direction);
            Assert.AreEqual<SurfaceCoordinate>(expectedCoordinate, actualPosition.Coordinate);
        }
    }
}

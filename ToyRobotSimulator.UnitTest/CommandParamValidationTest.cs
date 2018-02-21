using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class CommandParameterTest
    {
        [TestMethod]
        public void Command_Param_Validator_should_return_place_command_param_for_input_PLACE_4_1_SOUTH()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);

            var result = (PlaceCommandParam) commandParamValidator.ValidateCommand("PLACE 4,1 SOUTH");

            var expectedCoordniate = new SurfaceCoordinate { X_Position = 4, Y_Position = 1 };
            Assert.AreEqual<CommandType>(CommandType.PLACE, result.CommandParamType);
            Assert.AreEqual<Direction>(Direction.SOUTH, result.Direction);
            Assert.AreEqual<int>(expectedCoordniate.X_Position, result.SurfaceCoordinate.X_Position);
            Assert.AreEqual<int>(expectedCoordniate.Y_Position, result.SurfaceCoordinate.Y_Position);
        }
        [TestMethod]
        public void Command_Param_Validator_should_return_place_command_param_for_input_PLACE_0_1_EAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = (PlaceCommandParam)commandParamValidator.ValidateCommand("PLACE 0,1 EAST");

            var expectedCoordniate = new SurfaceCoordinate { X_Position = 0, Y_Position = 1 };
            Assert.AreEqual<CommandType>(CommandType.PLACE, result.CommandParamType);
            Assert.AreEqual<Direction>(Direction.EAST, result.Direction);
            Assert.AreEqual<int>(expectedCoordniate.X_Position, result.SurfaceCoordinate.X_Position);
            Assert.AreEqual<int>(expectedCoordniate.Y_Position, result.SurfaceCoordinate.Y_Position);
        }

        [TestMethod]
        public void Command_Param_Validator_should_not_return_place_command_param_for_input_PLACE_0_5_EAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = commandParamValidator.ValidateCommand("PLACE 0,5 EAST");

            Assert.AreEqual<ICommandParam>(null, result);
        }

        [TestMethod]
        public void Command_Param_Validator_should_not_return_place_command_param_for_input_PLAACE_0_4_EAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = commandParamValidator.ValidateCommand("PLLACE 0,4 EAST");

            Assert.AreEqual<ICommandParam>(null, result);
        }

        [TestMethod]
        public void Command_Param_Validator_should_not_return_place_command_param_for_input_PLACE_0_5_WEAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = commandParamValidator.ValidateCommand("PLACE 0,5 WEAST");

            Assert.AreEqual<ICommandParam>(null, result);
        }

        [TestMethod]
        public void Command_Param_Validator_should_not_return_place_command_param_for_input_PLACE_0_comma_5_EAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = commandParamValidator.ValidateCommand("PLACE_0,5_WEAST");

            Assert.AreEqual<ICommandParam>(null, result);
        }

        [TestMethod]
        public void Command_Param_Validator_should_not_return_place_command_param_for_input_PLACE_0_dot_5_EAST()
        {
            var coordinateValidator = new SurfaceCoordinateValidator();
            var directionValidator = new DirectionValidator();
            var commandParamValidator = new CommandParamValidator(coordinateValidator, directionValidator);
            var result = commandParamValidator.ValidateCommand("PLACE 0.5 EAST");

            Assert.AreEqual<ICommandParam>(null, result);
        }
    }
}

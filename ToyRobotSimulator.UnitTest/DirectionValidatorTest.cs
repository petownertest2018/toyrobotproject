using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class DirectionValidatorTest
    {
        [TestMethod]
        public void Should_retrun_enum_north_when_north_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("NORTH", out Direction result);
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.NORTH, result);
        }

        [TestMethod]
        public void Should_retrun_enum_east_when_east_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("EAST", out Direction result);
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.EAST, result);
        }

        [TestMethod]
        public void Should_retrun_enum_south_when_south_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("SOUTH", out Direction result);
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.SOUTH, result);
        }
        [TestMethod]
        public void Should_retrun_enum_west_when_west_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("WEST", out Direction result);
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.WEST, result);
        }
        [TestMethod]
        public void Should_retrun_enum_north_when_north_lower_case_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("NORTH", out Direction result);
            Assert.AreEqual<bool>(true, actual);
            Assert.AreEqual<Direction>(Direction.NORTH, result);
        }

        [TestMethod]
        public void Should_retrun_false_when_south_east_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("SOUTH EAST", out Direction result);
            Assert.AreEqual<bool>(false, actual);
            Assert.AreEqual<Direction>(Direction.UNKNOWN, result);
        }

        [TestMethod]
        public void Should_retrun_false_when_unknown_param_is_passed()
        {
            var validator = new DirectionValidator();
            var actual = validator.IsValid("UNKNOWN", out Direction result);
            Assert.AreEqual<bool>(false, actual);
            Assert.AreEqual<Direction>(Direction.UNKNOWN, result);
        }
    }
}

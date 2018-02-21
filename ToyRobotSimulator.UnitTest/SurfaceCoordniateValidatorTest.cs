using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.UnitTest
{
    [TestClass]
    public class SurfaceCoordinateValidatorTest
    {
        [TestMethod]
        public void Coordinate_x_0_y_0_should_be_valid()
        {
            var validator = new SurfaceCoordinateValidator();
            var pos = new SurfaceCoordinate() { X_Position = 0, Y_Position = 0 };
            var actual = validator.Validate(pos);
            Assert.AreEqual<bool>(true, actual);
        }
        [TestMethod]
        public void Coordinate_x_4_y_4_should_be_valid()
        {
            var validator = new SurfaceCoordinateValidator();
            var pos = new SurfaceCoordinate() { X_Position = 4, Y_Position = 4 };
            var actual = validator.Validate(pos);
            Assert.AreEqual<bool>(true, actual);
        }
        [TestMethod]
        public void Coordinate_x_minus_1_y_0_should_be_invalid()
        {
            var validator = new SurfaceCoordinateValidator();
            var pos = new SurfaceCoordinate() { X_Position = -1, Y_Position = 0 };
            var actual = validator.Validate(pos);
            Assert.AreEqual<bool>(false, actual);
        }
        [TestMethod]
        public void Coordinate_x_0_y_5_should_be_invalid()
        {
            var validator = new SurfaceCoordinateValidator();
            var pos = new SurfaceCoordinate() { X_Position = 0, Y_Position = 5 };
            var actual = validator.Validate(pos);
            Assert.AreEqual<bool>(false, actual);
        }
    }
}

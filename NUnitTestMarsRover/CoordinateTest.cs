using Mars_Rover.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestMarsRover
{
    class CoordinateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, 0, "w", "0 0 W")]
        [TestCase(2, 4, "e", "2 4 E")]
        [TestCase(8, 10, "S", "8 10 S")]
        public void ToString_Success(int xCoord, int yCoord, string direction, string expectedResult)
        {
            //ARRANGE
            Coordinate coordinate = new Coordinate(xCoord, yCoord, direction);

            //ACT
            string result = coordinate.ToString();

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}

using Mars_Rover;
using Mars_Rover.Models;
using NUnit.Framework;
using NUnitTestMarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestMarsRover
{
    class RoverTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("0 0 n", "0 0 W", 'l')]
        [TestCase("0 0 s", "0 0 E", 'l')]
        [TestCase("0 0 e", "0 0 N", 'l')]
        [TestCase("0 0 w", "0 0 S", 'l')]
        [TestCase("0 0 n", "0 0 E", 'r')]
        [TestCase("0 0 s", "0 0 W", 'r')]
        [TestCase("0 0 e", "0 0 S", 'r')]
        [TestCase("0 0 w", "0 0 N", 'r')]
        public void Rotate_Success(string startPosition, string endposition, char rotationDirection)
        {
            //ARRANGE
            TestConsoleWrapper console = new TestConsoleWrapper();
            Plateau plateau = new Plateau("5", "5");
            Rover rover = new Rover(console, plateau, startPosition);

            //ACT
            bool result = rover.Rotate(rotationDirection);

            // ASSERT
            Assert.True(result, "Rotate method returned false when rotating left.");
            Assert.AreEqual(endposition, rover.currentPosition.ToString());
        }

        [Test]
        public void Rotate_Fail()
        {
            //ARRANGE
            TestConsoleWrapper console = new TestConsoleWrapper();
            Plateau plateau = new Plateau("5", "5");
            string startPosition = "0 0 N";
            Rover rover = new Rover(console, plateau, startPosition);

            //ACT
            bool result = rover.Rotate('z');

            // ASSERT
            Assert.False(result, "Rotate method returned true when passing invalid param.");
            Assert.AreEqual(startPosition, rover.currentPosition.ToString());
        }

        [Test]
        [TestCase("0 0 n", "0 1 N")]
        [TestCase("0 1 s", "0 0 S")]
        [TestCase("0 0 e", "1 0 E")]
        [TestCase("1 0 w", "0 0 W")]
        public void Move_Success(string startPosition, string endPosition)
        {
            //ARRANGE
            TestConsoleWrapper console = new TestConsoleWrapper();
            Plateau plateau = new Plateau("5", "5");
            Rover rover = new Rover(console, plateau, startPosition);

            //ACT
            bool result = rover.Move();

            //ASSERT
            Assert.True(result);
            Assert.AreEqual(endPosition, rover.currentPosition.ToString());
        }

        [Test]
        [TestCase("5 0 E")]
        [TestCase("0 0 S")]
        [TestCase("0 5 N")]
        [TestCase("0 0 W")]
        public void Move_Fail_OffGrid(string startPosition)
        {
            //ARRANGE
            TestConsoleWrapper console = new TestConsoleWrapper();
            Plateau plateau = new Plateau("5", "5");
            Rover rover = new Rover(console, plateau, startPosition);

            //ACT
            bool result = rover.Move();

            //ASSERT
            Assert.False(result);
        }
    }
}

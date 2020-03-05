using NUnit.Framework;
using Mars_Rover.Models;
using Mars_Rover;
using NUnitTestMarsRover.Models;

namespace NUnitTestMarsRover
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializePlateauSize_Success()
        {
            //ARRANGE
            Plateau expected = new Plateau("5", "5");
            TestConsoleWrapper console = new TestConsoleWrapper();
            console.LinesToRead.Add("5 5");

            //ACT
            Campaign campaign = new Campaign(console);

            // ASSERT
            Assert.Pass();
        }
    }
}
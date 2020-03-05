using Mars_Rover;
using Mars_Rover.Models;
using NUnit.Framework;
using NUnitTestMarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestMarsRover
{
    class CampaignTest
    {
        [Test]
        [TestCase("0 0 n", "5", "5")]
        public void BeginCampaign_Success(string startPosition, string xCoord, string yCoord)
        {
            //ARRANGE
            Plateau expectedPlateau = new Plateau(xCoord, yCoord);
            TestConsoleWrapper console = new TestConsoleWrapper();
            console.LinesToRead.Add("5 5");
            console.LinesToRead.Add(startPosition);
            console.LinesToRead.Add("m"); //move once
            console.LinesToRead.Add("");// end current rover
            console.LinesToRead.Add("");// end campaign
            Campaign campaign = new Campaign(console);
            campaign.BeginCampaign();

            //ASSERT
            Assert.AreEqual(expectedPlateau, campaign.plateau);
        }
    }
}

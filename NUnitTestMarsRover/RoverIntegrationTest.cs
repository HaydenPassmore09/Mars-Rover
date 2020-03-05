using Mars_Rover;
using NUnit.Framework;
using NUnitTestMarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestMarsRover
{
    class RoverIntegrationTest
    {
        List<string> campaignInput1 = new List<String>();
        List<string> campaignInput2 = new List<String>();

        [SetUp]
        public void Setup()
        {
            /* Sample input
             * "5 5"
             * "1 2 N"
             * "LMLMLMLMM"
             * "3 3 E"
             * "MMRMMRMRRM"
             * ""
             */
            campaignInput1.Add("5 5");
            campaignInput1.Add("1 2 N");
            campaignInput1.Add("LMLMLMLMM");
            campaignInput1.Add("3 3 E");
            campaignInput1.Add("MMRMMRMRRM");
            campaignInput1.Add("");

            //More input
            campaignInput2.Add("8 8");
            campaignInput2.Add("2 2 N");
            campaignInput2.Add("LMLMLM"); //2 1
            campaignInput2.Add("3 3 E");
            campaignInput2.Add("MRMMRMRRMR"); // x : 4, y : 1 
            campaignInput2.Add("");
        }

        [Test]
        public void BeginCampaign_Success()
        {
            //ARRANGE
            TestConsoleWrapper console1 = new TestConsoleWrapper();
            TestConsoleWrapper console2 = new TestConsoleWrapper();
            console1.LinesToRead = campaignInput1;
            console2.LinesToRead = campaignInput2;
            Campaign campaign1 = new Campaign(console1);
            Campaign campaign2 = new Campaign(console2);

            //ACT
            campaign1.BeginCampaign();
            campaign2.BeginCampaign();

            //ASSERT
            Assert.AreEqual("1 3 N", console1.outPutLines[0]);
            Assert.AreEqual("5 1 E", console1.outPutLines[1]);
            Assert.AreEqual("2 1 E", console2.outPutLines[0]);
            Assert.AreEqual("4 1 S", console2.outPutLines[1]);
        }
    }
}

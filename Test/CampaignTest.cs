using NUnit.Framework;
using System;

namespace Test
{
    public class CampaignTest
    {
        [Test]
        public void InitializePlateauSize_Success()
        {
            Plateau plateau = new Plateau("0", "0");
        }
    }
}

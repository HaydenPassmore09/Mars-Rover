using Mars_Rover.Models;
using System;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Campaign campain = new Campaign(new ConsoleWrapper());
            campain.BeginCampaign();
        }
    }
}

using Mars_Rover.Models;
using System;

namespace Mars_Rover
{
    public class Campaign
    {
        public readonly Plateau plateau;
        public IConsole console;
        public Campaign(IConsole console)
        {
            this.console = console;
            // this.console.WriteLine("Welcome! Please enter your plateau size : "); //for manual entering
            plateau = InitializePlateauSize(console.ReadLine());
        }

        /*
         * Handles the main rover campaign
         */
        public void BeginCampaign()
        {
            //console.WriteLine("Please enter your rover start position : ");//for manual entering
            string startPosition = console.ReadLine();
            while (!string.IsNullOrEmpty(startPosition))
            {
                Rover rover = new Rover(console, plateau, startPosition);                
                rover.StartExploring();

                //new rover 
                //console.WriteLine("Please enter your next rover start position : ");//for manual entering
                startPosition = console.ReadLine();
            }
        }

        /*
         * Initialises the Plateau grid size
         * Returns a Plateau object if the size is valid and throws an error if not
         */
        private Plateau InitializePlateauSize(string plateauSize)
        {
            string[] positionsCoordinates = plateauSize.Split(' ');
            Plateau plateau = new Plateau(positionsCoordinates[0], positionsCoordinates[1]);
            return plateau;
        }
    }
}
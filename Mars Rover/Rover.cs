using Mars_Rover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover
{
    public class Rover
    {
        private readonly Plateau plateau;
        public Coordinate currentPosition;
        public IConsole console;
        public Rover(IConsole console, Plateau plateau, string startPosition)
        {
            this.console = console;
            this.plateau = plateau;
            this.currentPosition = InitializeStartPosition(startPosition);
        }

        public void StartExploring()
        {
            //console.WriteLine("Where do you want to explore? : "); //for manual entering
            string input = console.ReadLine().ToLower();

            foreach (char c in input.ToCharArray())
            {
                if (c == 'm')
                {
                    Move();
                }
                else if (c == 'l' || c == 'r')
                {
                    Rotate(c);
                }
            }
            console.WriteLine(currentPosition.ToString());
        }

        /*
         * Initializes the rovers starting position on the plateau
         * Returns a Coordinate object if the position is valid and throws an error if not
         */
        private Coordinate InitializeStartPosition(string startPosition)
        {
            string[] positionsCoordinates = startPosition.Split(' ');
            Coordinate coordinate = new Coordinate(int.Parse(positionsCoordinates[0]), int.Parse(positionsCoordinates[1]), positionsCoordinates[2]);
            return coordinate;
        }

        /*
         * Moves the rover forward one space in the direction it is facing
         * Returns true if the rover has moved and false if not
         */
        public bool Move()
        {
            if (currentPosition.direction.ToLower() == "n")
            {
                if(currentPosition.yCoord + 1 <= plateau.yCoordMax && currentPosition.yCoord + 1 >= 0)
                {
                    currentPosition.yCoord++;
                    return true;
                }
            }
            else if (currentPosition.direction.ToLower() == "s")
            {
                if (currentPosition.yCoord - 1 <= plateau.yCoordMax && currentPosition.yCoord - 1 >= 0)
                {
                    currentPosition.yCoord--;
                    return true;
                }
            }
            else if (currentPosition.direction.ToLower() == "w")
            {
                if (currentPosition.xCoord - 1 <= plateau.xCoordMax && currentPosition.xCoord - 1 >= 0)
                {
                    currentPosition.xCoord--;
                    return true;
                }
            }
            else if (currentPosition.direction.ToLower() == "e")
            {
                if (currentPosition.xCoord + 1 <= plateau.xCoordMax && currentPosition.xCoord + 1 >= 0)
                {
                    currentPosition.xCoord++;
                    return true;
                }
            }
            return false;
        }

        /*
         * Rotates the Rover either left or right given the direction
         * Returns false if valid false if not
         */
        public bool Rotate(char direction)
        {
            if (direction == 'l' || direction == 'r') //checking that the input is valid, this is not really needed as the StartExploring() method checks this anyway
            {
                if (currentPosition.direction.ToLower() == "n")
                {
                    currentPosition.direction = direction == 'l' ? "w" : "e";
                    return true;
                }
                else if (currentPosition.direction.ToLower() == "e")
                {
                    currentPosition.direction = direction == 'l' ? "n" : "s";
                    return true;
                }
                else if (currentPosition.direction.ToLower() == "s")
                {
                    currentPosition.direction = direction == 'l' ? "e" : "w";
                    return true;
                }
                else if (currentPosition.direction.ToLower() == "w")
                {
                    currentPosition.direction = direction == 'l' ? "s" : "n";
                    return true;
                }
            }
            return false;
        }
    }
}

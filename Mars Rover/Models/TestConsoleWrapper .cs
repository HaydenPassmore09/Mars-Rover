using Mars_Rover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestMarsRover.Models
{
    public class TestConsoleWrapper : IConsole
    {
        public List<String> LinesToRead = new List<String>();
        public List<String> outPutLines = new List<String>();

        public void Write(string message)
        {
        }

        public void WriteLine(string message)
        {
            outPutLines.Add(message);
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
}

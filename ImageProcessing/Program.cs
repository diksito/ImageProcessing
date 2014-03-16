using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check user input
            if (!ArgumentsParser.IsValidArgs(args))
            {
                Console.WriteLine("Arguments are missing or invalid");
                System.Environment.Exit(0); // terminate the program
            }

            Image img = new Image();
        }
    }
}

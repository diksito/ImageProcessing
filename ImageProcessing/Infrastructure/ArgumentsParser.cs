using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class ArgumentsParser
    {
        /// <summary>
        /// Validate the user input
        /// </summary>
        /// <param name="arguments">Array of strings</param>
        /// <returns>Bool</returns>
        public static bool IsValidArgs(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
                return false;

            for (int i = 0; i < arguments.Length; i++)
            {
                Console.WriteLine("Input args " + arguments[i]);
            }
            return true;
        }
    }
}

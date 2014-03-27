using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Infrastructure
{
    class Log
    {
        /// <summary>
        /// Logging info messages. Time is UTC
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Console.WriteLine(Constants.INFO + ": " + DateTime.UtcNow + " " + message);
        }

        /// <summary>
        /// Logging error message. Time is UTC
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Console.WriteLine(Constants.ERROR + ": " + DateTime.UtcNow + " " + message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessing.Infrastructure;

namespace ImageProcessing
{
    class ArgumentsParser
    {
        public static Dictionary<string, string> Commands { get; set; }
        /// <summary>
        /// Validate the user input
        /// </summary>
        /// <param name="arguments">Array of strings</param>
        /// <returns>Bool</returns>
        public static bool IsValidArgs(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
                return false;


            if (arguments.Length % 2 != 0)
                return false;

            Commands = new Dictionary<string, string>(); // initialize dictionary
            for (int i = 0; i < arguments.Length - 1; i++)
            {
                // Check parameter and value pair
                if (isValidParameter(arguments[i]))
                {
                    if (isValidValue(arguments[i + 1]))
                    {
                        Commands.Add(arguments[i], arguments[i + 1]); // store commands in dictionary
                        i++;
                    }
                }
            }
            return true;
        }

        private static bool isValidValue(string value)
        {
            return true;
        }

        private static bool isValidParameter(string parameter)
        {
            parameter = parameter.ToLower();
            bool isValid = false;
            switch (parameter)
	        {
                case Constants.COMMAND_HEIGHT:
                    isValid = true;
                    break;
                case Constants.COMMAND_WIDTH:
                    isValid = true;
                    break;
                case Constants.COMMAND_RESIZE:
                    isValid = true;
                    break;
                case Constants.COMMAND_ROTATE:
                    isValid = true;
                    break;
                case Constants.COMMAND_CROP:
                    isValid = true;
                    break;
                case Constants.COMMAND_FILE:
                    isValid = true;
                    break;
                case Constants.COMMAND_DEST:
                    isValid = true;
                    break;
		        default:
                    isValid = false;
                    break;
	        }
            return isValid;
        }

        public static List<int> ParseIntValues(string value)
        {
            char[] delimiterChars = { 'x' };
            string[] words = value.Split(delimiterChars);

            List<int> parsedValues = new List<int>();
            foreach (var item in words)
            {
                int val;
                if (int.TryParse(item, out val))
                    parsedValues.Add(val);
            }

            return parsedValues;
        }
    }
}

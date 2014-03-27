using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessing.Infrastructure;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check user input
            if (!ArgumentsParser.IsValidArgs(args))
            {
                Log.Info("Arguments are missing or invalid");
                System.Environment.Exit(0); // terminate the program
            }

            // Proceed if passed arguments are ok
            if (ArgumentsParser.Commands.Keys.Count() > 0 && ArgumentsParser.Commands.Values.Count() > 0)
            {
                if (!ArgumentsParser.Commands.Keys.Contains(Constants.COMMAND_FILE))
                {
                    Log.Error("Please define file path.");
                    System.Environment.Exit(0);
                }
                // Get file and pass it to Image
                Image image = new Image(ArgumentsParser.Commands[Constants.COMMAND_FILE]);


                foreach (var item in ArgumentsParser.Commands)
                {
                    // Resize image
                    if (item.Key == Constants.COMMAND_RESIZE && !string.IsNullOrEmpty(item.Value))
                    {
                        //List<int> parameterValues = ArgumentsParser.ParseIntValues(item.Value);
                        //image.Resize(parameterValues[0], parameterValues[1]);
                        Log.Info("Resizing...");
                        Log.Info("Value: " + item.Value);
                    }
                    // Crop image
                    if (item.Key == Constants.COMMAND_CROP)
                    {
                        Log.Info("Croping...");
                        Log.Info("Value: " + item.Value);
                    }
                }

                // Free used resources
                image.Dispose();
            }
            else
            {
                Log.Error("Missing arguments!");
                System.Environment.Exit(0); // terminate the program
            }
        }
    }
}

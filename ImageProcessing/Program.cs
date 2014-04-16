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


                bool setDestinationPath = false;
                string destinationPath = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_DEST, out destinationPath))
                    setDestinationPath = true;

                // Resize image
                string resizeArgs = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_RESIZE, out resizeArgs))
                {
                    //List<int> parameterValues = ArgumentsParser.ParseIntValues(item.Value);
                    //image.Resize(parameterValues[0], parameterValues[1]);
                    Log.Info("Resizing...");
                    Log.Info("Value: " + resizeArgs);
                }
                // Crop image
                string cropArgs = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_CROP, out cropArgs))
                {
                    // Croping image...
                    Log.Info("Croping...");
                    Log.Info("Value: " + cropArgs);

                    image.SaveAs(Utility.GenerateRandomFileName());

                    //string saveTo = string.Empty;
                    //if (setDestinationPath)
                    //    destinationPath = Utility.CleanPath(destinationPath);
                    //else
                    //    destinationPath = Utility.CleanPath(image.CurrentDirectory) + @"\" + Utility.GenerateRandomFileName();
                    
                    //image.Crop(10, 30, 40, 50, destinationPath);


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

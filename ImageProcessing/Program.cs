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
                    Log.Error("Please define file input path.");
                    System.Environment.Exit(0);
                }
                // Get file and pass it to Image
                Image image = new Image(ArgumentsParser.Commands[Constants.COMMAND_FILE]);


                bool setDestinationPath = false;
                string destinationPath, parameter = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_DEST, out destinationPath))
                    setDestinationPath = true;

                // Resize image
                parameter = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_RESIZE, out parameter))
                {
                    List<int> parameterValues = ArgumentsParser.ParseIntValues(parameter);
                    if (parameterValues != null && parameterValues.Count == 2)
                    {
                        // Only positive pixels
                        if (parameterValues[0] > 0 && parameterValues[1] > 0)
                        {
                            Log.Info("Resizing...");
                            image.Resize(parameterValues[0], parameterValues[1]);
                        }
                    }
                }
                // Crop image
                parameter = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_CROP, out parameter))
                {
                    // Croping image...
                    List<int> parameterValues = ArgumentsParser.ParseIntValues(parameter);
                    if (parameterValues != null && parameterValues.Count == 4)
                    {
                        Log.Info("Croping...");
                        image.Crop(parameter[0], parameter[1], parameter[2], parameter[3]);
                    }
                }


                // Rotate
                parameter = string.Empty;
                if (ArgumentsParser.Commands.TryGetValue(Constants.COMMAND_ROTATE, out parameter))
                {
                    int degrees;
                    if(int.TryParse(parameter, out degrees))
                    {
                        image.Rotate(degrees);
                        Log.Info("Rotating...");
                    }
                }

                #region Save image
                Log.Info("Saving...");
                if (setDestinationPath)
                    image.SaveAs(destinationPath);
                else
                    image.Save();
                #endregion


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Infrastructure
{
    class Constants
    {
        public const string ERROR = "ERROR";
        public const string INFO = "INFO";
        public const string TEMPORARY_FILE_PREFIX = "temp_";

        // Commands
        public const string COMMAND_RESIZE = "-resize";
        public const string COMMAND_CROP = "-crop";
        public const string COMMAND_HEIGHT = "-height";
        public const string COMMAND_WIDTH = "-width";
        public const string COMMAND_FILE = "-file";
    }
}

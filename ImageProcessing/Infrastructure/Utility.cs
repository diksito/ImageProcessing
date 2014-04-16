using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Infrastructure
{
    class Utility
    {
        public static string GenerateRandomFileName()
        {
            return Constants.TEMPORARY_FILE_PREFIX + Guid.NewGuid().ToString();
        }

        public static string CleanPath(string path)
        {
            path = path.Replace("\"", "");
            return path;
        }
    }
}
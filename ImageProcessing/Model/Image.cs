using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class Image : File
    {
        // Properties
        public int Height { get; set; }
        public int Width { get; set; }

        // Methods
        public void Resize(int height, int width)
        {
        }

        public void ExportAs(string name, string extension)
        {
        }

        public void Rotate(int degrees)
        {
        }
    }
}

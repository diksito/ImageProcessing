using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class File
    {
        public string Name { get; set; }
        public string CurrentDirectory { get; set; }
        public int FileSize { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using ImageProcessing.Infrastructure;
namespace ImageProcessing
{
    class Image : File
    {
        // Properties
        public int Height { get; set; }
        public int Width { get; set; }
        private Bitmap image { get; set; }

        private string[] extensions = new string[] { ".jpg", ".png", ".jpeg", ".gif" };

        /// <summary>
        /// Default constructor
        /// </summary>
        public Image() { }

        public Image(string currentDirectory)
        {
            try
            {
                CurrentDirectory = currentDirectory;

                Name = Path.GetFileNameWithoutExtension(CurrentDirectory);
                string extension = Path.GetExtension(CurrentDirectory);

                if (isValidImageExtension(extension))
                    Extension = Path.GetExtension(CurrentDirectory);
                else
                    Extension = ".jpg"; // set default to jpg

                image = new Bitmap(CurrentDirectory);

                // Get image height and width
                Height = image.Height;
                Width = image.Width;
            }
            catch (FileNotFoundException exc)
            {
                Log.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Log.Error(exc.Message);
            }
        }
        public Image(string name, string currentDirectory, int FileSize, string extension, string MimeType, int height, int width)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Bitmap Resize(int height, int width)
        {
            int newHeight = (int)Math.Round(image.Height * (decimal)height / image.Width, 0);
            var destination = new Bitmap(width, newHeight);
            using (Graphics g = Graphics.FromImage(destination))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, 0, 0, width, newHeight);
            }
            return destination;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="extension"></param>
        public void ExportAs(string name, string extension)
        {
        }

        public void Save()
        {
        }


        public void SaveAs(string name)
        {
        }

        public void Rotate(int degrees)
        {
        }

        /// <summary>
        /// Crop image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination">destination path where the file will be saved</param>
        public void Crop(int x, int y, int width, int height, string destination)
        {
            Rectangle cropArea = new Rectangle(x, y, width, height);
            Bitmap bmpCrop = image.Clone(cropArea, image.PixelFormat);
            bmpCrop.Save(destination);
        }

        private bool isValidImageExtension(string ext)
        {
            if(string.IsNullOrEmpty(ext))
                return false;

            return extensions.Contains(ext);
        }

        public void Dispose()
        {
            image.Dispose();
        }
    }
}

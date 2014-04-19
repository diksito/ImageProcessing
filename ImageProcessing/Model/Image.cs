using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using ImageProcessing.Infrastructure;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    class Image : File
    {
        // Properties
        public int Height { get; set; }
        public int Width { get; set; }
        private System.Drawing.Image image { get; set; }

        private string[] extensions = new string[] { ".jpg", ".png", ".jpeg", ".gif" };

        /// <summary>
        /// Default constructor
        /// </summary>
        public Image() { }

        public Image(string filePath)
        {
            try
            {
                CurrentDirectory = Path.GetDirectoryName(filePath);

                Name = Path.GetFileNameWithoutExtension(CurrentDirectory);
                string extension = Path.GetExtension(CurrentDirectory);

                if (isValidImageExtension(extension))
                    Extension = Path.GetExtension(CurrentDirectory);
                else
                    Extension = ".jpg"; // set default to jpg

                image = System.Drawing.Image.FromFile(filePath);

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
        public void Resize(int width, int height)
        {
            int newHeight = (int)Math.Round(image.Height * (decimal)height / image.Width, 0);
            var resizedImage = new Bitmap(width, newHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, 0, 0, width, newHeight);
            }
            this.image = resizedImage;
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
            image.Save(CurrentDirectory + "/" + Utility.GenerateRandomFileName() + ".jpg", ImageFormat.Jpeg);
        }

        public void SaveAs(string name)
        {
            image.Save(name);
        }

        public void Rotate(int degrees)
        {
            Bitmap bitMap = (Bitmap)this.image;
            switch(degrees)
            {
                case 90:
                    bitMap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    break;
                case 180:
                    bitMap.RotateFlip(RotateFlipType.Rotate180FlipXY);
                    break;
                case 270:
                    bitMap.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    break;
                default:
                    break;
            }
            this.image = bitMap;
        }

        /// <summary>
        /// Crop image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="destination">destination path where the file will be saved</param>
        public void Crop(int x, int y, int width, int height)
        {
            Rectangle cropArea = new Rectangle(x, y, width, height);
            Bitmap bmpImage = new Bitmap(this.image);
            try
            {
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                this.image = bmpCrop;
            }
            catch(Exception exc)
            {
                Log.Error("Cropping image failed: " + exc.Message);
            }
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

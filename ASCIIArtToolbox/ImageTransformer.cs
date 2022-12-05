using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtToolbox
{
    public static class ImageTransformer
    {

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Resizes a image to fit the console. Also halves the height because of the size of characters.
        /// </summary>
        /// <param name="image">the image to resize</param>
        /// <returns>The resized image as a bitmap</returns>
        public static Bitmap PrepareForASCII(Image image, bool fitConsoleWidth)
        {
            int newImageWidth;
            int newImageHeight;

            if (fitConsoleWidth)
            {
                double scalingFactor = (double)Console.BufferWidth / (double)image.Width;
                newImageHeight = (int)Math.Round(image.Height * scalingFactor / 2);
                newImageWidth = Console.BufferWidth - 1;
            }
            else
            {
                newImageHeight = image.Height / 2;
                newImageWidth = image.Width;
            }
            

            return ResizeImage(image, newImageWidth, newImageHeight);
        }
    }
}

using System.Drawing;

namespace ASCIIArtToolbox
{
    public static class ImageReader
    {
        public static Bitmap GetBitmapImage(string imagePath)
        {
            try
            {
                // this.image = Image.FromFile(imagePath);
                FileStream imgStream = new FileStream(imagePath, FileMode.Open);
                return new Bitmap(imgStream);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static List<List<Pixel>> GetImagePixelMap(Bitmap bitmapImage)
        {
            List<List<Pixel>> imageList = new List<List<Pixel>>();

            for (int pixelY = 0; pixelY < bitmapImage.Height; pixelY++)
            {
                List<Pixel> pixelRowList = new List<Pixel>();

                for (int pixelX = 0; pixelX < bitmapImage.Width; pixelX++)
                {
                    Color pixelColor = bitmapImage.GetPixel(pixelX, pixelY);
                    Pixel nextPixel = new Pixel(pixelColor.R, pixelColor.G, pixelColor.B);
                    pixelRowList.Add(nextPixel);
                }

                imageList.Add(pixelRowList);
            }

            return imageList;
        }
    }
}
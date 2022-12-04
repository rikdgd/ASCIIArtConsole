using System.Drawing;

namespace ASCIIArtToolbox
{
    public class ImageReader
    {
        private string imagePath;
        // private Image ?image;
        private Bitmap ?image;
        private bool readSuccesful;


        public ImageReader(string imagePath)
        {
            this.imagePath = imagePath;
            LoadImage();
        }


        private void LoadImage()
        {
            try
            {
                // this.image = Image.FromFile(imagePath);
                FileStream imgStream = new FileStream(imagePath, FileMode.Open);
                this.image = new Bitmap(imgStream);
                this.readSuccesful = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.readSuccesful = false;
            }
        }

        public Bitmap GetBitmap()
        {
            return this.image;
        }

        public List<List<Pixel>> GetImagePixelMap()
        {
            List<List<Pixel>> imageList = new List<List<Pixel>>();

            for (int pixelY = 0; pixelY < this.image.Height; pixelY++)
            {
                List<Pixel> pixelRowList = new List<Pixel>();

                for( int pixelX = 0; pixelX < this.image.Width; pixelX++)
                {
                    Color pixelColor = this.image.GetPixel(pixelX, pixelY);
                    Pixel nextPixel = new Pixel(pixelColor.R, pixelColor.G, pixelColor.B);
                    pixelRowList.Add(nextPixel);
                }

                imageList.Add(pixelRowList);
            }

            return imageList;
        }
    }
}
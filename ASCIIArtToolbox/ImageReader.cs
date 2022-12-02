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


        public List<List<byte>> GetImageBrightnessMap()
        {
            List<List<Pixel>> imageMap = GetImagePixelMap();
            List<List<byte>> brightnessMap = ConvertToGrayscale(imageMap);

            return brightnessMap;
        }


        private List<List<Pixel>> GetImagePixelMap()
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

        private List<List<byte>> ConvertToGrayscale(List<List<Pixel>> colorPixelMap)
        {
            List<List<byte>> GrayscalePixelMap = new List<List<byte>>();

            foreach(List<Pixel> pixelRow in colorPixelMap)
            {
                List<byte> grayscalePixelRow = new List<byte>();

                foreach(Pixel pixel in pixelRow)
                {
                    // Good values for the human eye.
                    double brightness = 0.2126 * pixel.Red + 0.7152 * pixel.Green + 0.0722 * pixel.Blue;
                    byte roundBrightness = Convert.ToByte(Math.Round(brightness));

                    grayscalePixelRow.Add(roundBrightness);
                }

                GrayscalePixelMap.Add(grayscalePixelRow);
            }

            return GrayscalePixelMap;
        } 
    }
}
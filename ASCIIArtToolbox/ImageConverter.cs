namespace ASCIIArtToolbox
{
    public class ImageConverter
    {
        private List<List<Pixel>> image;
        private int[] convertedImageSize;


        public ImageConverter(List<List<Pixel>> image, int[] convertedImageSize)
        {
            this.image = image;
            this.convertedImageSize = convertedImageSize;
        }


        public List<List<byte>> ConvertToGrayscale()
        {
            List<List<byte>> GrayscalePixelMap = new List<List<byte>>();

            foreach (List<Pixel> pixelRow in image)
            {
                List<byte> grayscalePixelRow = new List<byte>();

                foreach (Pixel pixel in pixelRow)
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


        public List<List<byte>> GenerateASCIIimage()
        {
            throw new NotImplementedException();
        }


        private char ConvertPixelValueToCharacter(byte pixelValue)
        {
            throw new NotImplementedException();
        }
    }
}
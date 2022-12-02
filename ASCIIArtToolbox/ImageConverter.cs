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
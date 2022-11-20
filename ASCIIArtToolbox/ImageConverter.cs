namespace ASCIIArtToolbox
{
    public class ImageConverter
    {
        private int image;
        private int[] convertedImageSize;


        public ImageConverter(int image, int[] convertedImageSize)
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
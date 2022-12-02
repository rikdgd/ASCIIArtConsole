namespace ASCIIArtToolbox
{
    public class ImageConverter
    {
        private List<List<Pixel>> image;
        private int[] convertedImageSize;

        private static List<char> imageCharacterMapping = new List<char>
        {
            ' ',
            '.',
            '-',
            '+',
            '+',
            '*',
            'X',
            '#',
        };


        public ImageConverter(List<List<Pixel>> image, int[] convertedImageSize)
        {
            this.image = image;
            this.convertedImageSize = convertedImageSize;
        }


        public List<List<byte>> GetImageBrightnessMap()
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


        public List<List<char>> GenerateASCIIimage()
        {
            List<List<char>> ASCIIimageMap = new List<List<char>>();
            List<List<byte>> imageBrigntessMap = GetImageBrightnessMap();

            foreach (List<byte> imageMapRow in imageBrigntessMap)
            {
                List<char> imageRow = new List<char>();

                foreach (byte pixelBrightness in imageMapRow)
                {
                    char pixelChar = ConvertPixelBrightnessToCharacter(pixelBrightness);
                    imageRow.Add(pixelChar);
                }

                ASCIIimageMap.Add(imageRow);
            }

            return ASCIIimageMap;
        }


        private char ConvertPixelBrightnessToCharacter(byte pixelValue)
        {
            char pixelCharacter = '0';

            // yeah this is very bad I know
            if (pixelValue <= 31)
            {
                pixelCharacter = imageCharacterMapping[0];
            }
            else if (pixelValue > 31 && pixelValue <= 62)
            {
                pixelCharacter = imageCharacterMapping[1];
            }
            else if (pixelValue > 62 && pixelValue <= 93)
            {
                pixelCharacter = imageCharacterMapping[2];
            }
            else if (pixelValue > 93 && pixelValue <= 124)
            {
                pixelCharacter = imageCharacterMapping[3];
            }
            else if (pixelValue > 124 && pixelValue <= 155)
            {
                pixelCharacter = imageCharacterMapping[4];
            }
            else if (pixelValue > 155 && pixelValue <= 186)
            {
                pixelCharacter = imageCharacterMapping[5];
            }
            else if (pixelValue > 186 && pixelValue <= 217)
            {
                pixelCharacter = imageCharacterMapping[6];
            }
            else if (pixelValue > 217 && pixelValue <= 255)
            {
                pixelCharacter = imageCharacterMapping[7];
            }

            return pixelCharacter;
        }
    }
}
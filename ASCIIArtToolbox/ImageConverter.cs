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
                    // yeah this is very bad I know
                    if (pixelBrightness <= 31)
                    {
                        imageRow.Add(imageCharacterMapping[0]);
                    }
                    else if (pixelBrightness > 31 && pixelBrightness <= 62)
                    {
                        imageRow.Add(imageCharacterMapping[1]);
                    }
                    else if (pixelBrightness > 62 && pixelBrightness <= 93)
                    {
                        imageRow.Add(imageCharacterMapping[2]);
                    }
                    else if (pixelBrightness > 93 && pixelBrightness <= 124)
                    {
                        imageRow.Add(imageCharacterMapping[3]);
                    }
                    else if (pixelBrightness > 124 && pixelBrightness <= 155)
                    {
                        imageRow.Add(imageCharacterMapping[4]);
                    }
                    else if (pixelBrightness > 155 && pixelBrightness <= 186)
                    {
                        imageRow.Add(imageCharacterMapping[5]);
                    }
                    else if (pixelBrightness > 186 && pixelBrightness <= 217)
                    {
                        imageRow.Add(imageCharacterMapping[6]);
                    }
                    else if (pixelBrightness > 217 && pixelBrightness <= 255)
                    {
                        imageRow.Add(imageCharacterMapping[7]);
                    }
                    else
                    {
                        imageRow.Add('0');
                    }
                }

                ASCIIimageMap.Add(imageRow);
            }

            return ASCIIimageMap;
        }


        private char ConvertPixelValueToCharacter(byte pixelValue)
        {
            throw new NotImplementedException();
        }
    }
}
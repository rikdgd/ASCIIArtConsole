using ASCIIArtToolbox;
using System;
using System.Drawing;
using ImageConverter = ASCIIArtToolbox.ImageConverter;

namespace ASCIIArtConsole
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the image you want to convert to ASCII: ");
            string ?imagePath = Console.ReadLine();
            Console.WriteLine("\n");

            Bitmap transformedImage = ImageTransformer.ResizeFitConsole(ImageReader.GetBitmapImage(imagePath));
            
            List<List<Pixel>> imageMap = ImageReader.GetImagePixelMap(transformedImage);

            ImageConverter imageConverter = new ImageConverter(imageMap);
            List<List<char>> asciiImageMap = imageConverter.GenerateASCIIimage();

            ASCIIFormatter asciiFormatter = new ASCIIFormatter(asciiImageMap);
            string imageString = asciiFormatter.ConvertToASCIIstring();
            Console.WriteLine(imageString);
            Console.WriteLine("\n");

            Console.Read();
        }
    }
}
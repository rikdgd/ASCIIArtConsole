using ASCIIArtToolbox;
using System;

namespace ASCIIArtConsole
{
    internal class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the image you want to convert to ASCII: ");
            string ?imagePath = Console.ReadLine();
            Console.WriteLine("\n");

            ImageReader imageReader = new ImageReader(imagePath);
            //ImageReader imageReader = new ImageReader("./images/buurman.png"); //windows
            // ImageReader imageReader = new ImageReader("./bin/Debug/net6.0/images/buurman.png"); //linux
            List<List<Pixel>> imageMap = imageReader.GetImagePixelMap();

            ImageConverter imageConverter = new ImageConverter(imageMap, new int[2] { 200, 200 });
            List<List<byte>> brightnessMap = imageConverter.GetImageBrightnessMap();
            List<List<char>> asciiImageMap = imageConverter.GenerateASCIIimage();

            ASCIIFormatter asciiFormatter = new ASCIIFormatter(asciiImageMap);
            string imageString = asciiFormatter.ConvertToASCIIstring();
            Console.WriteLine(imageString);
            Console.WriteLine("\n");
        }
    }
}
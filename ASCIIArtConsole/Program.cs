using ASCIIArtToolbox;
using System;

namespace ASCIIArtConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageReader imageReader = new ImageReader("./images/buurman.png");
            List<List<Pixel>> imageMap = imageReader.GetImagePixelMap();

            ImageConverter imageConverter = new ImageConverter(imageMap, new int[2] { 200, 200 });
            List<List<byte>> brightnessMap = imageConverter.GetImageBrightnessMap();
            List<List<char>> asciiImageMap = imageConverter.GenerateASCIIimage();


            foreach (char i in asciiImageMap[20])
            {
                Console.Write(i);
            }

            Console.WriteLine("\npixels: " + brightnessMap[0].Count());
        }
    }
}
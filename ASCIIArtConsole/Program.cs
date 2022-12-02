using ASCIIArtToolbox;
using System;

namespace ASCIIArtConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageReader imageReader = new ImageReader("./images/buurman.png");
            List<List<byte>> brightnessMap = imageReader.GetImageBrightnessMap();
            
            foreach(int i in brightnessMap[0])
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\npixels: " + brightnessMap[0].Count());
        }
    }
}
using ASCIIArtToolbox;
using System;

namespace ASCIIArtConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageReader imageReader = new ImageReader("./images/buurman.png");
            // var image = imageReader.LoadImage();
            Console.WriteLine("image read done");
        }
    }
}
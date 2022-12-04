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

            Console.WriteLine("Do you want the image to fit the console? (y/n)");
            string fitScreen = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Enter location to write to: (leave blank for none)");
            string saveLocation = Console.ReadLine();

            Console.Clear();

            Bitmap image = ImageReader.GetBitmapImage(imagePath);

            if (fitScreen == "y" || fitScreen == "Y")
            {
                Bitmap transformedImage = ImageTransformer.PrepareForASCII(image, true);
                image = transformedImage;
            }
            else
            {
                Bitmap transformedImage = ImageTransformer.PrepareForASCII(image, false);
                image = transformedImage;
            }

            
            List<List<Pixel>> imageMap = ImageReader.GetImagePixelMap(image);

            ImageConverter imageConverter = new ImageConverter(imageMap);
            List<List<char>> asciiImageMap = imageConverter.GenerateASCIIimage();

            ASCIIFormatter asciiFormatter = new ASCIIFormatter(asciiImageMap);
            string imageString = asciiFormatter.ConvertToASCIIstring();
            Console.WriteLine(imageString);
            Console.WriteLine("\n");

            // Write the string to a new file
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(saveLocation, "ASCII-Art.txt")))
            {
               outputFile.WriteLine(imageString);
            }

            Console.Read();
        }
    }
}
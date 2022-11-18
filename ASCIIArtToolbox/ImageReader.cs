using System.Drawing;

namespace ASCIIArtToolbox
{
    public class ImageReader
    {
        private string imagePath;

        public ImageReader(string imagePath)
        {
            this.imagePath = imagePath;
        }

        public Image loadImage()
        {
            Image image = Image.FromFile(imagePath);
            return image;
        }
    }
}

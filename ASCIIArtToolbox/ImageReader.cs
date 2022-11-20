using System.Drawing;

namespace ASCIIArtToolbox
{
    public class ImageReader
    {
        private string imagePath;
        private Image ?image;
        private bool readSuccesful;

        public ImageReader(string imagePath)
        {
            this.imagePath = imagePath;
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                this.image = Image.FromFile(imagePath);
                this.readSuccesful = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.readSuccesful = false;
            }
        }

        private byte GetPixelValue(Pixel pixel)
        {
            throw new NotImplementedException();
        }

        private List<List<Pixel>> GetImagePixelMap()
        {
            // uses prop image
            throw new NotImplementedException();
        }
    }
}

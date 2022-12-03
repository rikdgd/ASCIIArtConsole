namespace ASCIIArtToolbox
{
    public class ASCIIFormatter
    {
        private List<List<char>> asciiImageMap;

        public ASCIIFormatter (List<List<char>> asciiImageMap)
        {
            this.asciiImageMap = asciiImageMap;
        }

        public string ConvertToASCIIstring ()
        {
            string asciiString = "";

            foreach (List<char> imageRow in asciiImageMap)
            {
                foreach (char asciiChar in imageRow)
                {
                    asciiString += asciiChar;
                }

                asciiString += "\n";
            }

            return asciiString;
        }
    }
}

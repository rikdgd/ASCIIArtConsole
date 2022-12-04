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

        public List<string> ConvertToASCIIstringList()
        {
            List<string> asciiImageMapping = new List<string>();

            foreach (List<char> imageRow in asciiImageMap)
            {
                string asciiRow = "";
                foreach (char asciiChar in imageRow)
                {
                    asciiRow += asciiChar;
                }

                asciiImageMapping.Add(asciiRow);
            }

            return asciiImageMapping;
        }
    }
}

namespace syntple.core.xml
{
    public class XmlOperationOptions
    {
        public string FilePath { get; set; }
        public bool Overwrite { get; set; } = false;
        public List<string>? Exclude { get; set; } = new List<String>();
        public bool Verbose { get; set; } = false;
        public string key { get; set; }

        // Costruttore per inizializzare le opzioni
        public XmlOperationOptions(string filePath, String key)
        {
            this.FilePath = filePath;
            this.key = key;
        }
    }
}

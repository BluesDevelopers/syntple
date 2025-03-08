namespace syntple.core.consolecommon.helptext
{
    public class HelpTextOptions
    {
        public int HelpTextLength { get; set; }
        public int HelpTextIndentLength { get; set; }
        public IEnumerable<string> HelpCommands { get; set; }
        public HelpTextOptions(int helpTextLength, int helpTextIndentLength, IEnumerable<string> helpCommands)
        {
            HelpTextLength = helpTextLength;
            HelpTextIndentLength = helpTextIndentLength;
            HelpCommands = helpCommands;
        }
    }
}

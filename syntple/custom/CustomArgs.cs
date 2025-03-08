using syntple.core.consolecommon;
using syntple.core.consolecommon.helptext;

namespace syntple.custom
{
    public class CustomArgs : ParamsObject
    {
        /// <summary>
        /// Custom parameter to pass console shell to execute encrypt or decrypt file xml
        /// </summary>
        /// <param name="args"></param>
        public CustomArgs(string[] args) : base(args)
        {

        }

        [Switch("S", true)]
        [SwitchHelpText("Set source path or path and file to process files or file")]
        public String sourcePathFile { get; set; }

        [Switch("D")]
        [SwitchHelpText("Set if you wont decrypt xml after protect it remember custom key if not use default")]
        public bool isDecrypt { get; set; } = false;
    
        [Switch("L")]
        [SwitchHelpText("Set list for key in xml to exclude to protect value alla tag must be separate with comma without space")]
        public String listNameExcludeProtect { get; set; }

        [Switch("F")]
        [SwitchHelpText("Set filename with list for all tag to exclude from protect")]
        public String fileNameExcludeProtect { get; set; }

        [Switch("R")]
        [SwitchHelpText("Set if save a new file with prefix NEW_ from source or override original file")]
        public bool rewriteFile { get; set; } = false;

        [Switch("K")]
        [SwitchHelpText("Set custom key (32 byte) to protect value in xml file Example: 6f4e8c91f24a6c2d0a8f6e2b9f4a3c1240e830d29c3b072b4c90708a1e62c58f")]
        public string key { get; set; }

        [Switch("V")]
        [SwitchHelpText("Set view in verbose mode")]
        public bool verbose { get; set; } = false;

        [HelpText(0)]
        public string Description
        {
            get { return "Protect xml file value for privacy with more options."; }
        }
        [HelpText(1, "Example")]
        public string ExampleText
        {
            get { return @"This is an example: syntple.exe /S:C:\xml\xmltoprotect.xml /V:T"; }
        }

        [HelpText(2)]
        public override string Usage
        {
            get { return base.Usage; }
        }
        [HelpText(3, "Parameters")]
        public override string SwitchHelp
        {
            get { return base.SwitchHelp; }
        }
    }
}

using syntple.core.funny;
using syntple.core.xml;
using syntple.custom;

namespace syntple
{

    internal class Program
    {
        private const String copyright = "(c) BluesDeveloper Tutti i diritti sono riservati.";
        private const String KEY = "12345678901234567890123456789012";
        static void Main(string[] args)
        {
            CustomArgs? _customArg = null;
            try
            {

                _customArg = new CustomArgs(args);
                _customArg.CheckParams();
                string _helptext = _customArg.GetHelpIfNeeded();
                //Print help to console if requested
                if (!string.IsNullOrEmpty(_helptext))
                {

                    Console.WriteLine(copyright);
                    Console.WriteLine(_helptext);
                    Environment.Exit(0);
                }
                List<String> exclude = new List<string>();
                String fileExclude = _customArg.fileNameExcludeProtect;
                if (!String.IsNullOrWhiteSpace(fileExclude))
                {
                    if (!fileExclude.Contains(@"\"))
                    {
                        fileExclude = string.Concat(Directory.GetCurrentDirectory(), "\\", fileExclude);
                    }
                    if (File.Exists(fileExclude))
                    {
                        exclude = File.ReadAllLines(fileExclude).ToList<String>();
                    }
                }

                String listExclude = _customArg.listNameExcludeProtect;
                if (!string.IsNullOrWhiteSpace(listExclude))
                {
                        exclude.AddRange(listExclude.Split(",").ToList<String>());
                }

                String key = KEY;
                if (!String.IsNullOrWhiteSpace(_customArg.key))
                {
                    key = _customArg.key;
                }

                var options = new XmlOperationOptions(_customArg.sourcePathFile, key)
                {
                    Overwrite = _customArg.rewriteFile,
                    Exclude = exclude,
                    Verbose = _customArg.verbose
                };
                if (!_customArg.isDecrypt)
                {
                    XmlEncryptor.EncryptXmlValues(options);
                }
                else
                {
                    XmlEncryptor.DecryptXmlValues(options);
                }

                Pleasure.homerohh();

            }
            catch (Exception exc)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {exc.Message}");
                if (_customArg != null && _customArg.verbose)
                {
                    Console.WriteLine($"Stack: {exc.StackTrace}");
                    Console.WriteLine($"Source: {exc.Source}");
                }
                else
                {
                    Console.WriteLine("Incorrect command syntax.");                    
                    Console.WriteLine($"Help list command with {string.Join(" ", _customArg?.HelpCommands)}");
                }
                Console.ResetColor();
                Environment.Exit(-1);
            }
        }

    }

}

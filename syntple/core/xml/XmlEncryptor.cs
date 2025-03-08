using System.Xml.Linq;
using syntple.core.utils;

namespace syntple.core.xml
{
    public class XmlEncryptor
    {
        /// <summary>
        /// Encrypt file xml with passed key 32 bit
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        public static void EncryptXmlValues(XmlOperationOptions options)
        {
            // Carica il documento XML
            XDocument xDoc = XDocument.Load(options.FilePath);
            String key = options.key;
            startLog(options);
            if (xDoc.Root != null)
            {
                // Cripta tutti i valori dei nodi
                EncryptXmlElements(xDoc.Root, key, options.Exclude);

                // Salva il file XML modificato
                String onlyFileName = FileUtility.getFileName(options.FilePath);
                String fileName = options.FilePath;
                if (options.Overwrite)
                {
                    fileName = options.FilePath.Replace(onlyFileName, $"NEW_{onlyFileName}");
                }
                xDoc.Save(fileName);
                endLog(options, fileName);
            }
        }

        /// <summary>
        /// Dencrypt file xml with passed key 32 bit
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        public static void DecryptXmlValues(XmlOperationOptions options)
        {
            // Carica il documento XML
            XDocument xDoc = XDocument.Load(options.FilePath);
            String key = options.key;
            startLog(options);

            // Decripta tutti i valori dei nodi
            if (xDoc.Root != null)
            {
                DecryptXmlElements(xDoc.Root, key, options.Exclude);
                // Salva il file XML con i valori decriptati
                // Salva il file XML modificato
                String onlyFileName = FileUtility.getFileName(options.FilePath);
                String fileName = options.FilePath;
                if (options.Overwrite)
                {
                    fileName = options.FilePath.Replace(onlyFileName, $"NEW_{onlyFileName}");
                }
                xDoc.Save(fileName);
                endLog(options, fileName);
            }
        }

        /// <summary>
        /// Log on console ending operation
        /// </summary>
        /// <param name="options"></param>
        /// <param name="fileName"></param>
        private static void endLog(XmlOperationOptions options, string fileName)
        {
            if (options.Verbose)
            {
                Console.WriteLine($"End operation file and write {fileName}");
            }
        }

        /// <summary>
        /// Log on console starting operation
        /// </summary>
        /// <param name="options"></param>
        private static void startLog(XmlOperationOptions options)
        {
            if (options.Verbose)
            {
                Console.WriteLine($"Start operation file {options.FilePath}");
                if (options.Exclude != null)
                {
                    Console.WriteLine($"exclude this tag from operation {string.Join(" ", options.Exclude)}");
                }
            }
        }


        /// <summary>
        /// Encrypt element with key recorsive on node
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        private static void EncryptXmlElements(XElement element, string key, List<String> exludes)
        {

            if (element.HasAttributes)
            {
                // Cripta tutti gli attributi dell'elemento
                foreach (var attribute in element.Attributes())
                {
                    if (!attribute.IsNamespaceDeclaration)
                    {
                        if(!exludes.Contains(attribute.Name.LocalName))
                        {
                            attribute.Value = EncrypString.encrypt(attribute.Value, key);
                        }
                    }
                }
            }

            // Se l'elemento ha dei valori (testo), crittografalo
            if (element.HasElements)
            {
                // Se ha figli, ricorri sugli altri nodi
                foreach (var childElement in element.Elements())
                {
                    EncryptXmlElements(childElement, key, exludes);
                }
            }
            else
            {
                // Criptografa il valore del nodo
                if (!exludes.Contains(element.Name.LocalName))
                {
                    element.Value = EncrypString.encrypt(element.Value, key);
                }
            }

        }

        /// <summary>
        /// Dencrypt element with key recorsive on node
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        private static void DecryptXmlElements(XElement element, string key, List<String> exludes)
        {

            if (element.HasAttributes)
            {
                // Decripta tutti gli attributi dell'elemento
                foreach (var attribute in element.Attributes())
                {
                    if (!attribute.IsNamespaceDeclaration)
                    {
                        if (!exludes.Contains(attribute.Name.LocalName))
                        {
                            attribute.Value = EncrypString.decrypt(attribute.Value, key);
                        }
                    }
                }
            }

            // Se l'elemento ha dei valori (testo), decriptalo
            if (element.HasElements)
            {
                // Se ha figli, ricorri sugli altri nodi
                foreach (var childElement in element.Elements())
                {
                    DecryptXmlElements(childElement, key, exludes);  // Chiamata ricorsiva per i figli
                }
            }
            else
            {
                if (!exludes.Contains(element.Name.LocalName))
                {
                    // Decripta il valore del nodo
                    element.Value = EncrypString.decrypt(element.Value, key);
                }
            }
        }
    }
}

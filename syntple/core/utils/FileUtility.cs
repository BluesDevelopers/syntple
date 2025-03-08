namespace syntple.core.utils
{
    public class FileUtility
    {
        /// <summary>
        /// Extract file name without extension from path return file with \\
        /// </summary>
        /// <param name="pathAndFile"></param>
        /// <returns></returns>
        public static string getOnlyFileName(String pathAndFile)
        {
            String fileame = getExtractFileName(pathAndFile);
            String extension = getExtensionFile(pathAndFile);
            return fileame.Replace("." + extension, "");
        }

        /// <summary>
        /// Extract file name from path return file with \\
        /// </summary>
        /// <param name="pathAndFile"></param>
        /// <returns></returns>
        public static string getExtractFileName(String pathAndFile)
        {
            int index = pathAndFile.LastIndexOf(@"\") + 1;
            return pathAndFile.Substring(index, (pathAndFile.Length - index));
        }
        /// <summary>
        /// Get only a file name with extension
        /// </summary>
        /// <param name="pathAndFile"></param>
        /// <returns></returns>
        public static string getFileName(String pathAndFile)
        {
            String fileName = getExtractFileName(pathAndFile);
            return fileName.Replace(@"\", "");
        }

        /// <summary>
        /// Get full path of file without file 
        /// </summary>
        /// <param name="pathAndFile"></param>
        /// <returns>all path and finish with <path of file >/ </returns>
        public static string getExtractPath(String pathAndFile)
        {
            return pathAndFile.Substring(0, pathAndFile.LastIndexOf(@"\"));
        }

        /// <summary>
        /// Return extension of file if is not present return null
        /// </summary>
        /// <param name="pathAndFile"></param>
        /// <returns></returns>
        public static string getExtensionFile(String pathAndFile)
        {
            String file = getExtractFileName(pathAndFile).Replace(@"\", "");
            if (file.LastIndexOf(@".") > 0)
                return file.Substring(file.LastIndexOf(@".") + 1);
            return null;
        }

    }
}

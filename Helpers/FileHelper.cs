using System.IO;
using TinyPNG.AppConstants;

namespace TinyPNG.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Check if file is already in the compressed file log.
        /// </summary>
        /// <param name="file">file path</param>
        /// <returns>true or false</returns>
        public static bool IsCompressed(string file)
        {
            // file name taken out of the file's path
            var fileName = Path.GetFileName(file);

            // if compression log file exists, see if the file exists
            // in the compression log. 
            if (File.Exists(Config.FileLogPath))
            {
                foreach (var loggedFile in File.ReadLines(Config.FileLogPath))
                {
                    if (loggedFile.Equals(fileName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

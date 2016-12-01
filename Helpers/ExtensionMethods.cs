using System.Collections.Generic;
using System.IO;
using TinyPNG.Models;

namespace TinyPNG.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Only grab files that have png, gif, or jpg extensions. Also narrow
        /// down list to those that have NOT been compressed yet.
        /// </summary>
        /// <param name="filesPaths">IEnumerable string of files</param>
        /// <returns>List of FileModel files</returns>
        public static List<FileModel> FilterFiles(this string[] filesPaths)
        {
            var fileList = new List<FileModel>();

            // 1) Check every file path to see if the image has already been compressed
            // 2) Make sure file is PNG or JPG
            // 3) Create FileModel and assign properties, add to list
            foreach (var filePath in filesPaths)
            {
                if (!FileHelper.IsCompressed(filePath))
                {
                    if (filePath.EndsWith("png") || filePath.EndsWith("jpg"))
                    {
                        var file = new FileModel()
                        {
                            FileName = Path.GetFileName(filePath),
                            FileSize = File.ReadAllBytes(filePath).Length / 1000,
                            FileType = Path.GetExtension(filePath).ToUpper(),
                            Path = Path.GetFullPath(filePath)
                        };

                        fileList.Add(file);
                    }
                }
            }

            return fileList;
        }
    }
}

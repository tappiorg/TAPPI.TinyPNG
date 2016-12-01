using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyPNG.Models
{
    /// <summary>
    /// File properties and data
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// Name of file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// File type (jpg or png)
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// File size
        /// </summary>
        public long FileSize { get;set; }
        /// <summary>
        /// Full path of file (i.e. C:\Full\Path\image.jpg)
        /// </summary>
        public string Path { get; set; }
    }
}

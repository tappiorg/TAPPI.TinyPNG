#region using
using System.Net;
using TinyPNG.Models;
#endregion

namespace TinyPNG.Logger
{
    /// <summary>
    /// Logger interface
    /// </summary>
    interface ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        void FileRecordLog(FileModel file);
        void DetailedFileLog(FileModel file);
        void ErrorLog(WebException e);
        void OptimizationLog(long before, long after);
    }
}
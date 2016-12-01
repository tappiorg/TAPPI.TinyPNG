#region using
using System.Configuration;
#endregion

namespace TinyPNG.AppConstants
{
    /// <summary>
    /// Exposes appsettings values for oft-used application values.
    /// </summary>
    public static class Config
    {
        #region Public Static Fields
        /// <summary>
        /// TinyPNY API Key
        /// </summary>
        public static string TinyPngApiKey = ConfigurationManager.AppSettings["TinyPNGKey"];
        /// <summary>
        /// TinyPNG API Url for image compression
        /// </summary>
        public static string CompressUrl = ConfigurationManager.AppSettings["CompressUrl"];
        /// <summary>
        /// Path for event microsite media folder
        /// </summary>
        public static string EventsPath = ConfigurationManager.AppSettings["EventsDev"];
        /// <summary>
        /// Default detailed logging path for each server **defaults to c:/TAPPI/Logs/TinyPNG-compressed.txt**
        /// </summary>
        public static string DetailedLogPath = ConfigurationManager.AppSettings["DetailedLogPath"];
        /// <summary>
        /// Default file log path **c:/TAPPI/Logs/TinyPNG-compression-detailed.txt**
        /// </summary>
        public static string FileLogPath = ConfigurationManager.AppSettings["FileLogPath"];
        /// <summary>
        /// Default error log path **c:/TAPPI/Logs/TinyPNG-error.txt**
        /// </summary>
        public static string ErrorLogPath = ConfigurationManager.AppSettings["ErrorLog"];
        /// <summary>
        /// Default optimization report log path **c:/TAPPI/Logs/TinyPNG-optimization.txt**
        /// </summary>
        public static string OptimizationLog = ConfigurationManager.AppSettings["OptimizationReportLog"];
        #endregion
    }
}

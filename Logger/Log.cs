using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TinyPNG.Models;

namespace TinyPNG.Logger
{
    public static class Log
    {
        public static void FileRecordLog(FileModel file)
        {
            new LogUtility().FileRecordLog(file);
        }

        public static void DetailedFileLog(FileModel file)
        {
            new LogUtility().DetailedFileLog(file);
        }

        public static void ErrorLog(WebException e)
        {
            new LogUtility().ErrorLog(e);
        }

        public static void OptimizationLog(long before, long after)
        {
            new LogUtility().OptimizationLog(before, after);
        }
    }
}

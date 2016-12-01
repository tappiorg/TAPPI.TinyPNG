using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TinyPNG.AppConstants;
using TinyPNG.Models;

namespace TinyPNG.Logger
{
    public class LogUtility : ILogger
    {
        public void FileRecordLog(FileModel file)
        {
            using (StreamWriter sw = File.AppendText(Config.FileLogPath))
            {
                sw.WriteLine(file.FileName);
            }
        }

        public void DetailedFileLog(FileModel file)
        {
            using (StreamWriter sw = File.AppendText(Config.DetailedLogPath))
            {
                sw.WriteLine(string.Format("{0} - {1} of type {2} - {3}KB - FULL PATH: {4}", DateTime.Now, file.FileName, file.FileType, file.FileSize, file.Path));
            }
        }

        public void ErrorLog(WebException e)
        {
            Stream stream = e.Response.GetResponseStream();
            using (StreamWriter sw = File.AppendText(Config.ErrorLogPath))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    sw.WriteLine(DateTime.Now + " - " + sr.ReadToEnd());
                }
                
            }
        }

        public void OptimizationLog(long before, long after)
        {
            using (StreamWriter sw = File.AppendText(Config.OptimizationLog))
            {
                sw.WriteLine(string.Concat("*****", DateTime.Now, "*****"));
                sw.WriteLine(string.Concat("Before: ", before));
                sw.WriteLine(string.Concat("After: ", after));
                sw.WriteLine(string.Concat("TOTAL SIZE SAVED: ", (before - after) / 1000, "MB"));
                sw.WriteLine("********************************************************************");
            }
        }
    }
}

#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TinyPNG.AppConstants;
using TinyPNG.Helpers;
using TinyPNG.Logger;
using TinyPNG.Models;
#endregion

namespace TinyPNG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enumerate & filter files
            var files = Directory.GetFiles(Config.EventsPath, "*.*", SearchOption.AllDirectories).FilterFiles();

            // set counters
            long totalFileSize = 0;
            long newTotalFileSize = 0;
            int count = 0;

            // create empty success list
            var successList = new List<FileModel>();

            //Start client
            WebClient client = new WebClient();
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Concat("api:", Config.TinyPngApiKey)));
            client.Headers.Add(HttpRequestHeader.Authorization, string.Concat("Basic ", auth));
            Console.WriteLine(files.Count);

            // run through every file in the list
            foreach (var file in files.Take(25))
            {
                //record total file size
                totalFileSize += file.FileSize;

                // set output file to same path
                var output = file.Path;

                // Execute upload, compression, and download of file
                try
                {
                    client.UploadData(Config.CompressUrl, File.ReadAllBytes(file.Path));
                    client.DownloadFile(client.ResponseHeaders["Location"], output);
                    successList.Add(file);
                    // New file size
                    newTotalFileSize += File.ReadAllBytes(file.Path).LongLength / 1000;
                    count++;
                    Console.WriteLine("Finished " + file.FileName + " - " + file.FileSize + "KB - " + "#" + count + " *AFTER* " + (File.ReadAllBytes(file.Path).LongLength) / 1000 + "KB");
                    // Log results
                    Log.FileRecordLog(file);
                    Log.DetailedFileLog(file);
                }
                catch (WebException e)
                {
                    // log error
                    Log.ErrorLog(e);
                }
            }

            Log.OptimizationLog(totalFileSize, newTotalFileSize);

            Console.ReadLine();
        }
    }
}

using System;
using System.Diagnostics;
using System.Net;

namespace DownloadHtmlStr
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine(_ramCounter.NextValue());
           
                var webRequest = HttpWebRequest.Create("https://www.simbirsoft.com//");
                webRequest.Method = "HEAD";
                var webResponse = webRequest.GetResponse();
            Console.WriteLine("\nThe following headers were received in the response");

            // Display each header and it's key , associated with the response object.
            for (int i = 0; i < webResponse.Headers.Count; ++i)
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", webResponse.Headers.Keys[i], webResponse.Headers[i]);

            // Release resources of response object.
            webResponse.Close();
            //    var fileSize = webResponse.Headers.Get("Content-Length");
            //Console.WriteLine(fileSize);
            //    var fileSizeInMegaByte = Math.Round(Convert.ToDouble(fileSize), 2);
            //    Console.WriteLine(fileSizeInMegaByte + " KB");


            // Console.WriteLine(GC.GetTotalMemory(false));
            //_ = new LoadingHtml("https://samara.itstep.org/");
            //if (LoadingHtml.GetFile())
            //{
            //   _ = new WordsCountStatistics(ClearingFromTags.ClearText());
            //    WordsCountStatistics.ShowDictionary();
            //}
        }
    }
}

using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace DownloadHtmlStr
{
    /// <summary>
    /// класс LoadingHtml загружает страницу html в текстовый файл
    /// </summary>

    class LoadingHtml
    {
        public static string nameFile = "update.txt";
        private Uri adressUrl;

        public LoadingHtml(string adressUrlFromUser)
        {
            adressUrl = new Uri(adressUrlFromUser);
        }

        public bool GetFile()
        {
            WebClient client = new WebClient();
            try
            {
                bool didIt = false;
                if (File.Exists(nameFile))
                {
                    File.Delete(nameFile); 
                }
                    var ramCounter = GetRamCounter();
                    var contentLengthHtml = GetContentLengthHtml();
                    try
                    {
                        if (ramCounter > contentLengthHtml)
                            client.DownloadFile(adressUrl, nameFile);
                        didIt = true;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("in download ram");
                        Console.WriteLine("Exception: " + e.Message);
                        didIt = false;
                    }
                return didIt;
            }
            catch (Exception e)
            {
                Console.WriteLine("in download");
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }

        private float GetContentLengthHtml()
        {
            var webRequest = HttpWebRequest.Create(adressUrl);
            webRequest.Method = "HEAD";
            var webResponse = webRequest.GetResponse();
            string str = webResponse.Headers.Get("Content-Length");
            if (str == null) return 0;
            else return float.Parse(webResponse.Headers.Get("Content-Length"));
        }

        private float GetRamCounter()
        {
            PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available Bytes");
            return _ramCounter.NextValue();
        }
    }
}

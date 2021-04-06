using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace DownloadHtmlStr
{
    class LoadingHtml                                                        // класс загружает страницу html в текстовый файл
    {
        private static Uri adressUrl;
        public static string nameFile = "update.txt";

        public LoadingHtml(string adressUrlFromUser)
        {
            adressUrl = new Uri(adressUrlFromUser);
        }

        private static float GetContentLengthHtml()
        {
            var webRequest = HttpWebRequest.Create(adressUrl);
            webRequest.Method = "HEAD";
            var webResponse = webRequest.GetResponse();
            return float.Parse(webResponse.Headers.Get("Content-Length"));
        }

        private static float GetRamCounter()
        {
            PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available Bytes");
            return _ramCounter.NextValue();
        }

        private static void ReadByLine()
        {
            
        }
        public static bool GetFile()                                                 //получение и скачивание файла в документ .txt
        {
            WebClient client = new WebClient();
            try
            {
                if (!File.Exists(nameFile))
                {
                    var ramCounter = GetRamCounter();                               //получение данных о свободной RAM
                    var contentLengthHtml = GetContentLengthHtml();                 //получение данных об объеме скачиваемого документа
                    try
                    {
                        if (ramCounter > contentLengthHtml) client.DownloadFileAsync(adressUrl, nameFile);
                        else
                        {
                            ReadByLine();                                          //запись по строчно 
                        }
                    }
                    catch(OutOfMemoryException)
                    {
                        ReadByLine();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }
    }
}

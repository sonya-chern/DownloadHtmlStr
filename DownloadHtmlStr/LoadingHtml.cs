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

                        }
                    }
                    catch(OutOfMemoryException)
                    {

                    }
                }
                    
                      

                return true;
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("The path is empty");
                return false;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Could not find file");
                return false;
            }
            
        }
    }
}

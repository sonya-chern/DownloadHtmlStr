using System;
using System.Net;
using System.Web;

namespace DownloadHtmlStr
{
    class Program
    {
        public static bool GetFile(string adress, string name)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(adress,name);
                return true;
            }
            catch
            {
                return false;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

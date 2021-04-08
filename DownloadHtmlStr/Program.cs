using System;

namespace DownloadHtmlStr
{
    class Program
    {
         public static void Main(string[] args)
         {
            string adressUrlFromUser = args[0];
            Console.WriteLine(adressUrlFromUser);

            // для теста string adressUrlFromUser = "https://www.simbirsoft.com/"; 
            LoadingHtml loadingHtml = new LoadingHtml(adressUrlFromUser);
            Console.WriteLine("Start downloading");
            if (loadingHtml.GetFile())
            {
                Console.WriteLine("File has downloaded");
                Console.WriteLine("File is processing...");
                ClearingFromTags clearingFromTags = new ClearingFromTags();
                string clearStr = clearingFromTags.ClearText();
                //Console.WriteLine("Text has cleaned " + clearStr.Length);
                WordsCountStatistics wordsCountStatistics = new WordsCountStatistics(clearStr);
                Console.WriteLine("Statistic:  ");
                wordsCountStatistics.ShowDictionary();
                try
                {
                    MyDataBase myDataBase = new MyDataBase();
                    myDataBase.CreatDataBasesStatistic(wordsCountStatistics.GetDictionary());
                    Console.WriteLine("DataBase is created");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
         }
    }
}

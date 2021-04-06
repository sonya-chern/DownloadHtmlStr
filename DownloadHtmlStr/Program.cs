using System;

namespace DownloadHtmlStr
{
    class Program
    {
         static void Main(string[] args)
        {
            LoadingHtml loadingHtml = new LoadingHtml("https://samara.itstep.org/");
            if (loadingHtml.GetFile())
            {
                ClearingFromTags clearingFromTags = new ClearingFromTags();
                WordsCountStatistics wordsCountStatistics = new WordsCountStatistics(clearingFromTags.ClearText());
                wordsCountStatistics.ShowDictionary();
                try
                {
                    MyDataBase myDataBase = new MyDataBase();
                    myDataBase.CreatDataBasesStatistic(wordsCountStatistics.GetDictionary());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

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
                MyDataBase myDataBase = new MyDataBase();
                myDataBase.CreatDataBasesStatistics(wordsCountStatistics.GetDictionary());
            }
        }
    }
}

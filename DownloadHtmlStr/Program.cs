using System;
using System.Diagnostics;
using System.Net;

namespace DownloadHtmlStr
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new LoadingHtml("https://samara.itstep.org/");
            if (LoadingHtml.GetFile())
            {
                _ = new WordsCountStatistics(ClearingFromTags.ClearText());
                WordsCountStatistics.ShowDictionary();
            }
        }
    }
}

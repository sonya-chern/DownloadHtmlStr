using System;
using System.Collections.Generic;

namespace DownloadHtmlStr
{
    //подсчитывает количество одинаковых слов в видимом тексте и выводит статистику на экран
    class WordsCountStatistics
    {
        private static string onlyText;
        private readonly static char[] charSeparators = { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        private static Dictionary<string, int> wordAndItsRepetition = new Dictionary<string, int>();

        public WordsCountStatistics(string onlyTextFrom)
        {
            onlyText = onlyTextFrom;
        }
        private static void FillingDictionary()
        {
            onlyText = onlyText.ToLower();
            string[] withoutSeparators = onlyText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in withoutSeparators)
            {
                IsItUnique(item, withoutSeparators);
            }
        }
    
        private static Dictionary<string, int> IsItUnique(string forSearch, string[] arrayOfWords)
        {
            var count = 0;
            if (wordAndItsRepetition.ContainsKey(forSearch)) return wordAndItsRepetition;
            else
            {
                foreach (var item in arrayOfWords)
                {
                    if (item == forSearch) count++;
                }
                wordAndItsRepetition.Add(forSearch, count);
                return wordAndItsRepetition;
            }
        }

        public static void ShowDictionary()
        {
            FillingDictionary();
            foreach (KeyValuePair<string, int> keyValue in wordAndItsRepetition)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
    }
}

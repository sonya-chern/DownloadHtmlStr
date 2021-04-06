using System;
using System.Collections.Generic;

namespace DownloadHtmlStr
{
    /// <summary>
    /// класс WordsCountStatistics подсчитывает количество одинаковых слов в видимом тексте и выводит статистику на экран
    /// </summary>

    class WordsCountStatistics
    {
        private string onlyText;
        private readonly char[] charSeparators = { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        private static Dictionary<string, int> wordAndItsRepetition = new Dictionary<string, int>();

        public WordsCountStatistics(string onlyTextFrom)
        {
            onlyText = onlyTextFrom;
        }

        public void ShowDictionary()
        {
            FillingDictionary();
            foreach (KeyValuePair<string, int> keyValue in wordAndItsRepetition)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }

        public Dictionary<string, int> GetDictionary()
        {
            return wordAndItsRepetition;
        }
        private void FillingDictionary()
        {
            onlyText = onlyText.ToLower();
            string[] withoutSeparators = onlyText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in withoutSeparators)
            {
                IsItUnique(item, withoutSeparators);
            }
        }
    
        private void IsItUnique(string forSearch, string[] arrayOfWords)
        {
            var count = 0;
            if (!wordAndItsRepetition.ContainsKey(forSearch))
            {
                foreach (var item in arrayOfWords)
                {
                    if (item == forSearch) 
                        count++;
                }
                wordAndItsRepetition.Add(forSearch, count);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DownloadHtmlStr
{
    /// <summary>
    /// класс ClearingFromTags чистит текст от тегов и возвращает строку текста
    /// </summary>

    class ClearingFromTags
    {
        private readonly Dictionary<string, string> tagsHtml = new Dictionary<string, string>
            {
                {"<script", "</script>"},
                {"<noscript", "</noscript>"},
                {"<body", ">"},
                {"<path", "/>"},
                {"<img", ">"}
            };

        public string ClearText()
        {
            string allText = File.ReadAllText(LoadingHtml.nameFile);
            var withoutHead = allText.Remove(0, allText.IndexOf("<body", StringComparison.InvariantCulture));
            var cleanedText = DeleteWithRegex(withoutHead, "\\s+", " ");
            foreach (KeyValuePair<string, string> item in tagsHtml)
            {
                cleanedText = DeleteBetweenTags(cleanedText, item.Key, item.Value);
            }
            cleanedText = DeleteWithRegex(cleanedText, "<.*?>", "");
            return cleanedText;
        }
        private string DeleteBetweenTags(string withoutTags, string beginTag, string endTag) //удаляет все между заданных тегов
        {
            int findInd, findInd2;
            while (true)
            {
                findInd = withoutTags.IndexOf(beginTag);
                findInd2 = withoutTags.IndexOf(endTag);
                if (findInd != -1 && (findInd2 - findInd) > 0)
                {
                    withoutTags = withoutTags.Remove(findInd, findInd2 - findInd + endTag.Length);
                }
                else break;
            }
            return withoutTags;
        }
        private string DeleteWithRegex(string cleanedSmth, string regx, string toReplace)
        {
            return Regex.Replace(cleanedSmth, regx, toReplace);
        }
    }
}

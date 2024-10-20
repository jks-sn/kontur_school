using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            // Разбиваем начальную фразу на список слов
            var currentPhrase = new List<string>(
                phraseBeginning.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            var result = new StringBuilder(phraseBeginning);

            for (int i = 0; i < wordsCount; i++)
            {
                string key = GetKeyForNextWord(currentPhrase);

                if (!nextWords.TryGetValue(key, out string nextWord))
                    break;

                result.Append(' ').Append(nextWord);
                currentPhrase.Add(nextWord);
            }

            return result.ToString();
        }

        private static string GetKeyForNextWord(List<string> words)
        {
            int count = words.Count;

            if (count >= 2)
                return words[count - 2] + " " + words[count - 1];
            else if (count == 1)
                return words[0];
            else
                return string.Empty; // Обработка случая пустой начальной фразы
        }
    }
}

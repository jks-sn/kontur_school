using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis;
static class TextGeneratorTask
{
    public static string ContinuePhrase(
        Dictionary<string, string> nextWords,
        string phraseBeginning,
        int wordsCount)
    {
        var currentPhrase = new List<string>(
            phraseBeginning.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        var result = new StringBuilder(phraseBeginning);

        for (int i = 0; i < wordsCount; i++)
        {
            string nextWord = GetNextWord(nextWords, currentPhrase);

            if (string.IsNullOrEmpty(nextWord))
                break;

            result.Append(' ').Append(nextWord);
            currentPhrase.Add(nextWord);

            if (currentPhrase.Count > 2)
                currentPhrase.RemoveAt(0);
        }

        return result.ToString();
    }

    private static string GetNextWord(Dictionary<string, string> nextWords, List<string> words)
    {
        int count = words.Count;

        if (count >= 2)
        {
            string bigramKey = words[count - 2] + " " + words[count - 1];
            if (nextWords.TryGetValue(bigramKey, out string nextWord))
                return nextWord;
        }

        if (count >= 1)
        {
            string unigramKey = words[count - 1];
            if (nextWords.TryGetValue(unigramKey, out string nextWord))
                return nextWord;
        }
        return null;
    }
}
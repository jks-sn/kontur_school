using System.Text.RegularExpressions;

namespace TextAnalysis;
static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentenceSeparators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
        return text
            .Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(sentence => Regex.Matches(sentence, @"[a-zA-Z']+")
                .Select(m => m.Value.ToLower())
                .ToList())
            .Where(words => words.Count > 0)
            .ToList();
    }
}
using System.Text;

namespace TextAnalysis;
static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesDelimetrs = ".!?;:()";
        var sentencesList = new List<List<string>>();
        var word = new StringBuilder();
        var sentence = new List<string>();

        foreach (var symbol in text)
        {
            if (char.IsLetter(symbol) || symbol == '\'')
            {
                word.Append(char.ToLower(symbol));
            }
            else if (word.Length > 0)
            {
                sentence.Add(word.ToString());
                word.Clear();
            }

            if (sentencesDelimetrs.Contains(symbol) && sentence.Count > 0)
            {
                sentencesList.Add(sentence);
                sentence = new List<string>();
            }
        }

        if (word.Length > 0)
        {
            sentence.Add(word.ToString());
        }

        if (sentence.Count > 0)
        {
            sentencesList.Add(sentence);
        }
        return sentencesList;
    }
}
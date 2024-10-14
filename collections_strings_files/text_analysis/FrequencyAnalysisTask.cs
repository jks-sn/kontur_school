namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var nGramFrequencies = new SortedDictionary<string, Dictionary<string, int>>(StringComparer.Ordinal);
        foreach (var sentence in text)
        {
            for (int i = 0; i < sentence.Count - 1; i++)
            {
                AddNGram(nGramFrequencies, sentence, i, 1); // Биграммы
                if (i < sentence.Count - 2)
                    AddNGram(nGramFrequencies, sentence, i, 2); // Триграммы
            }
        }

        var result = new Dictionary<string, string>();
        foreach (var nGram in nGramFrequencies)
        {
            var mostFrequentWord = nGram.Value
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key, StringComparer.Ordinal)
                .First().Key;
            result[nGram.Key] = mostFrequentWord;
        }

        return result;
    }

    private static void AddNGram(SortedDictionary<string, Dictionary<string, int>> nGrams, List<string> sentence, int index, int n)
    {
        var nGramKey = string.Join(" ", sentence.Skip(index).Take(n));
        var nextWord = sentence[index + n];

        if (!nGrams.ContainsKey(nGramKey))
            nGrams[nGramKey] = new Dictionary<string, int>(StringComparer.Ordinal);

        if (!nGrams[nGramKey].ContainsKey(nextWord))
            nGrams[nGramKey][nextWord] = 0;
        
        nGrams[nGramKey][nextWord]++;
    }
}
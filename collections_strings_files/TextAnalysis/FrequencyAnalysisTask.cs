namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var nGramFrequencies = new Dictionary<string, Dictionary<string, int>>(StringComparer.Ordinal);
        
        foreach (var sentence in text)
        {
            for (int i = 0; i < sentence.Count - 1; ++i)
            {
                AddNGram(nGramFrequencies, sentence, i, 1); // Биграммы
                if (i < sentence.Count - 2)
                    AddNGram(nGramFrequencies, sentence, i, 2); // Триграммы
            }
        }

        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        
        foreach (var nGram in nGramFrequencies)
        {
            int maxCount = -1;
            string mostFrequentWord = String.Empty;
            foreach (var (word, count) in nGram.Value)
            {
                if (count > maxCount || (count == maxCount && string.CompareOrdinal(word, mostFrequentWord) < 0))
                {
                    maxCount = count;
                    mostFrequentWord = word;
                }
            }
            result[nGram.Key] = mostFrequentWord;
        }
        return result;
    }

    private static void AddNGram(Dictionary<string, Dictionary<string, int>> nGrams, List<string> sentence, int index, int ngrmKeySize)
    {
        string nGramKey = (ngrmKeySize == 1 ? sentence[index] : sentence[index] + " " + sentence[index + 1]);

        string nextWord = sentence[index + ngrmKeySize];

        if (!nGrams.TryGetValue(nGramKey, out var nextWords))
        {
            nextWords = new Dictionary<string, int>(StringComparer.Ordinal);
            nGrams[nGramKey] = nextWords;
        }

        if (nextWords.TryGetValue(nextWord, out int count))
            nextWords[nextWord] = count + 1;
        else
            nextWords[nextWord] = 1;
    }
}
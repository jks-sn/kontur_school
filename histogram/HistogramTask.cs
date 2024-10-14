using System.Linq;

namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var days = Enumerable.Range(1, 31).Select(day => day.ToString()).ToArray();
        
        var birthCounts = new double[31];

        foreach (var person in names.Where(person => person.Name == name && person.BirthDate.Day != 1))
        {
            birthCounts[person.BirthDate.Day - 1]++;
        }
        return new HistogramData($"Рождаемость людей с именем '{name}'", days, birthCounts);
    }
}
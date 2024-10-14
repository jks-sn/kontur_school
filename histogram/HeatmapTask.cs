using System.Linq;

namespace Names;
internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var days = Enumerable.Range(2, 30).Select(day => day.ToString()).ToArray(); 
        var months = Enumerable.Range(1, 12).Select(month => month.ToString()).ToArray(); 
        var birthCounts = new double[30, 12];
        foreach (var person in names.Where(person => person.BirthDate.Day > 1))
        {
            birthCounts[person.BirthDate.Day - 2, person.BirthDate.Month - 1]++;
        }
        return new HeatmapData("Карта интенсивности рождаемости в зависимости от дня и месяца",  birthCounts, days, months);
    }
}
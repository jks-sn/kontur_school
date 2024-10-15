using System;
using System.Collections.Generic;
using System.Linq;
using Names.UI;

namespace Names;
internal static class CreativityTask
{
    public static void ShowAverageNameLengthPerYear(NameData[] names)
    {
        var namesByYear = names
            .GroupBy(n => n.BirthDate.Year)
            .OrderBy(g => g.Key);

        var years = new List<int>();
        var averageNameLengths = new List<double>();

        foreach (var group in namesByYear)
        {
            int year = group.Key;
            double avgLength = group.Average(n => n.Name.Length);

            years.Add(year);
            averageNameLengths.Add(avgLength);
        }

        // Отображаем график
        Charts.ShowLineChart(years.ToArray(), averageNameLengths.ToArray(), "Средняя длина имён по годам");
    }
}
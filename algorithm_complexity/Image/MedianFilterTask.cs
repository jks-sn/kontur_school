using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer;
internal static class MedianFilterTask
{
    public static double[,] MedianFilter(double[,] original)
    {
        var height = original.GetLength(0);
        var width = original.GetLength(1);
        var filtered = new double[height, width];

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var neighborhoods = GetNeighbourhoods(original, x, y);
                var median = CalculateMedian(neighborhoods);
                filtered[y, x] = median;
            }
        }

        return filtered;
    }


    private static List<double> GetNeighbourhoods(double[,] original, int x, int y)
    {
        var height = original.GetLength(0);
        var width = original.GetLength(1);
        
        var neighborhoods = new List<double>();
                
        var yStart = Math.Max(y - 1, 0);
        var yEnd = Math.Min(y + 1, height - 1);
        var xStart = Math.Max(x - 1, 0);
        var xEnd = Math.Min(x + 1, width - 1);
                
        for (var j = yStart; j <= yEnd; j++)
        {
            for (var i = xStart; i <= xEnd; i++)
            {
                neighborhoods.Add(original[j, i]);
            }
        }
        return neighborhoods;
    }

    private static double CalculateMedian(List<double> values)
    {
        values.Sort();
        var count = values.Count;
        if (count % 2 == 1)
        {
            return values[count / 2];
        }
        return (values[count / 2 - 1] + values[count / 2]) / 2.0;
    }
}

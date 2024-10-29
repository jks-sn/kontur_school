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
        double[,] filtered = new double[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var neighborhoods = getNeigbourhoods(original, x, y, width, height);
                double median = CalculateMedian(neighborhoods);
                filtered[y, x] = median;
            }
        }

        return filtered;
    }


    private static List<double> getNeigbourhoods(double[,] original, int x, int y, int width, int height)
    {
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

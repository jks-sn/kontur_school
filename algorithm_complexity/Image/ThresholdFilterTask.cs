using System;
using System.Linq;

namespace Recognizer;

public static class ThresholdFilterTask
{
    public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
    {
        var height = original.GetLength(0);
        var width = original.GetLength(1);
        var totalPixels = height * width;
        var requiredWhite = CalculateRequiredWhitePixels(totalPixels, whitePixelsFraction);

        if (requiredWhite <= 0)
        {
            return CreateAllBlackImage(height, width);
        }

        if (requiredWhite >= totalPixels)
        {
            return CreateAllWhiteImage(height, width);
        }

        var threshold = CalculateThreshold(original, requiredWhite);
        return ApplyThresholdFilter(original, threshold);
    }

    private static int CalculateRequiredWhitePixels(int totalPixels, double whitePixelsFraction)
    {
        return (int)(whitePixelsFraction * totalPixels);
    }

    private static double[,] CreateAllBlackImage(int height, int width)
    {
        return new double[height, width];
    }

    private static double[,] CreateAllWhiteImage(int height, int width)
    {
        var allWhite = new double[height, width];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                allWhite[y, x] = 1.0;
        return allWhite;
    }

    private static double CalculateThreshold(double[,] original, int requiredWhite)
    {
        var allPixelValues = GetAllPixelValues(original);
        Array.Sort(allPixelValues);
        return allPixelValues[allPixelValues.Length - requiredWhite];
    }

    private static double[] GetAllPixelValues(double[,] original)
    {
        int height = original.GetLength(0);
        int width = original.GetLength(1);
        double[] allPixelValues = new double[height * width];
        int index = 0;

        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                allPixelValues[index++] = original[y, x];

        return allPixelValues;
    }

    private static double[,] ApplyThresholdFilter(double[,] original, double threshold)
    {
        int height = original.GetLength(0);
        int width = original.GetLength(1);
        double[,] filtered = new double[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                filtered[y, x] = original[y, x] >= threshold ? 1.0 : 0.0;
            }
        }
        return filtered;
    }
}

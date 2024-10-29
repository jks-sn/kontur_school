using System;

namespace Recognizer;
internal static class SobelFilterTask
{
    public static double[,] SobelFilter(double[,] g, double[,] sx)
    {
        int width = g.GetLength(0);
        int height = g.GetLength(1);
        var result = new double[width, height];
        
        double[,] sy = TransposeMatrix(sx);

        int radius = sx.GetLength(0) / 2;

        for (int x = radius; x < width - radius; x++)
        {
            for (int y = radius; y < height - radius; y++)
            {
                double gx = ApplyKernel(g, sx, x, y, radius);
                double gy = ApplyKernel(g, sy, x, y, radius);

                result[x, y] = Math.Sqrt(gx * gx + gy * gy);
            }
        }

        return result;
    }
    
    private static double[,] TransposeMatrix(double[,] matrix)
    {
        int size = matrix.GetLength(0);
        double[,] transposed = new double[size, size];
        for (int i = 0; i < size; i++)
        for (int j = 0; j < size; j++)
            transposed[i, j] = matrix[j, i];
        return transposed;
    }
    
    private static double ApplyKernel(double[,] image, double[,] kernel, int x, int y, int radius)
    {
        double result = 0.0;
        int kernelSize = kernel.GetLength(0);

        for (int i = 0; i < kernelSize; i++)
        {
            for (int j = 0; j < kernelSize; j++)
            {
                int offsetX = x + i - radius;
                int offsetY = y + j - radius;

                result += image[offsetX, offsetY] * kernel[i, j];
            }
        }

        return result;
    }
}
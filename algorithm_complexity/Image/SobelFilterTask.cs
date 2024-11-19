using System;

namespace Recognizer;
internal static class SobelFilterTask
{
    public static double[,] SobelFilter(double[,] g, double[,] sx)
    {
        var width = g.GetLength(0);
        var height = g.GetLength(1);
        var result = new double[width, height];
        
        var sy = TransposeMatrix(sx);

        var radius = sx.GetLength(0) / 2;

        for (var x = radius; x < width - radius; x++)
        {
            for (var y = radius; y < height - radius; y++)
            {
                var gx = ApplyKernel(g, sx, x, y, radius);
                var gy = ApplyKernel(g, sy, x, y, radius);

                result[x, y] = Math.Sqrt(gx * gx + gy * gy);
            }
        }

        return result;
    }
    
    private static double[,] TransposeMatrix(double[,] matrix)
    {
        var size = matrix.GetLength(0);
        var transposed = new double[size, size];
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                transposed[i, j] = matrix[j, i];
            }
        }

        return transposed;
    }
    
    private static double ApplyKernel(double[,] image, double[,] kernel, int x, int y, int radius)
    {
        var result = 0.0;
        var kernelSize = kernel.GetLength(0);

        for (var i = 0; i < kernelSize; i++)
        {
            for (var j = 0; j < kernelSize; j++)
            {
                var offsetX = x + i - radius;
                var offsetY = y + j - radius;

                result += image[offsetX, offsetY] * kernel[i, j];
            }
        }

        return result;
    }
}
using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Pixel
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Pixel(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}

public class GrayscaleBenchmark
{
    private Pixel[,] _image;

    [Params(100, 500, 1000)]
    public int ImageSize { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _image = new Pixel[ImageSize, ImageSize];
        var random = new Random();
        for (int x = 0; x < ImageSize; x++)
        {
            for (int y = 0; y < ImageSize; y++)
            {
                _image[x, y] = new Pixel((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            }
        }
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public double[,] ToGrayscale1()
    {
        var width = _image.GetLength(0);
        var height = _image.GetLength(1);
        var grayscale = new double[width, height];

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (width != height)
                {
                    Console.WriteLine("HELLO WORLD!");
                }
                var pixel = _image[x, y];
                var brightness = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255.0;
                grayscale[x, y] = brightness;
            }
        }
        return grayscale;
    }
    
    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public double[,] ToGrayscale2()
    {
        var width = _image.GetLength(0);
        var height = _image.GetLength(1);
        var grayscale = new double[width, height];

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var width1 = _image.GetLength(0);
                var height1 = _image.GetLength(1);

                if (width1 != height1)
                {
                    Console.WriteLine("HELLO WORLD!");
                }
                var pixel = _image[x, y];
                var brightness = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255.0;
                grayscale[x, y] = brightness;
            }
        }
        return grayscale;
    }
    
    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public double[,] ToGrayscale3()
    {
        var width = _image.GetLength(0);
        var height = _image.GetLength(1);
        var grayscale = new double[width, height];

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (width != height)
                {
                    Console.WriteLine("HELLO WORLD!");
                }
                var pixel = _image[x, y];
                var brightness = calculateBrigtness(pixel);
                grayscale[x, y] = brightness;
            }
        }
        return grayscale;
    }

    public double calculateBrigtness(Pixel pixel)
    {
        return (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255.0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<GrayscaleBenchmark>();

        if (summary != null)
        {
            Console.WriteLine("HELLO");
        }
    }
}
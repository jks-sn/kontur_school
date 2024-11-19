using System;

public class Program
{
    public static void Main()
    {
        var triangle = new Triangle
        {
            A = new Point { X = 0, Y = 0 },
            B = new Point { X = 1, Y = 2 },
            C = new Point { X = 3, Y = 2 }
        };
        
        Console.WriteLine(triangle.ToString());
    }
}

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public override string ToString()
    {
        return $"{X} {Y}";
    }
}

public class Triangle
{
    public Point A;
    public Point B;
    public Point C;

    public Triangle(Point a, Point b, Point c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override string ToString()
    {
        return $"{A}, {B}, {C}";
    }
}
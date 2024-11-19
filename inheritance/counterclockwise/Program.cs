using System;
using System.Collections;

public class Point
{
    public double X;
    public double Y;
}

public class ClockwiseComparer : IComparer
{
    public int Compare(object x, object y)
    {
        if(x is Point p1 && y is Point p2) 
        {
            var angle1 = Math.Atan2(p1.Y, p1.X);
            var angle2 = Math.Atan2(p2.Y, p2.X);
            
            if (angle1 < 0)
            { 
                angle1 += 2 * Math.PI;
            }

            if (angle2 < 0)
            {
                angle2 += 2 * Math.PI;
            }
			
            if(angle1 > angle2)
            {
                return 1;
            }

            if(angle1 < angle2)
            {
                return -1;
            }
			
            return 0;
        }

        return 0;
    }
}

class Program
{
    public static void Main()
    {
        var array = new[]
        {
            new Point { X = 1, Y = 0 },      // 3:00
            new Point { X = -1, Y = 0 },     // 9:00
            new Point { X = 0, Y = 1 },      // 12:00
            new Point { X = 0, Y = -1 },     // 6:00
            new Point { X = 0.01, Y = 1 }    // Немного правее 12:00
        };
        Array.Sort(array, new ClockwiseComparer());
        foreach (Point e in array)
            Console.WriteLine("{0} {1}", e.X, e.Y);
    }
}
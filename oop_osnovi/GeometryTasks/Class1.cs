namespace GeometryTasks;

public class Vector
{
    public double X;
    public double Y;
	
    public Vector() { }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public double GetLength()
    {
        return Geometry.GetLength(this);
    }
    
    public Vector Add(Vector other)
    {
        return Geometry.Add(this, other);
    }
    
    public bool Belongs(Segment segment)
    {
        return Geometry.IsVectorInSegment(this, segment);
    }
}

public class Segment
{
    public Vector Begin;
    public Vector End;
    
    public Segment()
    {
        Begin = new Vector();
        End = new Vector();
    }
    
    public Segment(Vector begin, Vector end)
    {
        Begin = begin;
        End = end;
    }
    
    public double GetLength()
    {
        return Geometry.GetLength(this);
    }
    
    public bool Contains(Vector point)
    {
        return Geometry.IsVectorInSegment(point, this);
    }
}

public static class Geometry
{
    public static double GetLength(Vector vector)
    {
        return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }

    public static Vector Add(Vector vector1, Vector vector2)
    {
        return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
    }
    
    public static double GetLength(Segment segment)
    {
        var deltaX = segment.End.X - segment.Begin.X;
        var deltaY = segment.End.Y - segment.Begin.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    
    public static bool IsVectorInSegment(Vector point, Segment segment)
    {
        double distanceToBegin = GetDistance(segment.Begin, point);
        double distanceToEnd = GetDistance(point, segment.End);
        double segmentLength = GetLength(segment);

        double totalDistance = distanceToBegin + distanceToEnd;
        return Math.Abs(totalDistance - segmentLength) < 1e-10;
    }
}

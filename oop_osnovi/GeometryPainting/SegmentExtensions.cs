using System.Collections.Generic;
using GeometryTasks;
using Avalonia.Media;

namespace GeometryPainting;

public static class SegmentExtensions
{
    private static readonly Dictionary<Segment, Color> segmentColors = new Dictionary<Segment, Color>();
    
    public static void SetColor(this Segment segment, Color color)
    {
        segmentColors[segment] = color;
    }
    
    public static Color GetColor(this Segment segment)
    {
        return segmentColors.TryGetValue(segment, out var color) ? color : Colors.Black;
    }
}
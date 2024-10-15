namespace Names;

public class PlotData
{
    public string Title { get; }
    public string[] XLabels { get; }
    public double[] YValues { get; }

    public PlotData(string title, string[] xLabels, double[] yValues)
    {
        Title = title;
        XLabels = xLabels;
        YValues = yValues;
    }
}
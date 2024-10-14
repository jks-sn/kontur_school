namespace index_of_max;

class Program
{
    static void Main(string[] args)
    {
        double[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine($"Index of max: {MaxIndex(array)}.");
    }
    
    public static int MaxIndex(double[] array)
    {
        return array.Length == 0 ? -1 : Array.IndexOf(array, array.Max());
    }

}
namespace split_and_join;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    
    public static string ReplaceIncorrectSeparators(string text)
    {
        var parts = text.Split(new[] { ' ', ',', ':', ';', '-'}, StringSplitOptions.RemoveEmptyEntries);
        
        return string.Join("\t", parts);
    }
}
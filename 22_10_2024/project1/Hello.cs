namespace project1;

public class Hello
{
    public static string Greed(string name)
    {
        if (IsUpper(name))
        {
            return ($"HELLO, {name}!");
        }
        return($"Hello, {name}!");
    }
    
    public static string Greed(params string[] names)
    {
        if (names == null || names.Length == 0)
        {
            return "Hello, my friend!";
        }
        
        string allGreetings = string.Join("Hello, ", names.Take(greetings.Length - 1)) + " and " + greetings.Last() + "!";
    }
    public static bool IsUpper(string input)
    {
        return input.Length > 0 && input.All(char.IsUpper);
    }
}
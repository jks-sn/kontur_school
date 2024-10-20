namespace taro_cards;

class Program
{
    enum Suits
    {
        Wands,
        Coins,
        Cups,
        Swords
    }
    static void Main(string[] args)
    {
        Console.WriteLine(GetSuit(Suits.Wands));
        Console.WriteLine(GetSuit(Suits.Coins));
        Console.WriteLine(GetSuit(Suits.Cups));
        Console.WriteLine(GetSuit(Suits.Swords));
    }
    private static string GetSuit(Suits suit)
    {
        return suit switch
        {
            Suits.Wands => "жезлов",
            Suits.Coins => "монет",
            Suits.Cups => "кубков",
            Suits.Swords => "мечей"
        };
    }
}
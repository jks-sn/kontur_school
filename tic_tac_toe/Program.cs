namespace tic_tac_toe;

class Program
{
    public enum Mark
    {
        Empty,
        Cross,
        Circle
    }

    public enum GameResult
    {
        CrossWin,
        CircleWin,
        Draw
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public static GameResult GetGameResult(Mark[,] field)
    { 
        return GetWinnerMark(field) switch
        {
            Mark.Cross => GameResult.CrossWin,
            Mark.Circle => GameResult.CircleWin,
            _ => GameResult.Draw
        };
    }

    public static Mark GetWinnerMark(Mark[,] field)
    {
        for (int i = 0; i < 3; i++)
        {
            if (CheckLineMarked(field[i, 0], field[i, 1], field[i, 2]))
                return field[i, 0];
            if (CheckLineMarked(field[0, i], field[1, i], field[2, i]))
                return field[0, i];
        }
        
        if (CheckLineMarked(field[0, 0], field[1, 1], field[2, 2]))
            return field[0, 0];

        if (CheckLineMarked(field[0, 2], field[1, 1], field[2, 0]))
            return field[0, 2];

        return Mark.Empty;
    }
    public static bool CheckLineMarked(Mark a, Mark b, Mark c)
    {
        return  a != Mark.Empty && a == b && b == c;
    }
}
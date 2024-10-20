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
    var winnerCross = HasWinner(field, Mark.Cross);
    var winnerCircle = HasWinner(field, Mark.Circle);
    
    if (winnerCross && winnerCircle)
    {
        return GameResult.Draw;
    }

    if (winnerCross)
    {
        return GameResult.CrossWin;
    }

    if (winnerCircle)
    {
        return GameResult.CircleWin;
    }

    return GameResult.Draw;
}

public static bool HasWinner(Mark[,] field, Mark mark)
{
    for (int i = 0; i < 3; i++)
    {
        if (field[i, 0] == mark && field[i, 1] == mark && field[i, 2] == mark)
            return true;
    
        if (field[0, i] == mark && field[1, i] == mark && field[2, i] == mark)
            return true;
    }

    if (field[0, 0] == mark && field[1, 1] == mark && field[2, 2] == mark)
        return true;

    if (field[0, 2] == mark && field[1, 1] == mark && field[2, 0] == mark)
        return true;

    return false;
}
}
namespace stranger_cipher;

class Program
{
    public static void Main()
    {
        string[] lines = {
            "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ",
            "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой",
            "Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть",
            "если особенно упорно подойдешь к делу",
            "будет Трудно конечнО",
            "Код ведЬ не из простых",
            "очень ХОРОШИЙ код",
            "то у тебя все получится",
            "и я буДу Писать тЕбЕ еще",
            "чао"
        };

        string decodedMessage = DecodeMessage(lines);
        Console.WriteLine(decodedMessage);
    }

private static string DecodeMessage(string[] lines)
{
    return string.Join(" ", lines.SelectMany(line => line.Split(" ")).Where(word => char.IsUpper(word.FirstOrDefault())).Reverse());
}
}
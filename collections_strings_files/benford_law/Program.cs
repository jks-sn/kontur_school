namespace benford_law;


class Program
{
    static void Main(string[] args)
    {
        // Тест 1: простая строка, содержащая только цифру 1
        PrintStatistics(GetBenfordStatistics("1"));

        // Тест 2: строка, не содержащая цифр
        PrintStatistics(GetBenfordStatistics("abc"));

        // Тест 3: строка, содержащая несколько чисел
        PrintStatistics(GetBenfordStatistics("123 456 789"));

        // Тест 4: строка с перемешанными числами и буквами
        PrintStatistics(GetBenfordStatistics("abc 123 def 456 gf 789 i"));

        // Тест 5: строка с многозначными числами и пробелами
        PrintStatistics(GetBenfordStatistics("1024 23456 7890"));

        // Тест 6: строка с числами, начинающимися с нуля (их нужно игнорировать)
        PrintStatistics(GetBenfordStatistics("0123 0456 0789"));

        // Здесь можно добавить тесты для реальных данных, таких как данные о самых высоких зданиях
        string tallestBuildings = "828 632 601 555 452 442 439 428 421 413 410";
        PrintStatistics(GetBenfordStatistics(tallestBuildings));
    }
    public static int[] GetBenfordStatistics(string text)
    {
    var statistics = new int[10];

    text.Split(' ')
        .Where(part => part.Any(char.IsDigit))
        .Select(part => part.FirstOrDefault(char.IsDigit))
        .ToList()
        .ForEach(firstDigit => statistics[firstDigit - '0']++);
    return statistics;
    }
    public static void PrintStatistics(int[] statistics)
    {
        for (int i = 1; i <= 9; i++) // Цифры от 1 до 9
        {
            Console.WriteLine($"Цифра {i} встречается {statistics[i]} раз");
        }
        Console.WriteLine();
    }

}
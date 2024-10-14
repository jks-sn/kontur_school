namespace elementCount;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 1, 1 };
        Console.WriteLine($"Число 1 встречается {GetElementCount(array, 1)} раз(а)"); // Выведет 3
    }
    public static int GetElementCount(int[] items, int itemToCount)
    {
        return items.Count(item => item == itemToCount);
    }
}
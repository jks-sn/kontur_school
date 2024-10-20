namespace arr_to_pow;

class Program
{
    static void Main(string[] args)
    {
        var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Тест 1: Возведение элементов в степень 1 (ожидаем тот же массив)
        Console.WriteLine("Возведение в степень 1:");
        Console.WriteLine(string.Join(", ", GetPoweredArray(arrayToPower, 1)));
    
        // Тест 2: Возведение элементов в квадрат
        Console.WriteLine("Возведение в степень 2:");
        Console.WriteLine(string.Join(", ", GetPoweredArray(arrayToPower, 2)));
    
        // Тест 3: Возведение элементов в куб
        Console.WriteLine("Возведение в степень 3:");
        Console.WriteLine(string.Join(", ", GetPoweredArray(arrayToPower, 3)));
    
        // Тест 4: Частные случаи — пустой массив
        Console.WriteLine("Пустой массив:");
        Console.WriteLine(string.Join(", ", GetPoweredArray(new int[0], 1)));

        // Тест 5: Частные случаи — массив с одним элементом (возведение в степень 0)
        Console.WriteLine("Один элемент, возведение в степень 0:");
        Console.WriteLine(string.Join(", ", GetPoweredArray(new[] { 42 }, 0)));

        // Вывод исходного массива для проверки, что он не изменился
        Console.WriteLine("Исходный массив:");
        Console.WriteLine(string.Join(", ", arrayToPower));
    }
    public static int[] GetPoweredArray(int[]? arr, int power)
    {
        return arr.Length == 0 ? Array.Empty<int>() : arr.Select(x => (int)Math.Pow(x, power)).ToArray();
    }
}
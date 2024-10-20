//Program.cs

using System;

class Program
{
    public static void Main(string[] args)
    {
        // Пример вызова метода GetFirstEvenNumbers
        int[] result = GetFirstEvenNumbers(4);

        // Вывод результата на экран
        Console.WriteLine("Четные числа: " + string.Join(", ", result));
    }

    public static int[] GetFirstEvenNumbers(int count)
    {
        int[] evenNumbers = new int[count];
        
        for (int i = 0; i < count; ++i)
        {
            evenNumbers[i] = (i + 1) * 2;
        }
        
        return evenNumbers;
    }
}
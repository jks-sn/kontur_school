using System;

public class Program
{
    public static void Main()
    {
        var ints = new[] { 1, 2 };
        var strings = new[] { "A", "B" };

        Print(Combine(ints, ints));
        Print(Combine(ints, ints, ints));
        Print(Combine(ints));
        Print(Combine());
        Print(Combine(strings, strings));
        Print(Combine(ints, strings));
    }

    static void Print(Array? array)
    {
        if (array == null)
        {
            Console.WriteLine("null");
            return;
        }
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array.GetValue(i));
        Console.WriteLine();
    }

    public static Array? Combine(params Array[] arrays)
    {
        try
        {
            var elementType = arrays[0].GetType().GetElementType();
            
            if (arrays.Any(array => array.GetType().GetElementType() != elementType))
            {
                return null;
            }
        
            var totalLength = arrays.Sum(array => array.Length);

            var result = Array.CreateInstance(elementType, totalLength);
            var currentIndex = 0;

            foreach (var array in arrays)
            {
                Array.Copy(array, 0, result, currentIndex, array.Length);
                currentIndex += array.Length;
            }

            return result;
        }
        catch
        {
            return null;
        }
    }
}
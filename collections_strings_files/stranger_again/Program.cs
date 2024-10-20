namespace stranger_again;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Тест 1: Пример из задания
        string[] commands1 = {
            "push Привет! Это снова я! Пока!",
            "pop 5",
            "push Как твои успехи? Плохо?",
            "push qwertyuiop",
            "push 1234567890",
            "pop 26"
        };
        Console.WriteLine(ApplyCommands(commands1)); // Ожидается: "Привет! Это снова я! Как твои успехи?"

        // Тест 2: Только push
        string[] commands2 = {
            "push Hello",
            "push , World!"
        };
        Console.WriteLine(ApplyCommands(commands2)); // Ожидается: "Hello, World!"

        // Тест 3: push и pop поочередно
        string[] commands3 = {
            "push 12345",
            "pop 2",
            "push 67890",
            "pop 3"
        };
        Console.WriteLine(ApplyCommands(commands3)); // Ожидается: "123678"

        // Тест 4: Большое значение для pop, больше чем длина строки
        string[] commands4 = {
            "push Short",
            "pop 100"
        };
        Console.WriteLine(ApplyCommands(commands4)); // Ожидается: ""

        // Тест 5: Попробуем несколько команд pop подряд
        string[] commands5 = {
            "push StackOverflow",
            "pop 4",
            "pop 5",
            "pop 2"
        };
        Console.WriteLine(ApplyCommands(commands5)); // Ожидается: "Sta"

        // Тест 6: Попробуем, когда ничего не делаем
        string[] commands6 = { };
        Console.WriteLine(ApplyCommands(commands6)); // Ожидается: ""
    }

    public static string ApplyCommands(string[] commands)
    {
        var stringBuilder = new StringBuilder();

        foreach (var command in commands)
        {
            if (command.StartsWith("push"))
            {
                stringBuilder.Append(command.Substring(5));
            }
            else if (command.StartsWith("pop"))
            {
                int count = int.Parse(command.Substring(4));
                if (count <= stringBuilder.Length)
                {
                    stringBuilder.Length -= count;
                }
                else
                {
                    stringBuilder.Clear();
                }
            }
        }
        return stringBuilder.ToString();
    }
}
using System;
using System.Collections.Generic;

class Book : IComparable<Book>, IComparable
{
    public string Title;
    public int Theme;

    public Book(string title, int theme)
    {
        Title = title;
        Theme = theme;
    }
    
    public Book()
    {
        Title = string.Empty;
        Theme = 0;
    }
    public int CompareTo(Book? other)
    {
        if (other == null)
        {
            return 1;
        }
        var themeComparison = Theme.CompareTo(other.Theme);
        return themeComparison != 0 ? themeComparison : string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
    }
    
    int IComparable.CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }
        
        if (obj is Book otherBook)
        {
            return CompareTo(otherBook);
        }
        throw new ArgumentException();
    }
}

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book("C# Programming", 2),
            new Book("Introduction to Algorithms", 1),
            new Book("Design Patterns", 2),
            new Book("Clean Code", 1),
            new Book("The Pragmatic Programmer", 3),
            new Book("C# Programming", 1) // Дубликат с другим Theme
        };

        Console.WriteLine("Before Sorting:");
        foreach (var book in books)
            Console.WriteLine(book);

        books.Sort();

        Console.WriteLine("\nAfter Sorting:");
        foreach (var book in books)
            Console.WriteLine(book);

        // Тестирование Equals
        Book book1 = new Book("C# Programming", 2);
        Book book2 = new Book("c# programming", 2);
        Console.WriteLine($"\nbook1.Equals(book2): {book1.Equals(book2)}"); // True

        // Тестирование HashSet
        HashSet<Book> bookSet = new HashSet<Book>();
        bookSet.Add(book1);
        bookSet.Add(book2); // Не добавится, так как равен book1

        Console.WriteLine("\nHashSet contains:");
        foreach (var book in bookSet)
            Console.WriteLine(book);
    }
}

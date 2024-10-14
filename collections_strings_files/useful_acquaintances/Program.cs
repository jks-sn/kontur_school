namespace useful_acquaintances;

class Program
{
    static void Main(string[] args)
    {
        List<string> contacts = new List<string>
        {
            "Sasha:sasha1995@sasha.ru",
            "Alex:alex99@mail.ru",
            "Shurik:shurik2020@google.com",
            "Svetlana:sveta@ya.ru",
            "Alexey:alexey123@domain.com"
        };

        var optimizedContacts = OptimizeContacts(contacts);

        foreach (var kvp in optimizedContacts)
        {
            Console.WriteLine($"Key: {kvp.Key} -> Emails: {string.Join(", ", kvp.Value)}");
        }
    }
    private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
    {
        return contacts
            .GroupBy(GetKey)
            .ToDictionary(
                group => group.Key,
                group => group.ToList()
            );
    }

    private static string GetKey(string contact)
    {
        int colonIndex = contact.IndexOf(':') == -1 ? contact.Length : contact.IndexOf(':');
        string name = contact.Substring(0, colonIndex);
        return name.Length >= 2 ? name.Substring(0, 2) : name;
    }
}
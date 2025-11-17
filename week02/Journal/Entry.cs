using System;

public class Entry
{
    // Member variables
    public string _date;
    public string _prompt;
    public string _response;

    // Display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileString(string separator)
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}";
    }

    // Build an Entry from a file line
    public static Entry FromFileString(string line, string separator)
    {
        var parts = line.Split(new string[] { separator }, StringSplitOptions.None);
        if (parts.Length < 3) return null;
        return new Entry
        {
            _date = parts[0],
            _prompt = parts[1],
            _response = parts[2]
        };
    }
}

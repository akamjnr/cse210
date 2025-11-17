using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Add an entry
    public void AddEntry(Entry e)
    {
        _entries.Add(e);
    }

    // Display all entries
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine("----------------");
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Save the journal to a file
    public void Save(string filename, string separator)
    {
        var lines = new List<string>();
        foreach (var e in _entries)
        {
            lines.Add(e.ToFileString(separator));
        }
        File.WriteAllLines(filename, lines);
    }

    // Load the journal from a file
    public void Load(string filename, string separator)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}");
            return;
        }

        var lines = File.ReadAllLines(filename);
        var newEntries = new List<Entry>();
        foreach (var line in lines)
        {
            var entry = Entry.FromFileString(line, separator);
            if (entry != null) newEntries.Add(entry);
        }
        _entries = newEntries;
    }
}

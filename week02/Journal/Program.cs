using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();
        const string separator = "~|~";

        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    try
                    {
                        journal.Save(saveFile, separator);
                        Console.WriteLine($"Journal saved to {saveFile}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving file: " + ex.Message);
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        journal.Load(loadFile, separator);
                        Console.WriteLine($"Journal loaded from {loadFile}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading file: " + ex.Message);
                    }
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator generator)
    {
        string prompt = generator.GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        var entry = new Entry
        {
            _date = DateTime.Now.ToString("yyyy-MM-dd"),
            _prompt = prompt,
            _response = response
        };

        journal.AddEntry(entry);
        Console.WriteLine("Entry added.");
    }
}

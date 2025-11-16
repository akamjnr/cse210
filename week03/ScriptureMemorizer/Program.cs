using System;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        var reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                               "In all thy ways acknowledge him, and he shall direct thy paths.";

        var scripture = new Scripture(reference, scriptureText);

        var rng = new Random();

        // Clear initial screen and show the scripture
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            if (scripture.AllHidden())
            {
                // All words hidden, end program
                Console.WriteLine("All words are hidden. Program ended.");
                break;
            }

            Console.WriteLine("Press Enter to hide more words, or type 'quit' and press Enter to exit.");
            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Hide a few words per Enter.
            int hiddenThisRound = scripture.HideRandomWords(3, rng);

            // If none were hidden, we can end
            if (hiddenThisRound == 0 && scripture.AllHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ended.");
                break;
            }
            
        }
    }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Please enter a valid option (1-4).");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }

        Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
    }
}

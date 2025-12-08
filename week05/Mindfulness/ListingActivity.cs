using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        ShowStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> responses = new List<string>();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                responses.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {responses.Count} items.");
        ShowEndingMessage();
    }
}

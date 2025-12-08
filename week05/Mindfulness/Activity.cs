using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    // Start message
    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }
            Console.Write("Please enter a valid positive number: ");
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(4);
    }

    // Ending message
    protected void ShowEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(4);
    }

    // Spinner animation for pauses
    protected void ShowSpinner(int seconds)
    {
        char[] sequence = { '|', '/', '-', '\\' };
        int index = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(sequence[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % sequence.Length;
        }
    }

    // Countdown for breathing / thinking
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I grateful for today?",
        "What challenged me today and what did I learn?"
    };

    private Random _rand = new Random();

    // Return a random prompt
    public string GetRandomPrompt()
    {
        int idx = _rand.Next(_prompts.Count);
        return _prompts[idx];
    }
}

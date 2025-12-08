using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    Pause();
                    break;
                case "3":
                    SaveGoals();
                    Pause();
                    break;
                case "4":
                    LoadGoals();
                    Pause();
                    break;
                case "5":
                    RecordEvent();
                    Pause();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option (1-6).");
                    Pause();
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            Goal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "2")
        {
            Goal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            Goal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid type. Goal not created.");
        }
    }

    private void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Your goals:\n");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save (e.g. goals.txt): ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g. goals.txt): ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(name, desc, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, current));
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Please create a goal first.");
            return;
        }

        Console.Clear();
        Console.WriteLine("Which goal did you accomplish?\n");

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetName()}");
            index++;
        }

        Console.Write("\nEnter the number of the goal: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= _goals.Count)
            {
                Goal selected = _goals[choice - 1];
                int points = selected.RecordEvent();
                _score += points;

                Console.WriteLine($"\nEvent recorded! You earned {points} points.");
                Console.WriteLine($"Your new total score is: {_score}");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

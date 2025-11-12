using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    public List<Job> _jobs = new List<Job>();


    // Display method: prints the name and all jobs
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}
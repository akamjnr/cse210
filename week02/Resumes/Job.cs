using System;

public class Job
{
    // Member variables (by convention start with underscore)
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;


    // Display method to print job details in the required format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
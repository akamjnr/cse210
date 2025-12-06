using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List to hold videos
        List<Video> videos = new List<Video>();

        // ----- Video 1 -----
        Video video1 = new Video("How to make bread", "BakingWithMe", 540);
        video1.AddComment(new Comment("Lehi", "This was very helpful, thanks!"));
        video1.AddComment(new Comment("Nephi", "Mine turned out great!"));
        video1.AddComment(new Comment("Alma", "Can you do a sourdough version?"));
        videos.Add(video1);

        // ----- Video 2 -----
        Video video2 = new Video("Intro to C# Classes", "CodeTeacher", 900);
        video2.AddComment(new Comment("Student1", "Now I finally understand classes."));
        video2.AddComment(new Comment("Student2", "Clear and simple explanation."));
        video2.AddComment(new Comment("Student3", "Please make more videos"));
        videos.Add(video2);

        // ----- Video 3 -----
        Video video3 = new Video("Travel Vlog: Cape Town", "CapeAdventure", 720);
        video3.AddComment(new Comment("Millie", "Cape Town looks amazing!"));
        video3.AddComment(new Comment("Jnr", "Adding this to my bucket list."));
        video3.AddComment(new Comment("Taka", "Love the editing on this video."));
        videos.Add(video3);

        // ----- Display all videos and comments -----
        foreach (Video v in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {v.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"- {c.Name}: {c.Text}");
            }

            Console.WriteLine();
        }

        // Keep the console open
        Console.WriteLine("Done. Press Enter to exit.");
        Console.ReadLine();
    }
}

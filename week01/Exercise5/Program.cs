using System;

class Program
{
    static void Main(string[] args)
    {
        {
            // Display a welcome message
            DisplayWelcomeMessage();

            // Get user input
            string userName = PromptUserName();
            int userNumber = PromptUserNumber();

            // Calculate the square
            int squaredNumber = SquareNumber(userNumber);

            // Display the final result
            DisplayResult(userName, squaredNumber);
        }

        // Displays a welcome message
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // Prompts the user for their name and returns it
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // Prompts the user for their favorite number and returns it
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        // Squares a number and returns the result
        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        // Displays the result with the user's name
        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }
    }
}
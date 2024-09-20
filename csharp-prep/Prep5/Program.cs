using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcomeMessage();

        string name = prompt_name();
        int number = prompt_number();

        int squared_number = square_number(number);

        result(name, squared_number);

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string prompt_name()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            return name;
        }

        static int prompt_number()
        {
            Console.Write("What is your favorite number? ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        static int square_number(int number)
        {
            int square = number * number;

            return square;
        }

        static void result(string name, int square)
        {
            Console.WriteLine($"{name}, your favorite number squared is {square}.");
        }

    }
}
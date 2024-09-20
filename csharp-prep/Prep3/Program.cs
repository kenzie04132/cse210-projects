using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string answer = Console.ReadLine();
        int magic_number = int.Parse(answer);

        int guess = -1;

        while (guess != magic_number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magic_number)
            {
                Console.WriteLine("Guess lower.");
            }

            else if (guess < magic_number)
            {
                Console.WriteLine("Guess higher.");
            }

            else if (guess == magic_number)
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
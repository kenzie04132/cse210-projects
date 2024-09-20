using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your number grade in your course? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        if (percent >= 90)
        {
            Console.WriteLine("You passed! You have an A in the course.");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("You passed! You have an B in the course.");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("You passed! You have an C in the course.");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("Sorry, you did not pass. You have an D in the course.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. You have an F in the course.");
        }
    }
}
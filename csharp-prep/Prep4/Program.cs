using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();

        Console.Write("Enter a list of numbers. Type 0 when you are finished. ");

        int number = -1;

        //loop for asking for new numbers
        while (number != 0)
        {
            Console.WriteLine("Enter a number. ");
            string answer = Console.ReadLine();
            number = int.Parse(answer);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        //sum calculator 
        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }

        Console.Write($"The sum is {sum}. ");

        //average calculator
        float average = ((float)sum / numbers.Count);

        Console.Write($"The average is {average}. ");

        //largest number calculator
        int max_number = numbers[0];

        foreach (int item in numbers)
        {
            if (number > max_number)
            {
                max_number = number;
            }
        }

        Console.WriteLine($"The max is {max_number}. ");

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction a1 = new Fraction();
        Console.WriteLine(a1.GetFractionString());
        Console.WriteLine(a1.GetDecimalValue());

        Fraction a2 = new Fraction(5);
        Console.WriteLine(a2.GetFractionString());
        Console.WriteLine(a2.GetDecimalValue());

        Fraction a3 = new Fraction(3, 4);
        Console.WriteLine(a3.GetFractionString());
        Console.WriteLine(a3.GetDecimalValue());

        Fraction a4 = new Fraction(1, 3);
        Console.WriteLine(a4.GetFractionString());
        Console.WriteLine(a4.GetDecimalValue());

    }
}
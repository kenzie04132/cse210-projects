using System;
using System.Runtime.CompilerServices;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetTop()
    {
        string top_text = $"The top of the fraction is {_top}";
        return top_text;
    }

    public string GetBottom()
    {
        string bottom_text = $"The bottom of the fraction is {_bottom}";
        return bottom_text;
    }

    public string GetFractionString()
    {
        string fraction_text = $"The top of the fraction is {_top} and the bottom is {_bottom}. {_top}/{_bottom}.";
        return fraction_text;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
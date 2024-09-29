using System;
using System.Collections.Generic;

public class MenuOptions
{
    // Variable to hold the list of menu options
    private List<string> options;

    // Constructor to initialize the menu options
    public MenuOptions()
    {
        options = new List<string>
        {
            "Write New Journal Entry",
            "View Old Entries",
            "End Program"
        };
    }

    // Method to print the menu options on the screen
    public void PrintMenu()
    {
        Console.WriteLine("Menu Options:");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("Please select an option (1 - {0}):", options.Count);
    }
}
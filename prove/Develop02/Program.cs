using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        JournalStorage journalStorage = new JournalStorage("JournalEntries");

        while (true)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Create New Journal Entry");
            Console.WriteLine("2. View Old Journal Entries");
            Console.WriteLine("3. End Program");
            Console.Write("Choose an option (1-3): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine("Your Journal Prompt Today is: " + randomPrompt);

                Console.WriteLine("Please write your journal entry and hit enter when you are finished:");
                string userEntry = Console.ReadLine();

                JournalEntry journalEntry = new JournalEntry(userEntry);

                journalStorage.Save(journalEntry);
                Console.WriteLine("Your journal entry has been saved.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter the date to view entries (yyyy-MM-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    journalStorage.LoadEntriesByDate(date);
                }
                else
                {
                    Console.WriteLine("Error. Invalid date format. Please try again by entering yyyy-MM-DD (example: 2024-01-24).");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Error. Inavlid option. Please select a valid option.");
            }
        }
    }
}

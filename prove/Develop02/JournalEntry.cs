using System;
using System.IO;

public class JournalEntry
{
    public string NewEntry { get; private set; }

    public DateTime EntryDateTime { get; private set; }

    public JournalEntry(string entry)
    {
        NewEntry = entry;
        EntryDateTime = DateTime.Now; // Set the current date and time
    }

    public void SaveEntry(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);

        string fileName = $"{EntryDateTime.ToString("yyyy-MM-dd")}.txt";
        string filePath = Path.Combine(directoryPath, fileName);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{EntryDateTime}: {NewEntry}");
        }
    }
}
public class JournalStorage
{
    private string storageDirectory;

    public JournalStorage(string directory)
    {
        storageDirectory = directory;
    }

    public void Save(JournalEntry entry)
    {
        entry.SaveEntry(storageDirectory);
    }

    public void LoadEntriesByDate(DateTime date)
    {
        string fileName = $"{date.ToString("yyyy-MM-dd")}.txt";
        string filePath = Path.Combine(storageDirectory, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine($"Journal entries made on {date.ToString("yyyy-MM-dd")}:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine($"No journal entries found for {date.ToString("yyyy-MM-dd")}.");
        }
    }
}
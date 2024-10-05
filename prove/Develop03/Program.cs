using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("Revelation 14:2", "And I heard a voice from heaven, as the voice of many waters, and as the voice of a great thunder: and I heard the voice of harpers harping with their harps:"),
            new Scripture("1 Timothy 3:15", "But if I tarry long, that thou mayest know how thou oughtest to behave thyself in the house of God, which is the church of the living God, the pillar and ground of the truth."),
            new Scripture("Joseph Smith—Matthew 1:48", "Therefore be ye also ready, for in such an hour as ye think not, the Son of Man cometh."),
            new Scripture("D&C 20:53", "The teacher's duty is to watch over the church always, and be with and strengthen them;"),
            new Scripture("Articles of Faith 1:3", "We believe that through the Atonement of Christ, all mankind may be saved, by obedience to the laws and ordinances of the Gospel.")
        };

        Console.Clear();

        foreach (var scripture in scriptures)
        {
            while (true)
            {
                Console.WriteLine(scripture.GetDisplayedText());

                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit...");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    return; 
                }
                else if (input == "")
                {
                    scripture.HideRandomWord();

                    Console.Clear();

                    if (scripture.AllWordsHidden())
                    {
                        Console.WriteLine("All words are now hidden. Exiting...");
                        return; 
                    }
                }
            }
        }
    }
}
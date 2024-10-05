using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public string Reference { get; set; }
    public string Text { get; set; }
    private HashSet<int> hiddenWordIndices;

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        hiddenWordIndices = new HashSet<int>();
    }

    public string GetDisplayedText()
    {
        var words = Text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWordIndices.Contains(i))
            {
                words[i] = "____"; 
            }
        }
        return $"{Reference}: \"{string.Join(' ', words)}\"";
    }

    public bool HideRandomWord()
    {
        var words = Text.Split(' ');
        var random = new Random();

        var availableIndices = Enumerable.Range(0, words.Length)
                                          .Where(i => !hiddenWordIndices.Contains(i))
                                          .ToList();

        if (availableIndices.Count == 0)
        {
            return false;
        }

        int indexToHide = availableIndices[random.Next(availableIndices.Count)];
        hiddenWordIndices.Add(indexToHide);
        return true; 
    }

    public bool AllWordsHidden()
    {
        return hiddenWordIndices.Count == Text.Split(' ').Length;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public string Reference { get; private set; }
    public string Text { get; private set; }

    private HashSet<int> _hiddenWordIndices;

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        _hiddenWordIndices = new HashSet<int>();
    }

    public string GetDisplayedText()
    {
        var words = Text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (IsWordHidden(i))
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
                                          .Where(i => !IsWordHidden(i))
                                          .ToList();

        if (availableIndices.Count == 0)
        {
            return false;
        }

        int indexToHide = availableIndices[random.Next(availableIndices.Count)];
        HideWordAtIndex(indexToHide);
        return true; 
    }

    public bool AllWordsHidden()
    {
        return _hiddenWordIndices.Count == Text.Split(' ').Length;
    }

    // Encapsulated method to check if a word is hidden
    private bool IsWordHidden(int index)
    {
        return _hiddenWordIndices.Contains(index);
    }

    // Encapsulated method to hide a word at a specific index
    private void HideWordAtIndex(int index)
    {
        _hiddenWordIndices.Add(index);
    }
}

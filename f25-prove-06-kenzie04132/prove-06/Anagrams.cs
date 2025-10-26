namespace prove_06;

public static class Anagrams {
    /// <summary>
    /// <p>Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.</p>
    /// <p>Examples:</p>
    /// <p><c>is_anagram("CAT","ACT")</c> would return true</p>
    /// <p><c>is_anagram("DOG","GOOD")</c> would return false because GOOD has 2 O's</p>
    /// <p>Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces. You should also ignore cases. For 
    /// example, 'Ab' and 'Ba' should be considered anagrams</p>
    /// <p>Reminder: You can access a letter by index in a string by 
    /// using the [] notation.</p>
    /// </summary>
    public static bool IsAnagram(string word1, string word2) {
    // Remove spaces and convert to lowercase
        string cleanWord1 = word1.Replace(" ", "").ToLower();
        string cleanWord2 = word2.Replace(" ", "").ToLower();

        // Check if lengths are different
        if (cleanWord1.Length != cleanWord2.Length) {
            return false;
        }

        // Create a dictionary to count character frequencies for the first word
        // Key: character (char), Value: count (int)
        var counts = new Dictionary<char, int>();

        // Populate the dictionary with character counts from cleanWord1
        foreach (char c in cleanWord1) {
            // C# 7.0+ method for concise counting:
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        // Compare the second word against the character counts.
        foreach (char c in cleanWord2) {
            // Check if the character is in the dictionary (was in word1).
            if (counts.ContainsKey(c)) {
                // Decrement the count for this character.
                counts[c] -= 1;
                
                // Check if count is below zero 
                if (counts[c] < 0) {
                    return false;
                }
            } else {
                // check if character is from dictionary
                return false;
            }
        }
        return true;
    }
}

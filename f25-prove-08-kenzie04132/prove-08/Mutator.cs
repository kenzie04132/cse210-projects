namespace prove_08;

public class Mutator
{
    public List<string> Results { get; } = new();

    /// <summary>
    /// <p>Using recursion Print permutations of length
    /// 'size' from a list of 'letters'.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to deduplicate letters).</p>
    ///
    /// <p>In mathematics, we can calculate the number of permutations
    /// using the formula: <c>letters.Length! / (letters.Length - size)!</c></p>
    ///
    /// <p>For example, if letters was <c>['A','B','C']</c> and <c>size</c> was 2 then
    /// the following would be added to <c>Results</c>: AB, AC, BA, BC, CA, CB
    /// (might be in a different order).</p>
    ///
    /// <p>You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).</p>
    /// </summary>
    public void PermutationsChoose(string letters, int size, string word = "")
    {
        // if the current word reaches the target size, it will be returned
        if (word.Length == size)
        {
            Results.Add(word);
            return;
        }

        // for every letter in the string
        for (int i = 0; i < letters.Length; i++)
        {
            // chooses letter to be next in the word
            char nextChar = letters[i];
            string newWord = word + nextChar;

            // excludes the letter to make sure that it can't be used again 
            string remainingLetters = letters.Remove(i, 1);

            // calls the function with the new list of letters and the now longer word 
            PermutationsChoose(remainingLetters, size, newWord);
        }
    }
}
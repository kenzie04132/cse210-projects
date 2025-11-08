namespace prove_08;

public class WildcardBinary
{
    public List<string> Results { get; } = new();

    /// <summary>
    /// <p>A binary string is a string consisting of just 1's and
    /// 0's. For example, 1010111 is a binary string. If we introduce
    /// a wildcard symbol * into the string, we can say that this is
    /// now a pattern for multiple binary strings. For example, 101*1
    /// could be used to represent 10101 and 10111. A pattern can
    /// have more than one * wildcard. For example, 1**1 would result
    /// in 4 different binary strings: 1001, 1011, 1101, and 1111.</p>
    ///
    /// <p>Using recursion, determine all possible binary strings
    /// for a given pattern. You might find some of the string
    /// functions like <c>IndexOf</c> and <c>[..X]</c> / <c>[X..]</c>
    /// to be useful in solving this problem.</p>
    /// </summary>
    public void ExpandPattern(string pattern)
    {
        // find index of first wildcard
        int wildcardIndex = pattern.IndexOf('*');

        // if there is no wildcard, then the pattern's complete
        if (wildcardIndex == -1)
        {
            Results.Add(pattern);
            return;
        }

        // gets the 1st part of the string before the wildcard
        string firstPart = pattern.Substring(0, wildcardIndex);
        
        // gets the 2nd part of the string after the wildcard
        string secondPart = pattern.Substring(wildcardIndex + 1);

        // replaces '*' with 0 instead, becomes '1st part' + 0 + '2nd part'
        string patternZero = firstPart + '0' + secondPart;
        ExpandPattern(patternZero);

        // replaces '*' with 1 instead, becomes '1st part' + 1 + '2nd part'
        string patternOne = firstPart + '1' + secondPart;
        ExpandPattern(patternOne);
    }
}
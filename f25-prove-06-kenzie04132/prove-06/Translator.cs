namespace prove_06;

public class Translator {
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// For example, in a english to german dictionary:
    /// 
    /// my_translator.AddWord("book","buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    /// <returns>fixed array of divisors</returns>
    public void AddWord(string fromWord, string toWord) {
        // Todo Problem 1 - ADD YOUR CODE HERE
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord) {
        // The Dictionary.ContainsKey() method checks if the 'fromWord' key exists.
        if (_words.ContainsKey(fromWord)) {
            // If the key exists, return the corresponding value (the translation)
            return _words[fromWord];
        } else {
            // If the key does not exist, return the required "???" string
            return "???";
        }
    }
}
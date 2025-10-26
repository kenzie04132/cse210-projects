namespace prove_06;

public static class CensusData {
    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename) {
        var degrees = new Dictionary<string, int>();
        // Make sure the file exists before reading
        if (!File.Exists(filename)) {
            return degrees;
        }

        foreach (var line in File.ReadLines(filename)) {
            var fields = line.Split(",");
            
            // Check if there are enough fields to prevent an IndexOutOfRangeException
            if (fields.Length > 3) {
                string degree = fields[3].Trim(); // Get the degree string

                // Check if the degree already exists in the dictionary
                if (degrees.ContainsKey(degree)) {
                    // If it exists, increment the count
                    degrees[degree] += 1;
                } else {
                    // If it does not exist, add it to the dictionary with a starting count of 1
                    degrees.Add(degree, 1);
                }
            }
        }

        return degrees;
    }
}
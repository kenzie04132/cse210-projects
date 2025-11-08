namespace prove_08;

public static class SumSquares
{
    /// <summary>
    /// <p>Using recursion, find the sum of <c>1^2 + 2^2 + 3^2 + ... + n^2</c>
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// <c>n &lt;= 0</c>, return <c>0</c>.</p>
    /// <p>A loop should not be used.</p>
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // checks if n is 0 or less than 0, returns 0
        if (n <= 0)
        {
            return 0;
        }

        // keeps the counting going by having the last number squared + the sum squares recursive times the last number minus 1
        return (n * n) + SumSquaresRecursive(n - 1);
    }
}
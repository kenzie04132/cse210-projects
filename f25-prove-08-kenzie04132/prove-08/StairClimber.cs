namespace prove_08;

public static class StairClimber
{
    /// <summary>
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    /// <code>
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    /// </code>
    ///
    /// <p>With just one step to go, the ways to get
    /// to the top of <c>s</c> stairs is to either:</p>
    ///
    /// <list type="bullet">
    /// <item>take a single step from the second to last step,</item>
    /// <item>take a double step from the third to last step,</item>
    /// <item>take a triple step from the fourth to last step</item>
    /// </list>
    ///
    /// <p>We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).</p>
    ///
    /// <p>These final leaps give us a sum:</p>
    ///
    /// <code>
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + CountWaysToClimb(s-2) + CountWaysToClimb(s-3);
    /// </code>
    /// <p>To run this function for larger values of <c>s</c>, you will need
    /// to update this function to use memoization.  The parameter
    /// <c>remember</c> has already been added as an input parameter to 
    /// the function for you to complete this task.</p>
    /// </summary>
    /// <param name="s">Number of steps</param>
    /// <param name="remember">Optional dictionary to implement memoization</param>
    /// <returns>The number of ways that a person could climb <c>s</c> steps</returns>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // check the cache
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // base cases, I just added a 0 to it to handle possible exceptions, added notes for what I added 
        if (s == 0)
            return 1; // only one way to climb 0 stairs
        if (s < 0)
            return 0; // can't climb a negative amount of stairs 
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // original code 
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        // save to the cache
        remember[s] = ways;

        return ways;
    }
}
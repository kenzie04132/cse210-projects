namespace prove_08;

/// <summary>
/// Problem 5<br/>
/// <para>A maze is defined as a list of lists.  The outer list
/// contains a representation of each row in the maze.  You can
/// assume that the maze will be square (same number of rows
/// and columns). The inner lists show what is in the maze:</para>
/// <ul>
/// <li>0 = Wall (You can't go through this)</li>
/// <li>1 = Open Path (You can go through this)</li>
/// <li>2 = End (You want to get to this point to win)</li>
/// </ul>
/// <p>See the Prove instructions for graphical representations of
/// the 2 test mazes defined below.</p>
/// 
/// <p>The <c>IsEnd()</c> and the <c>IsValidMove()</c> functions are
/// already written for you.  These functions assume that the first
/// square in the maze is <c>(0,0)</c>.  These functions also assume
/// that you can't leave the boundaries of the maze and that you 
/// can't visit the same square in the same path (no circles).</p>
/// 
/// <p>The <c>currPath</c> variable is a list of (x,y) tuples that 
/// represent the path we are currently on.  If you add a new position
/// to the path, make sure that you add the tuple to the list so that the
/// <c>IsValidMove()</c> function works properly.</p>
/// 
/// <p>The goal is to implement the 'solve_maze' function to display
/// all paths to the end square using recursion.  When you find a path, 
/// then displaying will be as simple as 'Print(curr_path)'.</p>
/// </summary>
public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public List<List<(int, int)>> Solutions { get; }

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
        Solutions = new List<List<(int, int)>>();
    }


    /// <summary>
    /// Helper function to determine if the (x,y) position is at 
    /// the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }

    /// <summary>
    /// Helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<(int, int)> currPath, int x, int y)
    {
        // Can't go outside the maze boundary (assume maze is a square)
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        // Can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // Can't go if we have already been there (don't go in circles)
        if (currPath.Contains((x, y)))
            return false;
        // Otherwise, we are good
        return true;
    }

    /// <summary>
    /// Makes a copy of the <paramref name="currentPath"/> and saves it in
    /// the <see cref="Solutions"/> list
    /// </summary>
    /// <param name="currentPath">The path traveled from (0, 0) to (endX, endY) inclusive</param>
    /// <exception cref="ArgumentException">If <paramref name="currentPath"/> is null</exception>
    public void MarkSolution(List<(int, int)>? currentPath)
    {
        if (currentPath is null)
            throw new ArgumentException("Path cannot be null");
        // Add a copy of the current path to the list of solutions
        Solutions.Add(new List<(int, int)>(currentPath));
    }

    /// <summary>
    /// Use recursion to Print all paths that start at (0,0) and end at the
    /// 'end' square.
    /// </summary>
    public void Solve(int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // checks for validity 
        if (!this.IsValidMove(currPath, x, y))
        {
            return;
        }

        // adds to path 
        currPath.Add((x, y));

        // once the end is found, marks the current path as the solution
        if (this.IsEnd(x, y))
        {
            this.MarkSolution(currPath);
        }
        else
        {
            // checks possible paths in every direction
        
            // checks up 
            Solve(x, y - 1, currPath);

            // checks down
            Solve(x, y + 1, currPath);

            // checks left
            Solve(x - 1, y, currPath);

            // checks right
            Solve(x + 1, y, currPath);
        }

        // if we need to go back in case of a dead end, retreats one space 
        currPath.RemoveAt(currPath.Count - 1);
    }
}
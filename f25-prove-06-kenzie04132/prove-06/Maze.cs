namespace prove_06;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then display "Can't go that way!". If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze {
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    private Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap) {
        _mazeMap = mazeMap;
    }
    
    /// <summary>
    /// Builds a brand-new Maze with the dictionary
    /// </summary>
    public static Maze Build() {
        return new Maze(new() {
            { (1, 1), [false, true, false, true] },
            { (1, 2), [false, true, true, false] },
            { (1, 3), [false, false, false, false] },
            { (1, 4), [false, true, false, true] },
            { (1, 5), [false, false, true, true] },
            { (1, 6), [false, false, true, false] },
            { (2, 1), [true, false, false, true] },
            { (2, 2), [true, false, true, true] },
            { (2, 3), [false, false, true, true] },
            { (2, 4), [true, true, true, false] },
            { (2, 5), [false, false, false, false] },
            { (2, 6), [false, false, false, false] },
            { (3, 1), [false, false, false, false] },
            { (3, 2), [false, false, false, false] },
            { (3, 3), [false, false, false, false] },
            { (3, 4), [true, true, false, true] },
            { (3, 5), [false, false, true, true] },
            { (3, 6), [false, false, true, false] },
            { (4, 1), [false, true, false, false] },
            { (4, 2), [false, false, false, false] },
            { (4, 3), [false, true, false, true] },
            { (4, 4), [true, true, true, false] },
            { (4, 5), [false, false, false, false] },
            { (4, 6), [false, false, false, false] },
            { (5, 1), [true, true, false, true] },
            { (5, 2), [false, false, true, true] },
            { (5, 3), [true, true, true, true] },
            { (5, 4), [true, false, true, true] },
            { (5, 5), [false, false, true, true] },
            { (5, 6), [false, true, true, false] },
            { (6, 1), [true, false, false, false] },
            { (6, 2), [false, false, false, false] },
            { (6, 3), [true, false, false, false] },
            { (6, 4), [false, false, false, false] },
            { (6, 5), [false, false, false, false] },
            { (6, 6), [true, false, false, false] }
        });
    }

    /// <summary>
    /// Check if you can move left 
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveLeft() {
        return CheckAndMove(0, -1, 0); 
    }

    /// <summary>
    /// Check to see if you can move right
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveRight() {
        return CheckAndMove(1, 1, 0);
    }

    /// <summary>
    /// Check to see if you can move up
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveUp() {
        return CheckAndMove(2, 0, -1);
    }

    /// <summary>
    /// Check to see if you can move down
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveDown() {
        return CheckAndMove(3, 0, 1);
    }
    
    /// <summary>
    /// Private helper function to handle the common logic for all four directions.
    /// </summary>
    /// <param name="directionIndex">The index in the bool array for the direction (0=L, 1=R, 2=U, 3=D)</param>
    /// <param name="deltaX">The change to _currX if movement is successful</param>
    /// <param name="deltaY">The change to _currY if movement is successful</param>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    private bool CheckAndMove(int directionIndex, int deltaX, int deltaY) {
        // Get coordinates for the current location
        bool[] validMoves = _mazeMap[(_currX, _currY)];

        // Check if the current direction can be taken 
        if (validMoves[directionIndex]) {
            _currX += deltaX;
            _currY += deltaY;
            return true;
        } else {
            Console.WriteLine("Can't go that way!");
            return false;
        }
    }

    public (int, int) GetStatus() {
        Console.WriteLine($"Current location (x={_currX}, y={_currY})");
        return (_currX, _currY);
    }
}
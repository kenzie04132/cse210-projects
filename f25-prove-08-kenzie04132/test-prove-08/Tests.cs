using NUnit.Framework;
using prove_08;

public class Tests
{
    [Test]
    [TestCase(1, 1)]
    [TestCase(10, 385)]
    [TestCase(100, 338350)]
    public void TestProblem1SumSquares(int n, int expected)
    {
        Assert.That(SumSquares.SumSquaresRecursive(n), Is.EqualTo(expected));
    }

    [Test]
    public void TestProblem2PermutationsChoose1()
    {
        var mutator = new Mutator();
        mutator.PermutationsChoose("ABCD", 3);
        string[] expected =
        [
            "ABC", "ABD", "ACB", "ACD", "ADB", "ADC", "BAC", "BAD", "BCA", "BCD", "BDA", "BDC",
            "CAB", "CAD", "CBA", "CBD", "CDA", "CDB", "DAB", "DAC", "DBA", "DBC", "DCA", "DCB"
        ];
        Assert.That(mutator.Results, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem2PermutationsChoose2()
    {
        var mutator = new Mutator();
        mutator.PermutationsChoose("ABCD", 2);
        string[] expected = ["AB", "AC", "AD", "BA", "BC", "BD", "CA", "CB", "CD", "DA", "DB", "DC"];
        Assert.That(mutator.Results, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem2PermutationsChoose3()
    {
        var mutator = new Mutator();
        mutator.PermutationsChoose("ABCD", 1);
        string[] expected = ["A", "B", "C", "D"];
        Assert.That(mutator.Results, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem3CountWaysToClimb1()
    {
        Assert.That(StairClimber.CountWaysToClimb(5), Is.EqualTo(13m));
    }

    [Test]
    public void TestProblem3CountWaysToClimb2()
    {
        Assert.That(StairClimber.CountWaysToClimb(20), Is.EqualTo(121415m));
    }

    [Test, Timeout(5000)] // Run for a maximum of 5000 milliseconds (5 seconds)
    public void TestProblem3CountWaysToClimb3()
    {
        Assert.That(StairClimber.CountWaysToClimb(100), Is.EqualTo(180396380815100901214157639m));
    }

    [Test]
    public void TestProblem4WildcardBinary1()
    {
        var wildcard = new WildcardBinary();
        wildcard.ExpandPattern("110*0*");
        string[] expected = ["110000", "110001", "110100", "110101"];
        Assert.That(wildcard.Results, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem4WildcardBinary2()
    {
        var wildcard = new WildcardBinary();
        wildcard.ExpandPattern("***");
        string[] expected = ["000", "001", "010", "011", "100", "101", "110", "111"];
        Assert.That(wildcard.Results, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem5SolveMaze1Simple()
    {
        Maze maze = new Maze(3, 1, MazeData.SimpleMazeData);
        maze.Solve();
        // One Solution (order should match):
        List<List<(int, int)>> expected =
        [
            [(0, 0), (1, 0), (2, 0)]
        ];
        Assert.That(maze.Solutions, Has.Count.EqualTo(1));
        Assert.That(maze.Solutions, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem5SolveMaze2Smallest()
    {
        Maze maze = new Maze(2, 2, MazeData.SmallestMazeData);
        maze.Solve();
        // One Solution (order should match):
        List<List<(int, int)>> expected =
        [
            [(0, 0), (0, 1)]
        ];
        Assert.That(maze.Solutions, Has.Count.EqualTo(1));
        Assert.That(maze.Solutions, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem5SolveMaze3SmallestAlt()
    {
        Maze maze = new Maze(2, 2, MazeData.SmallestAltMazeData);
        maze.Solve();
        // One Solution (order should match):
        List<List<(int, int)>> expected =
        [
            [(0, 0), (1, 0)]
        ];
        Assert.That(maze.Solutions, Has.Count.EqualTo(1));
        Assert.That(maze.Solutions, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem5SolveMaze4TwoSolutions()
    {
        Maze maze = new Maze(3, 3, MazeData.TwoSolutionMazeData);
        maze.Solve();
        // Two Solutions (order in each solution should match):
        List<List<(int, int)>> expected =
        [
            [(0, 0), (0, 1), (0, 2), (1, 2), (2, 2)],
            [(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)]
        ];
        Assert.That(maze.Solutions, Has.Count.EqualTo(2));
        Assert.That(maze.Solutions, Is.EquivalentTo(expected));
    }

    [Test]
    public void TestProblem5SolveMaze5Big()
    {
        Maze maze = new Maze(20, 20, MazeData.BigMazeData);
        maze.Solve();
        // One Solution (order should match):
        List<List<(int, int)>> expected =
        [
            [
                (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (3, 3), (3, 4), (3, 5),
                (3, 6), (2, 6), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (2, 10), (3, 10),
                (4, 10), (5, 10), (5, 9), (5, 8), (5, 7), (5, 6), (5, 5), (5, 4), (5, 3),
                (5, 2), (5, 1), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (10, 1),
                (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (9, 6), (8, 6), (8, 7), (8, 8),
                (7, 8), (7, 9), (7, 10), (7, 11), (7, 12), (7, 13), (6, 13), (5, 13), (5, 14),
                (5, 15), (5, 16), (5, 17), (5, 18), (5, 19), (6, 19), (7, 19), (8, 19), (9, 19),
                (10, 19), (11, 19), (12, 19), (12, 18), (12, 17), (12, 16), (12, 15), (12, 14),
                (12, 13), (12, 12), (12, 11), (12, 10), (12, 9), (13, 9), (14, 9), (15, 9),
                (15, 8), (15, 7), (15, 6), (15, 5), (14, 5), (13, 5), (12, 5), (12, 4), (12, 3),
                (12, 2), (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (17, 2), (17, 3),
                (17, 4), (17, 5), (18, 5), (19, 5), (19, 6), (19, 7), (19, 8), (19, 9), (19, 10),
                (19, 11), (19, 12), (18, 12), (17, 12), (16, 12), (16, 13), (16, 14), (16, 15),
                (17, 15), (18, 15), (18, 16), (18, 17), (18, 18), (18, 19), (19, 19)
            ]
        ];
        Assert.That(maze.Solutions, Has.Count.EqualTo(1));
        Assert.That(maze.Solutions, Is.EquivalentTo(expected));
    }
}
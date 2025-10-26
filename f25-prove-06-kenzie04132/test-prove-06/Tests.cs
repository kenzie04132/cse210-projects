using System.Text.RegularExpressions;
using NUnit.Framework;
using prove_06;

public class Tests
{
    [Test]
    public void Test1GermanTranslator()
    {
        // Todo Problem 1
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        Assert.That(englishToGerman.Translate("Car"), Is.EqualTo("Auto"));
        Assert.That(englishToGerman.Translate("Plane"), Is.EqualTo("Flugzeug"));
        Assert.That(englishToGerman.Translate("Train"), Is.EqualTo("???"));
    }

    [Test]
    public void Test2SummarizeDegrees()
    {
        // Todo Problem 2
        var expected = new Dictionary<string, int>
        {
            { "Bachelors", 5355 }, { "HS-grad", 10501 }, { "11th", 1175 }, { "Masters", 1723 }, { "9th", 514 },
            { "Some-college", 7291 }, { "Assoc-acdm", 1067 }, { "Assoc-voc", 1382 }, { "7th-8th", 646 },
            { "Doctorate", 413 }, { "Prof-school", 576 }, { "5th-6th", 333 }, { "10th", 933 }, { "1st-4th", 168 },
            { "Preschool", 51 }, { "12th", 433 },
        };
        Assert.That(CensusData.SummarizeDegrees("census.txt"), Is.EquivalentTo(expected));

        // Results may be in a different order:
        // <Dictionary>{[Bachelors, 5355], [HS-grad, 10501], [11th, 1175],
        // [Masters, 1723], [9th, 514], [Some-college, 7291], [Assoc-acdm, 1067],
        // [Assoc-voc, 1382], [7th-8th, 646], [Doctorate, 413], [Prof-school, 576],
        // [5th-6th, 333], [10th, 933], [1st-4th, 168], [Preschool, 51], [12th, 433]}
    }

    [Test]
    [TestCase("CAT", "ACT", true)]
    [TestCase("DOG", "GOOD", false)]
    [TestCase("AABBCCDD", "ABCD", false)]
    [TestCase("ABCCD", "ABBCD", false)]
    [TestCase("BC", "AD", false)]
    [TestCase("Ab", "Ba", true)]
    [TestCase("A Decimal Point", "Im a Dot in Place", true)]
    [TestCase("tom marvolo riddle", "i am lord voldemort", true)]
    [TestCase("Eleven plus Two", "Twelve Plus One", true)]
    [TestCase("Eleven plus One", "Twelve Plus One", false)]
    public void Test3Anagrams(string word1, string word2, bool expected)
    {
        // Todo Problem 3
        Assert.That(Anagrams.IsAnagram(word1, word2), Is.EqualTo(expected));
    }

    [Test]
    public void Test4Maze()
    {
        // Todo Problem 4
        Maze maze = Maze.Build();
        Assert.Multiple(() =>
        {
            Assert.That(maze.GetStatus(), Is.EqualTo((1, 1))); // Should be at (1,1)
            Assert.That(maze.MoveUp(), Is.False); // Error
            Assert.That(maze.MoveLeft(), Is.False); // Error
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.MoveRight(), Is.False); // Error
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.MoveUp(), Is.True);
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveLeft(), Is.True);
            Assert.That(maze.MoveDown(), Is.False); // Error
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveDown(), Is.True);
            Assert.That(maze.MoveRight(), Is.True);
            Assert.That(maze.GetStatus(), Is.EqualTo((6, 6))); // Should be at (6,6)
        });
    }

    [Test]
    public void Test5EarthquakeDailySummary()
    {
        // Todo Problem 5
        var results = EarthquakesService.EarthquakeDailySummary();
        var expected = GetExpectedResults();
        Assert.That(results, Is.EqualTo(expected));
    }

    private static List<string> GetExpectedResults()
    {
        return new HttpClient()
            .GetStringAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson").Result
            .Split("\n").Select(line => Regex.Match(line, @".*""mag"":(?<mag>[^,]+),""place"":""(?<place>[^""]+)"))
            .Select(match => $"{match.Groups["place"]} - Mag {match.Groups["mag"]}").ToList();
    }
}
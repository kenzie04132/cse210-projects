using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Abstract base class for all goals
[Serializable]
public abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public string Name => _name;
    public int Points => _points;

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{_name}: {_description} - Points: {_points}");
    }

    public abstract string GetGoalType();
    public abstract bool IsComplete();
    public abstract int GetTimesCompleted();
}

// Class for simple goals inheriting from Goal
[Serializable]
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Completed goal '{Name}'! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine(_isComplete ? "[X] Completed" : "[ ] Not Completed");
    }

    public override string GetGoalType() => "Simple Goal";
    public override bool IsComplete() => _isComplete;
    public override int GetTimesCompleted() => _isComplete ? 1 : 0;
}

// Class for eternal goals inheriting from Goal
[Serializable]
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for goal '{Name}'. You earned {Points} points.");
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine("[ ] Eternal Goal (never complete)");
    }

    public override string GetGoalType() => "Eternal Goal";
    public override bool IsComplete() => false; // Eternal goals are never completed
    public override int GetTimesCompleted() => 0; // Eternal goals do not have completions
}

// Class for checklist goals inheriting from Goal
[Serializable]
public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private readonly int _targetTimes;
    private readonly int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetTimes, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetTimes = targetTimes;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_timesCompleted < _targetTimes)
        {
            _timesCompleted++;
            Console.WriteLine($"Recorded event for goal '{Name}'. You earned {Points} points.");

            if (_timesCompleted == _targetTimes)
            {
                Console.WriteLine($"Congratulations! You completed the goal '{Name}' and earned an additional {_bonusPoints} bonus points!");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' has already been completed.");
        }
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"Completed {_timesCompleted}/{_targetTimes} times.");
    }

    public override string GetGoalType() => "Checklist Goal";
    public override bool IsComplete() => _timesCompleted >= _targetTimes;
    public override int GetTimesCompleted() => _timesCompleted;
}

// Class to manage all goals
[Serializable]
public class GoalManager
{
    private readonly List<Goal> _goals;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            goal.DisplayGoal();
        }
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void SaveGoals(string filename)
    {
        var json = JsonSerializer.Serialize(_goals);
        File.WriteAllText(filename, json);
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            var json = File.ReadAllText(filename);
            _goals.Clear(); // Clear existing goals before loading
            _goals.AddRange(JsonSerializer.Deserialize<List<Goal>>(json));
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}

// Entry point of the program
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string filename = "goals.json"; // Using JSON file extension

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(goalManager);
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    break;
                case "3":
                    goalManager.SaveGoals(filename);
                    break;
                case "4":
                    goalManager.LoadGoals(filename);
                    break;
                case "5":
                    RecordEvent(goalManager);
                    break;
                case "6":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select an option: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description of the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of points associated with the goal: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            goalManager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            goalManager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("Enter the target number of times to complete this goal: ");
            int targetTimes = int.Parse(Console.ReadLine());
            Console.Write("Enter the bonus points for completing this goal: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            goalManager.AddGoal(new ChecklistGoal(name, description, points, targetTimes, bonusPoints));
        }
        else
        {
            Console.WriteLine("Invalid goal type. Goal not created.");
        }
    }

    static void RecordEvent(GoalManager goalManager)
    {
        Console.Write("Enter the index of the goal to record an event (starting from 0): ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            goalManager.RecordGoalEvent(index);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}
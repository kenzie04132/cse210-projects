using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _duration; // in minutes

    // Constructor
    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    // Properties
    public DateTime Date => _date;
    public int Duration => _duration;

    // Abstract methods
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Summary method
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Duration} min)";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / Duration) * 60; // mph

    public override double GetPace() => Duration / GetDistance(); // min per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * (Duration / 60.0); // miles

    public override double GetSpeed() => _speed;

    public override double GetPace() => (60.0 / GetSpeed()); // min per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():F1} miles, Speed: {GetSpeed()} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 0.025; // assuming 25m lap, convert to miles

    public override double GetSpeed() => (GetDistance() / Duration) * 60; // mph

    public override double GetPace() => Duration / GetDistance(); // min per mile

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Main program
public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of each activity
        Running run = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Cycling cycle = new Cycling(new DateTime(2022, 11, 4), 45, 12.0);
        Swimming swim = new Swimming(new DateTime(2022, 11, 5), 30, 20);

        // Add activities to a list
        List<Activity> activities = new List<Activity>
        {
            run,
            cycle,
            swim
        };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;

namespace ActivityApp
{
    // Base class for activities
    public abstract class Activity
    {
        protected string _activityName;
        protected string _description;
        protected int _duration;

        // Common method to start the activity
        public void StartActivity()
        {
            Console.WriteLine($"Starting: {_activityName}");
            Console.WriteLine(_description);
            Console.Write("Enter the duration (in seconds) that you would like this activity to last: ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready to begin...");
            DisplayAnimation(3);
        }

        // Common method to end the activity
        public void EndActivity()
        {
            Console.WriteLine("Good job! You completed the activity.");
            Console.WriteLine($"Activity: {_activityName}, Duration: {_duration} seconds.");
            DisplayAnimation(3);
        }

        // Method to display animation
        protected void DisplayAnimation(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }

    // Derived class for Breathing Activity
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _activityName = "Breathing Activity";
            _description = "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public void PerformBreathing()
        {
            StartActivity();
            int elapsedTime = 0;

            while (elapsedTime < _duration)
            {
                Console.WriteLine("Breathe in...");
                DisplayAnimation(4); // 4 seconds for breathing in
                Console.WriteLine("Breathe out...");
                DisplayAnimation(4); // 4 seconds for breathing out
                elapsedTime += 8; // 4 seconds in + 4 seconds out
            }

            EndActivity();
        }
    }

    // Derived class for Reflection Activity
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you completed a difficult task.",
            "Think of a time when you didn't give up.",
            "Think of a time when you helped a close friend.",
            "Think of a time when you felt proud of yourself."
        };

        private List<string> _questions = new List<string>
        {
            "How did this experience make you feel?",
            "When was another time you did this?",
            "Where did this experience come from?",
            "How did you feel about yourself afterwards?",
            "What made this experience stick out to you?",
            "Did you share this exeprience with anyone else?",
            "Who was around when you experienced this?",
            "Who might have helped you in this experience?",
            "What about this changed you or made you think differently?"
        };

        public ReflectionActivity()
        {
            _activityName = "Reflection Activity";
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public void PerformReflection()
        {
            StartActivity();
            int elapsedTime = 0;

            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Thread.Sleep(4000); // Pause to allow reflection on the prompt

            while (elapsedTime < _duration)
            {
                string question = _questions[random.Next(_questions.Count)];
                Console.WriteLine(question);
                DisplayAnimation(5); // Pause for 5 seconds for reflection
                elapsedTime += 5; // Increment elapsed time by the duration of the pause
            }

            EndActivity();
        }
    }

    // Derived class for Listing Activity
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are important people in your life?",
            "What do you like about yourself?",
            "How have you seen God's hand in your life this week?",
            "What spiritual experiences have you had this week? If you haven't, what can you do to better feel the spirit?",
            "Who have you helped this week? How have you helped them?"
        };

        public ListingActivity()
        {
            _activityName = "Listing Activity";
            _description = "This activity will help you reflect on the good things in your life by having you enter your answers to a question.";
        }

        public void PerformListing()
        {
            StartActivity();
            int elapsedTime = 0;
            List<string> itemsList = new List<string>();

            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            DisplayAnimation(3); // Countdown to start thinking about the prompt

            while (elapsedTime < _duration)
            {
                Console.Write("Please write an answer to the question. You can have multiple answers. (or press Enter to finish): ");
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    itemsList.Add(item);
                }
                else
                {
                    break; // Exit if the user presses Enter without input
                }
                elapsedTime += 1; // Increment elapsed time by 1 second per item
            }

            Console.WriteLine($"You gave {itemsList.Count} answers.");
            EndActivity();
        }
    }

    // Main program to run the activities
    class Program
    {
        static void Main(string[] args)
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.PerformBreathing();

            ReflectionActivity reflectionActivity = new ReflectionActivity();
            reflectionActivity.PerformReflection();

            ListingActivity listingActivity = new ListingActivity();
            listingActivity.PerformListing();
        }
    }
}
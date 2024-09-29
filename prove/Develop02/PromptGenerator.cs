using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What are you grateful for?",
            "Who/what made you smile today?",
            "What is something you struggled with today?",
            "How did you see the hand of God in your life today?",
            "Who are your closest friends? How have they helped you?",
            "What is a goal you want to work on?",
            "What did you learn today?",
            "What do you hope for tomorrow?",
            "What person/place/thing stood out to you today?",
            "What are your plans for this week?"
        };
        random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
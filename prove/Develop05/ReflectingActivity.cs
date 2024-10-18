using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ReflectingActivity : Activity
{
    private static int _reflectingCount = 0;
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        ">Why was this experience meaningful to you?",
        ">Have you ever done anything like this before?",
        ">How did you get started?",
        ">How did you feel when it was complete?",
        ">What made this time different than other times when you were not as successful?",
        ">What is your favorite thing about this experience?",
        ">What could you learn from this experience that applies to other situations?",
        ">What did you learn about yourself through this experience?",
        ">How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public void RunReflectingActivity()
    {
        Console.Clear();
        Console.WriteLine("Consider the following prompt:\n");
        string selectedPrompt = GetRandomPrompt();
        Console.WriteLine($"---{selectedPrompt}---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may begin in: ");
        ShowCountDown(3);

        int reflectionDuration = _duration;
        while (reflectionDuration > 0)
        {
            string selectedQuestion = GetRandomQuestion();
            Console.Write($"\n{selectedQuestion}");
            ShowSpinner(5);
            reflectionDuration -= 5;
        }

        _reflectingCount++;
    }

    public new void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        ShowSpinner(3);
        RunReflectingActivity();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public static int GetReflectingCount()
    {
        return _reflectingCount;
    }
}
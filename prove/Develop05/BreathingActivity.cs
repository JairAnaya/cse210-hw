using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class BreathingActivity : Activity
{
    private static int _breathingCount = 0;
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void RunBreathingExercise()
    {
        int breatheDuration = _duration / 2;
        for (int i = 0; i < breatheDuration; i++)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.Write("Breathe out...");
            ShowCountDown(6);
        }
        _breathingCount++;
    }
    public new void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(3);
        RunBreathingExercise();
        DisplayEndingMessage();
    }
    public static int GetBreathingCount()
    {
        return _breathingCount;
    }
}
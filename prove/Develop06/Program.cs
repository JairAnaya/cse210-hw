using System;
//I add a deduction method for the simple goals, so every time a simple goal is completed, it asks for a new goal to achieve
//if the user doesn't add a new goal, it will ask the user how many points will be deducted.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Goals Program!");

        GoalManager goalManager = new GoalManager(0);

        goalManager.Start();
    }
}
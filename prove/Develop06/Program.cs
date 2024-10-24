using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Goals Program!");

        GoalManager goalManager = new GoalManager(0);

        goalManager.Start();
    }
}
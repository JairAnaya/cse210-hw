using System;

class Program
{
    static void Main(string[] args)
    {
        var running = new Running(new DateTime(2022, 11, 3), 30, 4.8);
        var cycling = new Cycling(new DateTime(2024, 10, 25), 42, 18);
        var swimming = new Swimming(new DateTime(2024, 10, 28), 35, 90);

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
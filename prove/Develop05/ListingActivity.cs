using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
public class ListingActivity : Activity
{
    private static int _listingCount = 0;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void RunListingActivity()
    {
        string selectedPrompt = GetRandomPrompt();
        Console.WriteLine($"\n---{selectedPrompt}---");
        ShowCountDown(3);

        List<string> items = GetListFromUser();
        Console.WriteLine($"\nYou listed {items.Count} items.");
        _listingCount++;
    }

    public new void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        ShowSpinner(3);
        RunListingActivity();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        Console.WriteLine("Start listing your items (type 'done' when finished):");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done")
            {
                break;
            }
            items.Add(input);
        }

        return items;
    }

    public static int GetListingCount()
    {
        return _listingCount;
    }
}
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(int score)
    {
        _score = score;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n");
            DisplayPlayerInfo();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");
            
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points\n");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        int listed = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{listed}. {goal.GetDetailsString()}");
            listed += 1;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Type of goals:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("\nWhat type of goal do you want to create?");
        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target times to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("List of goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("\nWhich goal did you complete? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        Goal selectedGoal = _goals[goalIndex];

        if (!selectedGoal.IsComplete())
        {
            selectedGoal.RecordEvent();
            _score += selectedGoal.GetPoints();

            if (selectedGoal is SimpleGoal)
            {
                Console.WriteLine("You've completed a Simple Goal. Do you want to create a new goal? (yes/no)");
                string response = Console.ReadLine().ToLower();

                if (response == "no")
                {
                    DeductPoints();
                }
                else
                {
                    CreateGoal();
                }
            }

            if (selectedGoal is ChecklistGoal)
            {
                Console.WriteLine("You've completed a Checklist Goal. Do you want to create a new goal? (yes/no)");
                string response = Console.ReadLine().ToLower();

                if (response == "no")
                {
                    DeductPoints();
                }
                else
                {
                    CreateGoal();
                }
            }
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public void DeductPoints()
    {
        Console.Write("Enter the number of points to deduct: ");
        int pointsToDeduct = int.Parse(Console.ReadLine());
        _score -= pointsToDeduct;

        if (_score < 0) _score = 0;

        Console.WriteLine($"{pointsToDeduct} points have been deducted. Your new score is {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the file name to save the goals ( .txt): ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);

            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to {fileName}");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the file name to load the goals from ( .txt): ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                _score = int.Parse(reader.ReadLine());

                _goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];

                    if (goalType == "SimpleGoal")
                    {
                        SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))
                        {
                            _isComplete = bool.Parse(parts[4])
                        };
                        _goals.Add(simpleGoal);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        EternalGoal eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        _goals.Add(eternalGoal);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        ChecklistGoal checklistGoal = new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]), 
                            int.Parse(parts[4]), 
                            int.Parse(parts[5])  
                        )
                        {
                            _amountCompleted = int.Parse(parts[6])
                        };
                        _goals.Add(checklistGoal);
                    }
                }
            }

            Console.WriteLine($"Goals loaded from {fileName}");
        }
        else
        {
            Console.WriteLine($"The file {fileName} does not exist.");
        }
    }
}
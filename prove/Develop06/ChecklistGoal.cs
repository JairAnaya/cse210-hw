public class ChecklistGoal : Goal
{
    public int _amountCompleted;
    public int _target;
    public int _bonus;
    private bool completed;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (IsComplete())
        {
            Console.WriteLine($"Goal complete! You get a bonus of {_bonus} points!");
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        completed = true;
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{(completed ? "[X]" : "[ ]")} {_shortName} ({_description}) --Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
        }
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()}) -- " +
               $"Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public bool JustCompleted()
    {
        return _amountCompleted == _target;
    }
}
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        Console.WriteLine("================================");
        Console.WriteLine("       ETERNAL QUEST");
        Console.WriteLine("================================");

        while (running)
        {
            DisplayPlayerStatus();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
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
                    running = false;
                    Console.WriteLine("Keep going on your Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayPlayerStatus()
    {
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine("--------------------------------");
    }

    // Creativity: The program includes a leveling system with
    // special titles based on the player's score. This adds
    // gamification beyond the core requirements and encourages
    // the user to continue accomplishing meaningful goals.
    private static string GetLevel()
    {
        if (_score >= 3000)
        {
            return "5 - Master of the Quest";
        }
        else if (_score >= 2000)
        {
            return "4 - Eternal Champion";
        }
        else if (_score >= 1000)
        {
            return "3 - Quest Warrior";
        }
        else if (_score >= 500)
        {
            return "2 - Apprentice";
        }
        else
        {
            return "1 - Beginner";
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nChoose the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a choice: ");

        string choice = Console.ReadLine() ?? "";

        if (choice != "1" && choice != "2" && choice != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("The goal name cannot be empty.");
            return;
        }

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("The description cannot be empty.");
            return;
        }

        int points = ReadPositiveInt("Enter the points for this goal: ");

        Goal goal;

        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                int target = ReadPositiveInt(
                    "How many times must this goal be completed? ");

                int bonus = ReadPositiveInt(
                    "Enter the bonus points for completing the goal: ");

                goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus);
                break;

            default:
                return;
        }

        _goals.Add(goal);

        Console.WriteLine($"Goal created successfully: {name}");
    }

    private static int ReadPositiveInt(string prompt)
    {
        int value;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }

    private static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("\nSelect a goal to record:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int selection = ReadPositiveInt("Enter the goal number: ");

        if (selection > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[selection - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
            return;
        }

        string previousLevel = GetLevel();

        selectedGoal.RecordEvent();

        _score += selectedGoal.GetPoints();

        Console.WriteLine(
            $"Congratulations! You earned {selectedGoal.GetPoints()} points.");

        if (selectedGoal is ChecklistGoal checklistGoal
            && checklistGoal.JustCompleted())
        {
            _score += checklistGoal.GetBonus();

            Console.WriteLine(
                $"BONUS! You earned {checklistGoal.GetBonus()} additional points!");
        }

        Console.WriteLine($"Your new score is {_score}.");

        if (GetLevel() != previousLevel)
        {
            Console.WriteLine("\n*** LEVEL UP! ***");
            Console.WriteLine($"You are now: {GetLevel()}");
        }
    }

    private static void SaveGoals()
    {
        Console.Write("Enter a filename to save your goals: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            List<string> lines = new List<string>();

            lines.Add($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                lines.Add(goal.GetStringRepresentation());
            }

            File.WriteAllLines(filename, lines);

            Console.WriteLine($"Goals saved successfully to {filename}");
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to save the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to save this file.");
        }
    }

    private static void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            string[] scoreParts = lines[0].Split('|');

            if (scoreParts.Length != 2
                || scoreParts[0] != "Score"
                || !int.TryParse(scoreParts[1], out int loadedScore)
                || loadedScore < 0)
            {
                Console.WriteLine("The file does not contain a valid score.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = CreateGoalFromString(lines[i]);

                if (goal == null)
                {
                    Console.WriteLine(
                        $"Warning: Could not load goal on line {i + 1}.");
                    return;
                }

                loadedGoals.Add(goal);
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals and score loaded successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to read the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to read this file.");
        }
    }

    private static Goal CreateGoalFromString(string data)
    {
        string[] parts = data.Split('|');

        try
        {
            switch (parts[0])
            {
                case "SimpleGoal":
                    if (parts.Length != 5
                        || !int.TryParse(parts[3], out int simplePoints)
                        || simplePoints <= 0
                        || !bool.TryParse(parts[4], out bool isComplete))
                    {
                        return null;
                    }

                    SimpleGoal simpleGoal = new SimpleGoal(
                        parts[1],
                        parts[2],
                        simplePoints);

                    if (isComplete)
                    {
                        simpleGoal.RecordEvent();
                    }

                    return simpleGoal;

                case "EternalGoal":
                    if (parts.Length != 4
                        || !int.TryParse(parts[3], out int eternalPoints)
                        || eternalPoints <= 0)
                    {
                        return null;
                    }

                    return new EternalGoal(
                        parts[1],
                        parts[2],
                        eternalPoints);

                case "ChecklistGoal":
                    if (parts.Length != 7
                        || !int.TryParse(parts[3], out int checklistPoints)
                        || checklistPoints <= 0
                        || !int.TryParse(parts[4], out int target)
                        || target <= 0
                        || !int.TryParse(parts[5], out int bonus)
                        || bonus <= 0
                        || !int.TryParse(parts[6], out int completed)
                        || completed < 0
                        || completed > target)
                    {
                        return null;
                    }

                    ChecklistGoal checklistGoal = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        checklistPoints,
                        target,
                        bonus);

                    for (int i = 0; i < completed; i++)
                    {
                        checklistGoal.RecordEvent();
                    }

                    return checklistGoal;

                default:
                    return null;
            }
        }
        catch (FormatException)
        {
            return null;
        }
    }
}
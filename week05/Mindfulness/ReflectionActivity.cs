using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    private string _lastPrompt = "";
    private string _lastQuestion = "";

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine(
            "Now ponder on each of the following questions as they relate to this experience.");

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(8);
            Console.WriteLine();
        }

        EndActivity();
    }

    private string GetRandomPrompt()
    {
        string prompt;

        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        }
        while (prompt == _lastPrompt && _prompts.Count > 1);

        _lastPrompt = prompt;

        return prompt;
    }

    private string GetRandomQuestion()
    {
        string question;

        do
        {
            int index = _random.Next(_questions.Count);
            question = _questions[index];
        }
        while (question == _lastQuestion && _questions.Count > 1);

        _lastQuestion = question;

        return question;
    }
}
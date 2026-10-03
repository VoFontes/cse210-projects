public class BreathingActivity : Activity
{
public BreathingActivity()
    : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
   {
   }

public void Run()
    {
    StartActivity();

    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

    while (DateTime.Now < endTime)
        {
        Console.WriteLine();
        Console.WriteLine("Breathe in...");
        ShowCountDown(4);

        Console.WriteLine();
        Console.WriteLine("Breathe out...");
        ShowCountDown(4);
        }

    EndActivity();
    }
}
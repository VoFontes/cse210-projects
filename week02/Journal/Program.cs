using System;

class Program
{
    // Creativity: Added additional journal prompts beyond the required five,
    // including a prompt about recognizing the hand of the Lord in my life.

    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = prompts.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry();

                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                theJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                theJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully.");
            }
        }
    }
}

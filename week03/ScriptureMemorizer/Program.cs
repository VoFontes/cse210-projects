using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and exceeding requirements:
         * This program gradually increases the number of words
         * hidden after each attempt. This makes the memorization
         * activity progressively more challenging.
         */

        Reference reference = new Reference("1 Nephi", 3, 7);

        string text =
            "And it came to pass that I, Nephi, said unto my father: " +
            "I will go and do the things which the Lord hath commanded, " +
            "for I know that the Lord giveth no commandments unto the children of men, " +
            "save he shall prepare a way for them that they may accomplish " +
            "the thing which he commandeth them.";

        Scripture scripture = new Scripture(reference, text);

        int wordsToHide = 2;

        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsToHide);

            if (wordsToHide < 5)
            {
                wordsToHide++;
            }
        }
    }
}
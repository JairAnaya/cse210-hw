using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("reference.txt");
        List<Scripture> scriptures = new List<Scripture>();

        foreach (string line in lines)
        {
            string[] parts = line.Split('|').Select(p => p.Trim()).ToArray();

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            string[] verseParts = parts[2].Split('-');
            int startVerse = int.Parse(verseParts[0]);
            int endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : startVerse;
            string text = parts[3];

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(reference, text);
            scriptures.Add(scripture);
        }

        Console.WriteLine("Please select a scripture:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference.GetDisplayText()}");
        }

        int selectedScriptureIndex = -1;
        while (selectedScriptureIndex < 0 || selectedScriptureIndex >= scriptures.Count)
        {
            Console.Write("Enter the number of the scripture you want to select: ");
            if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= scriptures.Count)
            {
                selectedScriptureIndex = selection - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }
        }

        Scripture selectedScripture = scriptures[selectedScriptureIndex];
        Reference selectedReference = selectedScripture.Reference;

        while (true)
        {
            Console.Clear();
            Console.Write($"{selectedReference.GetDisplayText()} ");
            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                break;
            }
        }
    }
}
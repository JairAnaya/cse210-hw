using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Journal journal = new Journal();
        journal.Prompt.LoadPrompts();
        
        int selection = 1;
        while (selection != 5)
        {
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            int option = int.Parse(Console.ReadLine());
            selection = option;
            
            switch (selection)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    journal.LoadFromFile();
                    break;
                case 4:
                    journal.SaveToFile();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again.");
                    break;
            }
        }
    }
}
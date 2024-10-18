using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an activity:\n1. Breathing Activity\n2. Reflection Activity\n3. Listing Activity\n4. Quit\n");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                Console.Clear();
                ReflectingActivity reflection = new ReflectingActivity();
                reflection.Run();
            }
            else if (choice == "3")
            {
                Console.Clear();
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine($"\nBreathing Activity was performed {BreathingActivity.GetBreathingCount()} times.");
                Console.WriteLine($"Reflecting Activity was performed {ReflectingActivity.GetReflectingCount()} times.");
                Console.WriteLine($"Listing Activity was performed {ListingActivity.GetListingCount()} times.");
                break;
            }
        }
    }
}
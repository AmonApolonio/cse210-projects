using System;

//CSE210 - Amon Apolonio Vieira

//#Exceeding Requirements
//1. Make sure no random prompts/questions are selected until they have all been used at least once in that session.
//2. Keeping a log of how many times activities were performed.

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("     1. Start breathing activity");
            Console.WriteLine("     2. Start reflecting activity");
            Console.WriteLine("     3. Start listing activity");
            Console.WriteLine("     4. Show activity log");
            Console.WriteLine("     5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    reflectingCount++;
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;
                 case "4":
                    Console.WriteLine("Activity Log:");
                    Console.WriteLine($"Breathing activity: {breathingCount} times");
                    Console.WriteLine($"Reflecting activity: {reflectingCount} times");
                    Console.WriteLine($"Listing activity: {listingCount} times");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
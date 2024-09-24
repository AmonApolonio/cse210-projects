using System;

//CSE210 - Amon Apolonio Vieira

//#Exceeding Requirements
//1. The document can be saved as JSON or CSV
//2. The possible prompts are saved in a JSON file
class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");

        string option;
        do
        {
            Console.WriteLine("=========================");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load journal from a JSON file");
            Console.WriteLine("4. Save journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("=========================");
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("=========================");
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        } while (option != "5");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);

        string userInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            Entry newEntry = new Entry
            {
                Date = DateTime.Now.ToShortDateString(),
                PromptText = prompt,
                EntryText = userInput
            };
            journal.AddEntry(newEntry);
            Console.WriteLine("=========================");
            Console.WriteLine("Entry saved!");
        }
        else
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Entry was empty and not saved.");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.WriteLine("=========================");
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    static void SaveJournal(Journal journal)
    {
        Console.WriteLine("=========================");
        Console.Write("Enter the filename to save to (without extension): ");
        string filename = Console.ReadLine();

        Console.WriteLine("Choose the format to save:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. CSV");
        Console.Write("Enter 1 or 2: ");
        string formatChoice = Console.ReadLine();

        switch (formatChoice)
        {
            case "1":
                journal.SaveToFile(filename, "json");
                break;
            case "2":
                journal.SaveToFile(filename, "csv");
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to JSON format.");
                journal.SaveToFile(filename, "json");
                break;
        }
    }
}

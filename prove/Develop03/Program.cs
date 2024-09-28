using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//CSE210 - Amon Apolonio Vieira

//#Exceeding Requirements
//1. The scriptures can be loaded from a file, 
//so the system asks the user if they want to use the standard scriptures if the list of scriptures is empty.
//2. The user can change how many words are hidden per entry by selecting a difficulty level when starting the game.

class Program
{
    static void Main(string[] args)
    {
        string option;
        List<Scripture> scriptures = new();
        Console.WriteLine("Welcome to Scripture Memorizer!");

        do
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.Write("1. Play\n2. Add Scripture\n3. Quit\n");
            Console.Write("What would you like to do? ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    PlayGame(scriptures);
                    break;
                case "2":
                    AddScripture(scriptures);
                    break;
                case "3":
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("Sorry the option you choose is not available");
                    break;
            }
        } while (option != "3");
    }

    static void AddScripture(List<Scripture> scriptures)
    {
        Console.WriteLine("Enter the book: ");
        string book = Console.ReadLine();
        Console.WriteLine("Enter the chapter: ");
        int chapter = int.Parse(Console.ReadLine());

        Scripture scripture = new Scripture(book, chapter);

        while (true)
        {
            Console.WriteLine("Enter the verse number, to quit enter (q): ");
            string verserNumber = Console.ReadLine();
            if (verserNumber == "q")
            {
                break;
            }

            Console.WriteLine("Enter the verse text: ");
            try{
                scripture.SetVerse(int.Parse(verserNumber), Console.ReadLine());
            }catch{
                Console.WriteLine("Error adding this last verse");
                break;
            }
            
        }

        scriptures.Add(scripture);
        Console.WriteLine("Scripture added successfully!");
    }

    static void PlayGame(List<Scripture> scriptures)
    {
        if (scriptures.Count == 0)
        {
            Console.WriteLine("\n===================================================");
            Console.WriteLine("There are no scriptures available yet. Would you like to:");
            Console.WriteLine("1. Add scriptures manually.");
            Console.WriteLine("2. Load standard scriptures");
            Console.Write("Please choose an option (1 or 2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddScripture(scriptures);
            }
            else if (choice == "2")
            {
                scriptures.AddRange(LoadStandardScriptures("scriptureMastery.json"));
                Console.WriteLine("Standard scriptures loaded.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please add scriptures manually.");
                AddScripture(scriptures);
            }
        }

        if (scriptures.Count > 0)
        {
            int wordsToHide = SelectDifficulty();
            string gameOption;
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, scriptures.Count);
            Scripture scripture = scriptures[randomIndex];
            List<Verse> cacheVerses = scripture.GetVerses().Select(verse => verse.Clone()).ToList();

            while (true)
            {
                Console.Clear();
                scripture.DisplayReference();
                scripture.DisplayVerses();
                Console.Write("Press enter to continue or type 'quit' to finish: ");
                gameOption = Console.ReadLine();

                if (gameOption == "quit" || scripture.IsCompletelyHidden())
                {
                    scripture.SetVerses(cacheVerses);
                    break;
                }

                scripture.HideRandomWords(wordsToHide);
            }
        }
    }

    static int SelectDifficulty()
    {
        Console.WriteLine("\n===================================================");
        Console.WriteLine("Select difficulty level:");
        Console.WriteLine("1. Easy (2 words)");
        Console.WriteLine("2. Medium (3 words)");
        Console.WriteLine("3. Hard (4 words)");
        Console.WriteLine("4. Super Hard (6 words)");
        Console.Write("Enter your choice (1-4): ");

        int choice = int.Parse(Console.ReadLine());
        
        return choice switch
        {
            1 => 2,
            2 => 3,
            3 => 4,
            4 => 6,
            _ => 2
        };
    }

    public static List<Scripture> LoadStandardScriptures(string filePath)
    {
        string jsonString = File.ReadAllText("scriptureMastery.json");
        var scriptureData = JsonSerializer.Deserialize<ScriptureCollection>(jsonString);
        List<Scripture> scriptures = new List<Scripture>();

        foreach (var scriptureEntry in scriptureData.scriptures)
        {
            Scripture scripture = new Scripture(scriptureEntry.book, scriptureEntry.chapter);
            foreach (var verseEntry in scriptureEntry.verses)
            {
                scripture.SetVerse(verseEntry.verseNumber, verseEntry.text);
            }
            scriptures.Add(scripture);
        }

        return scriptures;
    }
}

using System;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":

                    Console.WriteLine("\n=========List of Goals=========");
                    ListGoalNames();
                    Console.WriteLine("===============================");
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
        
        string rank = GetPlayerRank(_score);
        Console.WriteLine($"Player Rank: {rank}");
    }

    private string GetPlayerRank(int score)
    {
        string[] ranks = { "Iron", "Bronze", "Silver", "Gold", "Platinum", "Diamond", "Master", "Grandmaster", "Challenger" };
        int rankIndex = score / 100;

        if (rankIndex >= ranks.Length)
        {
            return $"Challenger {ToRoman(rankIndex - (ranks.Length - 1))}";
        }

        return ranks[rankIndex];
    }

    private string ToRoman(int number)
    {
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return thousands[number / 1000] +
            hundreds[(number % 1000) / 100] +
            tens[(number % 100) / 10] +
            units[number % 10];
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. { _goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            Console.WriteLine("Goal Details:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"Goal {i + 1}: {_goals[i].GetDetailsString()}");
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string goalType;
        do
        {
            Console.Write("Which type of goal would you like to create? (Enter the number): ");
            goalType = Console.ReadLine();
            
            if (goalType != "1" && goalType != "2" && goalType != "3")
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        } while (goalType != "1" && goalType != "2" && goalType != "3");

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (goalType)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;

            default:
                goal = new SimpleGoal(name, description, points);
                break;
        }

        if (goal != null)
        {
            _goals.Add(goal);
        }
        Console.Clear();
    }

    public void RecordEvent()
    {
        Console.Clear();
        ListGoalNames();

        Console.Write("Select the number of the goal you accomplished: ");
        
        if (int.TryParse(Console.ReadLine(), out int userSelection))
        {
            int goalIndex = userSelection - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                _score += _goals[goalIndex].RecordEvent();
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
        Console.Clear();
    }

    public void SaveGoals()
    {
        Console.Write("Enter the file name to save the goals: ");
        string fileName = Console.ReadLine();

        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";
        }

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to {fileName}");
    }

    public void LoadGoals()
    {
        Console.Clear();
        string selectedFile = SelectFileToLoad();

        if (selectedFile == null)
        {
            return;
        }

        _goals = new List<Goal>();

        using (StreamReader reader = new StreamReader(selectedFile))
        {
            if (int.TryParse(reader.ReadLine(), out int loadedScore))
            {
                _score = loadedScore;
            }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        string name = goalData[0];
                        string description = goalData[1];
                        int points = int.Parse(goalData[2]);
                        bool isComplete = bool.Parse(goalData[3]);
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        _goals.Add(simpleGoal);
                        break;

                    case "EternalGoal":
                        name = goalData[0];
                        description = goalData[1];
                        points = int.Parse(goalData[2]);
                        EternalGoal eternalGoal = new EternalGoal(name, description, points);
                        _goals.Add(eternalGoal);
                        break;

                    case "ChecklistGoal":
                        name = goalData[0];
                        description = goalData[1];
                        points = int.Parse(goalData[2]);
                        int amountCompleted = int.Parse(goalData[3]);
                        int target = int.Parse(goalData[4]);
                        int bonus = int.Parse(goalData[5]);
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded successfully");
    }

    public string SelectFileToLoad()
    {
        string directoryPath = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(directoryPath, "*.txt");

        if (files.Length == 0)
        {
            Console.WriteLine("No .txt files available to load from.");
            return null;
        }

        Console.WriteLine("Select a file to load from:");

        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        int selectedIndex = -1;
        while (selectedIndex < 1 || selectedIndex > files.Length)
        {
            Console.Write("Enter the number of the file to load: ");
            if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 1 && selectedIndex <= files.Length)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
            }
        }

        return files[selectedIndex - 1];
    }
}
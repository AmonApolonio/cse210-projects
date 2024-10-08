class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _promptsCache = new List<string>();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    private string GetRandomPrompt()
    {
        if (_promptsCache.Count == _prompts.Count)
        {
            _promptsCache.Clear();
        }

        Random random = new Random();
        string selectedPrompt;

        do
        {
            selectedPrompt = _prompts[random.Next(_prompts.Count)];
        } while (_promptsCache.Contains(selectedPrompt));

        _promptsCache.Add(selectedPrompt);

        return selectedPrompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        Console.WriteLine("Start listing items. Press enter after each item and type 'done' when finished:");
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
            items.Add(input);
        }
        return items;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many reponses you can to the following prompt:");
        Console.Write("  --- ");
        Console.Write(GetRandomPrompt());
        Console.Write(" ---\n\n");
        PerformCountdown("You may begin in", 5);
        List<string> items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"You listed {_count} items.\n");
        DisplayEndingMessage();
    }
}
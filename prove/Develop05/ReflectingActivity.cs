class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What challenges did you face during this experience?",
        "How did you overcome obstacles you encountered?",
        "What advice would you give someone else facing a similar situation?",
        "What part of this experience surprised you the most?",
        "How did this experience impact your perspective or way of thinking?",
        "If you could do this again, what would you do differently?",
        "How did this experience help you grow personally or professionally?",
        "How did others contribute to the success of this experience?",
        "What skills or qualities did you rely on during this experience?",
        "How did this experience align with your values or goals?",
        "What emotions did you experience throughout this process?",
        "How would you describe this experience to someone who wasn't there?",
        "What are you most proud of from this experience?",
        "How did this experience change the way you approach challenges?",
        "What were the key takeaways from this experience?",
        "How did this experience affect your relationships with others?",
        "How has this experience shaped your future plans?"
    };

    private List<string> _questionsCache = new List<string>();
    private List<string> _promptsCache = new List<string>();

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
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

    private string GetRandomQuestion()
    {
        if (_questionsCache.Count == _questions.Count)
        {
            _questionsCache.Clear();
        }

        Random random = new Random();
        string selectedQuestion;

        do
        {
            selectedQuestion = _questions[random.Next(_questions.Count)];
        } while (_questionsCache.Contains(selectedQuestion));

        _questionsCache.Add(selectedQuestion);

        return selectedQuestion;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.Write("  --- ");
        Console.Write(GetRandomPrompt());
        Console.Write(" ---\n\n");
    }

    public void DisplayQuestions()
    {
        Console.Write("When you have something in mind, press Enter to begin... ");
        Console.ReadLine();
        PerformCountdown("You may begin in", 3);

        for (int i = 0; i < _duration; i += 5)
        {
            Console.Write(" > ");
            Console.Write(GetRandomQuestion() + "  ");
            ShowSpinner(5);
            Console.Write("\n");
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}
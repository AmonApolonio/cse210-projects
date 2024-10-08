class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        int breathingCycles = _duration / 6;
        
        for (int i = 0; i < breathingCycles; i++)
        {
            PerformBreathing("Breathe in", 3);
            PerformBreathing("Now breathe out", 3);
            Console.WriteLine("");
        }

        int remainingSeconds = _duration % 6;
        if (remainingSeconds > 0)
        {
            PerformBreathing("Breathe in", remainingSeconds / 2);
            PerformBreathing("Now breathe out", remainingSeconds - (remainingSeconds / 2));
        }

        DisplayEndingMessage();
    }

    private void PerformBreathing(string action, int countdown)
    {
        for (int count = countdown; count >= 0; count--)
        {
            Console.Write($"{action}...{count}\r");
            if (count == 0)
                Console.Write($"{action}...        \r");

            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

}
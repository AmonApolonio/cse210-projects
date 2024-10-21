using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 10, 19), 20, 5.0),
            new Cycling(new DateTime(2024, 10, 20), 40, 12.0),
            new Swimming(new DateTime(2024, 10, 21), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
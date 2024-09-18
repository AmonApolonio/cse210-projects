using System;

class Program
{
    static void Main(string[] args)
    {
        // I already know how to code in C#, so I took on the challenge of making it more efficient.
        Console.Write("What is your grade percentage? ");
        int percent = int.Parse(Console.ReadLine());

        // Doing it this way is better than using many "if" and "else" statements.
        string letter = percent >= 90 ? "A" :
                        percent >= 80 ? "B" :
                        percent >= 70 ? "C" :
                        percent >= 60 ? "D" : "F";

        Console.WriteLine($"Your grade is: {letter}");
        Console.WriteLine(percent >= 70 ? "You passed!" : "Better luck next time!");
    }
}
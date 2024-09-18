using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            // Random number from 1 to 100.
            int magicNumber = randomGenerator.Next(1, 101);
            
            int guess = -1;
            int guessCount = 0;

            // The guessing loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    //#Stretch Challenge 1 - Keeping track how many guesses the user has made
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            //#Stretch Challenge 2 - Asking if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
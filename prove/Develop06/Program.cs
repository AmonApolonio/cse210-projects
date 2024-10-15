using System;

//CSE210 - Amon Apolonio Vieira

//#Exceeding Requirements
//1. I added a player ranking system where every 100 points increases the player's rank, 
// progressing through tiers like Iron, Bronze, Silver, up to Challenger. 
// After reaching Challenger, additional ranks are represented using Roman numerals (like: Challenger I, II, III, etc.). 

//2. I added a menu to help the user load from a file by listing available .txt files and letting them select one by number

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
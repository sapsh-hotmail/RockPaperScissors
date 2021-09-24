using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;
using System;

namespace ConsoleGame.Code.Services
{
    public class ConsoleHumanDecisionService : IHumanDecisionService
    {
        public Decision GetHumanDecision()
        {
            while (true)
            {
                Console.WriteLine("Provide decision. Press");
                Console.WriteLine("1 For Rock");
                Console.WriteLine("2 For Paper");
                Console.WriteLine("3 For Scissors");
                var input = Console.ReadLine();

                switch (input.Trim())
                {
                    case "1":
                        return Decision.ROCK;

                    case "2":
                        return Decision.PAPER;

                    case "3":
                        return Decision.SCISSORS;

                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }
            }
        }
    }
}
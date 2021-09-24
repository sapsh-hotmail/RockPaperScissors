using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Code.Services
{
    public class RandomBotDecisionService : IBotDecisionService
    {
        public Decision GetDecision()
        {
            var decisions = new List<Decision> {
                Decision.ROCK,
                Decision.PAPER,
                Decision.SCISSORS,
            };

            var r = new Random();
            var nextChoice = r.Next(0, 3);
            return decisions[nextChoice];
        }
    }
}
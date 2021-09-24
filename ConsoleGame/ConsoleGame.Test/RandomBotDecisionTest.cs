using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services;
using System.Collections.Generic;
using Xunit;

namespace ConsoleGame.Test
{
    public class RandomBotDecisionTest
    {
        [Fact]
        public void Bot_decision_should_be_random()
        {
            RandomBotDecisionService botDecisionService = new RandomBotDecisionService();
            var decisions = new List<Decision>();
            for (int i = 0; i < 15; i++)
            {
                decisions.Add(botDecisionService.GetDecision());
            }

            Assert.Contains(Decision.PAPER, decisions);
            Assert.Contains(Decision.ROCK, decisions);
            Assert.Contains(Decision.SCISSORS, decisions);
        }
    }
}
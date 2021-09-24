using ConsoleGame.Code.Factory;
using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services;
using ConsoleGame.Code.Services.Interface;
using System;
using Xunit;

namespace ConsoleGame.Test
{
    public class DecisionServiceTest
    {
        private IBotDecisionService _botDecisionService;
        private IHumanDecisionService _humanDecisionService;

        public DecisionServiceTest()
        {
            _botDecisionService = new RandomBotDecisionService();
            _humanDecisionService = new ConsoleHumanDecisionService();
        }

        [Fact]
        public void Exception_should_be_thrown_when_human_decision_dependency_is_null()
        {
            _humanDecisionService = null;

            Assert.Throws<ArgumentNullException>(() => new DecisionService(_humanDecisionService, _botDecisionService));
        }

        [Fact]
        public void Exception_should_be_thrown_when_bot_decision_dependency_is_null()
        {
            _botDecisionService = null;

            Assert.Throws<ArgumentNullException>(() => new DecisionService(_humanDecisionService, _botDecisionService));
        }

        [Fact]
        public void Decision_should_be_return_when_player_type_is_Bot()
        {
            var player = new BotPlayerFactory("TestBotPlayer").GetPlayer();

            var decisionService = new DecisionService(_humanDecisionService, _botDecisionService);
            var decision = decisionService.GetDecisionForPlayer(player);

            Assert.IsType<Decision>(decision);
        }
    }
}
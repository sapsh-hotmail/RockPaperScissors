using ConsoleGame.Code;
using ConsoleGame.Code.Factory;
using ConsoleGame.Code.Services;
using ConsoleGame.Code.Services.Interface;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ConsoleGame.Test
{
    public class GameRunnerTest
    {
        private readonly IGameResultService _gameResultService;
        private readonly IDecisionService _decisionService;
        private readonly ILogger<GameRunner> _logger;
        private readonly IRoundResultService _roundResultService;
        private readonly IBotDecisionService _botDecisionService;
        private readonly IHumanDecisionService _humanDecisionService;

        public GameRunnerTest()
        {
            _roundResultService = new RoundResultService();
            _botDecisionService = new RandomBotDecisionService();
            _humanDecisionService = new ConsoleHumanDecisionService();

            _gameResultService = new GameResultService(_roundResultService);
            _decisionService = new DecisionService(_humanDecisionService, _botDecisionService);
            _logger = new Mock<ILogger<GameRunner>>().Object;
        }

        [Fact]
        public void Game_should_be_run_without_error_for_Bot_players()
        {
            var player1 = new BotPlayerFactory("BotPlayer1").GetPlayer();
            var player2 = new BotPlayerFactory("BotPlayer2").GetPlayer();
            int winCount = 3;
            var runner = new GameRunner(_gameResultService, _decisionService, _logger);

            var winner = runner.Play(player1, player2, winCount);

            Assert.NotNull(winner);
        }
    }
}
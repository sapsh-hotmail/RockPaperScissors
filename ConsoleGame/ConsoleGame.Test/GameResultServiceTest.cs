using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services;
using Xunit;

namespace ConsoleGame.Test
{
    public class GameResultServiceTest
    {
        private readonly IRoundResultService _roundResultService;

        public GameResultServiceTest()
        {
            _roundResultService = new RoundResultService();
        }

        [Fact]
        public void Add_round_should_increase_win_count()
        {
            GameResultService gameResultService = new GameResultService(_roundResultService);

            var result = gameResultService.AddRound(Decision.PAPER, Decision.SCISSORS);

            Assert.Equal(RoundResult.PLAYER_2_WIN, result);
            Assert.Equal(1, gameResultService.Player2WinCount);
        }

        [Fact]
        public void Tie_should_not_increase_win_count()
        {
            GameResultService gameResultService = new GameResultService(_roundResultService);

            gameResultService.AddRound(Decision.PAPER, Decision.SCISSORS);
            var result = gameResultService.AddRound(Decision.PAPER, Decision.PAPER);

            Assert.Equal(RoundResult.TIE, result);
            Assert.Equal(1, gameResultService.Player2WinCount);
        }
    }
}
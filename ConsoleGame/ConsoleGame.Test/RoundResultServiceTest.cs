using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services;
using Xunit;

namespace ConsoleGame.Test
{
    public class RoundResultServiceTest
    {
        [Fact]
        public void Scissors_should_win_over_Paper()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.PAPER, Decision.SCISSORS);

            Assert.Equal(RoundResult.PLAYER_2_WIN, result);
        }

        [Fact]
        public void Rock_should_win_over_Scissors()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.ROCK, Decision.SCISSORS);

            Assert.Equal(RoundResult.PLAYER_1_WIN, result);
        }

        [Fact]
        public void Paper_should_win_over_Rock()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.ROCK, Decision.PAPER);

            Assert.Equal(RoundResult.PLAYER_2_WIN, result);
        }

        [Fact]
        public void Result_should_tie_over_both_Paper()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.PAPER, Decision.PAPER);

            Assert.Equal(RoundResult.TIE, result);
        }

        [Fact]
        public void Result_should_tie_over_both_Rock()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.ROCK, Decision.ROCK);

            Assert.Equal(RoundResult.TIE, result);
        }

        [Fact]
        public void Result_should_tie_over_both_Scissors()
        {
            RoundResultService roundResultService = new RoundResultService();
            var result = roundResultService.GetRoundResult(Decision.ROCK, Decision.ROCK);

            Assert.Equal(RoundResult.TIE, result);
        }
    }
}
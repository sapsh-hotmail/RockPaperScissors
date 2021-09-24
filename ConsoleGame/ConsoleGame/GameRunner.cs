using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;

namespace ConsoleGame.Code
{
    public class GameRunner
    {
        private int _gameUptoWinCount;
        private readonly IGameResultService _gameResultService;
        private readonly IDecisionService _decisionService;

        public GameRunner(IGameResultService gameResultService,
            IDecisionService decisionService)
        {
            _gameResultService = gameResultService;
            _decisionService = decisionService;
        }

        public Player Play(Player player1, Player player2, int gameUptoWinCount)
        {
            _gameUptoWinCount = gameUptoWinCount;

            do
            {
                var decisionP1 = _decisionService.GetDecisionForPlayer(player1);
                var decisionP2 = _decisionService.GetDecisionForPlayer(player2);

                var result = _gameResultService.AddRound(decisionP1, decisionP2);
                if (result != RoundResult.TIE)
                {
                    var winner = IsPlayerWinUptoCount(player1, player2);
                    if (winner != null)
                    {
                        return winner;
                    }
                }
            } while (true);
        }

        private Player IsPlayerWinUptoCount(Player player1, Player player2)
        {
            if (_gameResultService.Player1WinCount > _gameResultService.Player2WinCount)
            {
                return _gameResultService.Player1WinCount >= _gameUptoWinCount ? player1 : null;
            }
            else
            {
                return _gameResultService.Player2WinCount >= _gameUptoWinCount ? player2 : null;
            }
        }
    }
}
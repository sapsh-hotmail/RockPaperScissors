using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleGame.Code
{
    public class GameRunner
    {
        private int _gameUptoWinCount;
        private readonly IGameResultService _gameResultService;
        private readonly IDecisionService _decisionService;
        private readonly ILogger _logger;

        public GameRunner(IGameResultService gameResultService,
            IDecisionService decisionService,
            ILogger<GameRunner> logger)
        {
            if (gameResultService == null) throw new ArgumentNullException(nameof(gameResultService));
            if (decisionService == null) throw new ArgumentNullException(nameof(decisionService));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _gameResultService = gameResultService;
            _decisionService = decisionService;
            _logger = logger;
        }

        public Player Play(Player player1, Player player2, int gameUptoWinCount)
        {
            _gameUptoWinCount = gameUptoWinCount;

            do
            {
                try
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
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Getting error while playing round. Current round is restarted.");
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
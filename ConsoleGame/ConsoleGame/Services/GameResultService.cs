using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;
using System;
using System.Collections.Generic;

namespace ConsoleGame.Code.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IRoundResultService _roundResultService;
        private Dictionary<int, RoundDecision> _roundSummary = new Dictionary<int, RoundDecision>();
        private int _player1WinCount = 0;
        private int _player2WinCount = 0;
        private int _tieCount = 0;
        private int _round = 0;

        public int Player1WinCount
        {
            get { return _player1WinCount; }
        }

        public int Player2WinCount
        {
            get { return _player2WinCount; }
        }

        public int TieCount
        {
            get { return _tieCount; }
        }

        public GameResultService(IRoundResultService roundResultService)
        {
            _roundResultService = roundResultService;
        }

        public RoundResult AddRound(Decision player1Decision, Decision player2Decision)
        {
            _round++;

            var result = _roundResultService.GetRoundResult(player1Decision, player2Decision);
            Console.WriteLine($"Winner of round {_round} is {result}");

            var roundDecision = new RoundDecision
            {
                RoundCount = _round,
                Player1Decision = player1Decision,
                Player2Decision = player2Decision,
                Result = result
            };

            _roundSummary.Add(_round, roundDecision);

            switch (result)
            {
                case RoundResult.PLAYER_1_WIN:
                    _player1WinCount++;
                    break;

                case RoundResult.PLAYER_2_WIN:
                    _player2WinCount++;
                    break;

                case RoundResult.TIE:
                    _tieCount++;
                    break;
            }

            return result;
        }
    }
}
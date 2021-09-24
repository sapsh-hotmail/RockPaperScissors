using ConsoleGame.Code.Models;

namespace ConsoleGame.Code.Services.Interface
{
    public interface IGameResultService
    {
        int Player1WinCount { get; }

        int Player2WinCount { get; }

        int TieCount { get; }

        RoundResult AddRound(Decision player1Decision, Decision player2Decision);
    }
}
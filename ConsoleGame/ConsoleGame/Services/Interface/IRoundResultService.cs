using ConsoleGame.Code.Models;

namespace ConsoleGame.Code.Services
{
    public interface IRoundResultService
    {
        public RoundResult GetRoundResult(Decision player1Decision, Decision player2Decision);
    }
}
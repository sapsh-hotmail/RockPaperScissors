using ConsoleGame.Code.Models;
using System;

namespace ConsoleGame.Code.Services
{
    public class RoundResultService : IRoundResultService
    {
        public RoundResult GetRoundResult(Decision player1Decision, Decision player2Decision)
        {
            if (player1Decision == player2Decision)
                return RoundResult.TIE;

            switch (player1Decision)
            {
                case Decision.PAPER:
                    if (player2Decision == Decision.SCISSORS)
                        return RoundResult.PLAYER_2_WIN;
                    else
                        return RoundResult.PLAYER_1_WIN;

                case Decision.ROCK:
                    if (player2Decision == Decision.PAPER)
                        return RoundResult.PLAYER_2_WIN;
                    else
                        return RoundResult.PLAYER_1_WIN;

                case Decision.SCISSORS:
                    if (player2Decision == Decision.ROCK)
                        return RoundResult.PLAYER_2_WIN;
                    else
                        return RoundResult.PLAYER_1_WIN;

                default:
                    throw new InvalidOperationException("Operation Invalid");
            }
        }
    }
}
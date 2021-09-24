namespace ConsoleGame.Code.Models
{
    public enum Decision
    {
        ROCK = 1,
        PAPER = 2,
        SCISSORS = 3
    }

    public enum PlayerType
    {
        Human,
        Bot
    }

    public enum RoundResult
    {
        PLAYER_1_WIN,
        PLAYER_2_WIN,
        TIE
    }
}
namespace ConsoleGame.Code.Models
{
    public abstract class Player
    {
        public abstract string PlayerName { get; }

        public abstract PlayerType PlayerType { get; }
    }
}
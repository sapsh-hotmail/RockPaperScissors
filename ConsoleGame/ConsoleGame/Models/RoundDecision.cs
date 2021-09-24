namespace ConsoleGame.Code.Models
{
    public class RoundDecision
    {
        public int RoundCount { get; set; }

        public Decision Player1Decision { get; set; }

        public Decision Player2Decision { get; set; }

        public RoundResult Result { get; set; }
    }
}
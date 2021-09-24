namespace ConsoleGame.Code.Models
{
    public class HumanPlayer : Player
    {
        private readonly PlayerType _playerType;

        private string _name;

        public HumanPlayer(string name)
        {
            _playerType = PlayerType.Human;
            _name = name;
        }

        public override string PlayerName
        {
            get { return _name; }
        }

        public override PlayerType PlayerType
        {
            get { return _playerType; }
        }
    }
}
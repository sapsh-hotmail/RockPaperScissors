using ConsoleGame.Code.Models;

namespace ConsoleGame.Code.Factory
{
    public class HumanPlayerFactory : PlayerFactory
    {
        private string _playerName;

        public HumanPlayerFactory(string name)
        {
            _playerName = name;
        }

        public override Player GetPlayer()
        {
            return new HumanPlayer(_playerName);
        }
    }
}
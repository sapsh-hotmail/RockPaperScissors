using ConsoleGame.Code.Models;

namespace ConsoleGame.Code.Factory
{
    public class BotPlayerFactory : PlayerFactory
    {
        private string _playerName;

        public BotPlayerFactory(string name)
        {
            _playerName = name;
        }

        public override Player GetPlayer()
        {
            return new BotPlayer(_playerName);
        }
    }
}
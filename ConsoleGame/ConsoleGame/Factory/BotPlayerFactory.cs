using ConsoleGame.Code.Models;
using System;

namespace ConsoleGame.Code.Factory
{
    public class BotPlayerFactory : PlayerFactory
    {
        private string _playerName;

        public BotPlayerFactory(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _playerName = name;
        }

        public override Player GetPlayer()
        {
            return new BotPlayer(_playerName);
        }
    }
}
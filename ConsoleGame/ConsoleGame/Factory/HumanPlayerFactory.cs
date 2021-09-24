using ConsoleGame.Code.Models;
using System;

namespace ConsoleGame.Code.Factory
{
    public class HumanPlayerFactory : PlayerFactory
    {
        private string _playerName;

        public HumanPlayerFactory(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _playerName = name;
        }

        public override Player GetPlayer()
        {
            return new HumanPlayer(_playerName);
        }
    }
}
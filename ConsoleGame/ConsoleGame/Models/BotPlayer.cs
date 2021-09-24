using System;

namespace ConsoleGame.Code.Models
{
    public class BotPlayer : Player
    {
        private readonly PlayerType _playerType;

        private string _name;

        public BotPlayer(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _playerType = PlayerType.Bot;
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
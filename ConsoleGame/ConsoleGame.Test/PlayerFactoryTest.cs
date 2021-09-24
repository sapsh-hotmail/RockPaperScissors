using ConsoleGame.Code.Factory;
using ConsoleGame.Code.Models;
using System;
using Xunit;

namespace ConsoleGame.Test
{
    public class PlayerFactoryTest
    {
        [Fact]
        public void Human_player_should_be_created()
        {
            var playerName = "TestHumanPlayer";
            var player = new HumanPlayerFactory(playerName).GetPlayer();

            Assert.NotNull(player);
            Assert.Equal(playerName, player.PlayerName);
            Assert.Equal(PlayerType.Human, player.PlayerType);
        }

        [Fact]
        public void Human_player_should_not_be_created_when_name_is_null()
        {
            var playerName = string.Empty;
            Assert.Throws<ArgumentNullException>(() => new HumanPlayerFactory(playerName).GetPlayer());
        }

        [Fact]
        public void Bot_player_should_be_created()
        {
            var playerName = "TestBotPlayer";
            var player = new BotPlayerFactory(playerName).GetPlayer();

            Assert.NotNull(player);
            Assert.Equal(playerName, player.PlayerName);
            Assert.Equal(PlayerType.Bot, player.PlayerType);
        }

        [Fact]
        public void Bot_player_should_not_be_created_when_name_is_null()
        {
            var playerName = string.Empty;
            Assert.Throws<ArgumentNullException>(() => new BotPlayerFactory(playerName).GetPlayer());
        }
    }
}
using ConsoleGame.Code.Factory;
using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services;
using ConsoleGame.Code.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleGame.Code
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //setup our DI
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var gameResultService = serviceProvider.GetService<IGameResultService>();
            var decisionService = serviceProvider.GetService<IDecisionService>();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            var loggerGameRunner = serviceProvider.GetService<ILogger<GameRunner>>();

            Player player1 = null;
            Player player2 = null;
            do
            {
                Console.WriteLine("Select player 1 type");
                Console.WriteLine("Press 1 for Human player");
                Console.WriteLine("Press 2 for Bot player");
                var input = Console.ReadLine();
                Console.WriteLine("Enter player name");
                var playername = Console.ReadLine();

                if (input.Trim() == "1")
                {
                    player1 = new HumanPlayerFactory(playername).GetPlayer();
                }
                else if (input.Trim() == "2")
                {
                    player1 = new BotPlayerFactory(playername).GetPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (player1 == null);

            do
            {
                Console.WriteLine("Select player 2 type");
                Console.WriteLine("Press 1 for Human player");
                Console.WriteLine("Press 2 for Bot player");
                var input = Console.ReadLine();
                Console.WriteLine("Enter player name");
                var playername = Console.ReadLine();

                if (input.Trim() == "1")
                {
                    player2 = new HumanPlayerFactory(playername).GetPlayer();
                }
                else if (input.Trim() == "2")
                {
                    player2 = new BotPlayerFactory(playername).GetPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (player2 == null);

            int gameUptoWinCount;
            do
            {
                Console.WriteLine("Enter win round count:");
                var input = Console.ReadLine();

                int.TryParse(input, out gameUptoWinCount);
            } while (gameUptoWinCount <= 0);

            bool playAgain = false;
            do
            {
                try
                {
                    var gameRunner = new GameRunner(gameResultService, decisionService, loggerGameRunner);
                    var winner = gameRunner.Play(player1, player2, gameUptoWinCount);
                    Console.WriteLine($"Winner is {winner.PlayerName}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Exception is thrown while playing game. The game will continue from last saved round.");
                    playAgain = true;
                }
            } while (playAgain);
        }

        /// <summary>
        /// Configure dependencies
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(configure => configure.AddConsole())
                .AddTransient<IHumanDecisionService, ConsoleHumanDecisionService>()
                .AddTransient<IBotDecisionService, RandomBotDecisionService>()
                .AddTransient<IDecisionService, DecisionService>()
                .AddScoped<IRoundResultService, RoundResultService>()
                .AddScoped<IGameResultService, GameResultService>();
        }
    }
}
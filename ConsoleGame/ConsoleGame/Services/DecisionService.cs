using ConsoleGame.Code.Models;
using ConsoleGame.Code.Services.Interface;
using System;

namespace ConsoleGame.Code.Services
{
    public class DecisionService : IDecisionService
    {
        private readonly IHumanDecisionService _humanDecisionService;
        private readonly IBotDecisionService _botDecisionService;

        public DecisionService(IHumanDecisionService humanDecisionService,
            IBotDecisionService botDecisionService)
        {
            _humanDecisionService = humanDecisionService;
            _botDecisionService = botDecisionService;
        }

        public Decision GetDecisionForPlayer(Player player)
        {
            switch (player.PlayerType)
            {
                case PlayerType.Bot:
                    return _botDecisionService.GetDecision();

                case PlayerType.Human:
                    return _humanDecisionService.GetHumanDecision();

                default:
                    throw new NotImplementedException("Get decision method is not implemented for user type");
            }
        }
    }
}
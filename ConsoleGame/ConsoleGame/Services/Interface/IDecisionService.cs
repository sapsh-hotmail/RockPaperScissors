using ConsoleGame.Code.Models;

namespace ConsoleGame.Code.Services.Interface
{
    public interface IDecisionService
    {
        Decision GetDecisionForPlayer(Player player);
    }
}
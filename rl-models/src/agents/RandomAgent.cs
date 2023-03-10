using src.games;
using src.models;


namespace src.agents;


public class RandomAgent : Agent
{
    public RandomAgent(int player) : base(player) {}

    public override Move SelectMove(IGame currentGame)
    {
        return SelectRandomMoveLocation(currentGame.AvailableMoves);
    }
}
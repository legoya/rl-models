using src.models;


namespace src.agents;


public class RandomAgent<TState> : Agent<TState>
{
    public RandomAgent(int player) : base(player) {}

    public override Move SelectMove(TState currentState, HashSet<Move> availableMoves)
    {
        return SelectRandomMoveLocation(availableMoves);
    }
}
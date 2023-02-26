using src.models;


namespace src.agents;


public abstract class Agent<TState>
{
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract Move SelectMove(TState currentState, HashSet<Move> availableMoves);

    public static Move SelectRandomMoveLocation(HashSet<Move> availableMoves)
    {
        return availableMoves.ElementAt(randomNumberGenerator.Next(availableMoves.Count));
    }
}
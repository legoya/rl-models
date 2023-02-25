namespace src.agents;


public abstract class Agent<TState, TMove>
{
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract TMove SelectMove(TState currentState, HashSet<TMove> availableMoves);

    public static TMove SelectRandomMoveLocation(HashSet<TMove> availableMoves)
    {
        return availableMoves.ElementAt(randomNumberGenerator.Next(availableMoves.Count));
    }
}
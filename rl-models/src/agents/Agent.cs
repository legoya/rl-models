namespace src.agents;


public abstract class Agent<TState, TMove>
{
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract TMove SelectMove(TState currentState, HashSet<TMove> possibleMoves);

    public static TMove SelectRandomMoveLocation(HashSet<TMove> possibleMoves)
    {
        return possibleMoves.ElementAt(randomNumberGenerator.Next(possibleMoves.Count));
    }
}
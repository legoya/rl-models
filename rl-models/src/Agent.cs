namespace src;


public abstract class Agent<TState, TMoveLocation>
{
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract TMoveLocation SelectMoveLocation(TState currentState, HashSet<TMoveLocation> possibleLocations);

    public static TMoveLocation SelectRandomMoveLocation(HashSet<TMoveLocation> possibleLocations)
    {
        return possibleLocations.ElementAt(randomNumberGenerator.Next(possibleLocations.Count));
    }
}
using src.games;
using src.models;


namespace src.agents;


public abstract class Agent
{
    public int Player;
    public static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract Move SelectMove(IGame currentGame);

    public static Move SelectRandomMoveLocation(HashSet<Move> availableMoves)
    {
        return availableMoves.ElementAt(randomNumberGenerator.Next(availableMoves.Count));
    }
}
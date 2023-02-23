using src.games;
using src.models;

namespace src;


public abstract class Agent
{
    public Game Game;
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(Game game, int player)
    {
        Game = game;
        Player = player;
    }

    public abstract MoveLocation SelectMove(State currentState, HashSet<MoveLocation> possibleMoves);

    public static MoveLocation SelectRandomMove(HashSet<MoveLocation> possibleMoves)
    {
        return possibleMoves.ElementAt(randomNumberGenerator.Next(possibleMoves.Count));
    }
}
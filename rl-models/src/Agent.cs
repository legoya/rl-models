using src.games;
using src.games.TicTacToe;
using src.models;

namespace src;


public abstract class Agent
{
    public int Player;
    private static Random randomNumberGenerator = new Random();

    public Agent(int player)
    {
        Player = player;
    }

    public abstract MoveLocation SelectMoveLocation(State<MoveLocation> currentState, HashSet<MoveLocation> possibleLocations);

    public static MoveLocation SelectRandomMoveLocation(HashSet<MoveLocation> possibleLocations)
    {
        return possibleLocations.ElementAt(randomNumberGenerator.Next(possibleLocations.Count));
    }
}
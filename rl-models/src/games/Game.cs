using src.models;


namespace src.games;


public abstract class Game
{
    public abstract override string ToString();
    public abstract State CalculateStateAfterMove(Move move);
    public abstract void MakeMove(Move move);
    public abstract GameResult GameResult(Move move);
}
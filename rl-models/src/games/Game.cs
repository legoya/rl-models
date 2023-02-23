using src.models;


namespace src.games;


public abstract class Game
{
    public abstract override string ToString();
    public abstract State CalculateStateAfterMove(IMove move);
    public abstract void MakeMove(IMove move);
    public abstract GameResult GameResult(IMove move);
}
using src.models;


namespace src.games;


public interface IGame<TState>
{
    public HashSet<Move> AvailableMoves {get;}
    public TState State {get;}
    public TState CalculateStateAfterMove(int player, Move moveLocation);
    public void MakeMove(int player, Move moveLocation);
    public GameResult GameResult(int player, Move moveLocation);
}
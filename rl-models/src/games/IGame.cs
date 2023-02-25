using src.models;


namespace src.games;


public interface IGame<TState, TMove>
{
    public HashSet<TMove> AvailableMoves {get;}
    public TState State {get;}
    public TState CalculateStateAfterMove(int player, TMove moveLocation);
    public void MakeMove(int player, TMove moveLocation);
    public GameResult GameResult(int player, TMove moveLocation);
}
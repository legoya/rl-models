using src.models;


namespace src.games;


public interface IGame<TState, TMoveLocation>
{
    public HashSet<TMoveLocation> AvailableLocations {get;}
    public TState State {get;}
    public TState CalculateStateAfterMove(int player, TMoveLocation moveLocation);
    public void MakeMove(int player, TMoveLocation moveLocation);
    public GameResult GameResult(int player, TMoveLocation moveLocation);
}
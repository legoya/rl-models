using src.models;


namespace src.games;


public abstract class Game<TState, TMoveLocation>
{
    public abstract HashSet<TMoveLocation> AvailableLocations {get;}
    public abstract TState State {get;}
    public abstract TState CalculateStateAfterMove(int player, TMoveLocation moveLocation);
    public abstract void MakeMove(int player, TMoveLocation moveLocation);
    public abstract GameResult GameResult(int player, TMoveLocation moveLocation);
}
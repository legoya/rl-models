using src.models;


namespace src.games;


public abstract class Game<TMoveLocation>
{
    public abstract HashSet<TMoveLocation> AvailableLocations {get;}
    public abstract State<TMoveLocation> State {get;}

    public abstract override string ToString();
    public abstract State<TMoveLocation> CalculateStateAfterMove(int player, TMoveLocation moveLocation);
    public abstract void MakeMove(int player, TMoveLocation moveLocation);
    public abstract GameResult GameResult(int player, TMoveLocation moveLocation);
}
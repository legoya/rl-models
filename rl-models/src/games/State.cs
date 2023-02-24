using src.models;


namespace src.games;


public abstract class State<TMoveLocation>
{
    // TODO: need to implement function to get the hash of a state
    public abstract void Update(int player, TMoveLocation moveLocation);
    public abstract bool HasWinner(int player, TMoveLocation moveLocation);
}
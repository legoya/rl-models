using src.models;


namespace src.games;


public abstract class State
{
    // TODO: need to implement function to get the hash of a state
    public abstract void Update(IMove move);
    public abstract bool HasWinner(IMove move);

}
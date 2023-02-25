using src.models;


namespace src.games;


public interface IState<TMoveLocation>
{
    // TODO: need to implement function to get the hash of a state
    public List<List<int>> Squares { get; }
    public void Update(int player, TMoveLocation moveLocation);
    public bool HasWinner(int player, TMoveLocation moveLocation);
}
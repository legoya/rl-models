using src.models;


namespace src.games;


public interface IState<TMove>
{
    // TODO: need to implement function to get the hash of a state
    public List<List<int>> Squares { get; }
    public void Update(int player, TMove moveLocation);
    public bool HasWinner(int player, TMove moveLocation);
}
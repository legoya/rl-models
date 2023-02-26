using src.models;


namespace src.games;


public interface IState
{
    // TODO: need to implement function to get the hash of a state
    public List<List<int>> Squares { get; }
    public void Update(int player, Move moveLocation);
    public bool HasWinner(int player, Move moveLocation);
}
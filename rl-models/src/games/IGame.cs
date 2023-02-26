using src.models;


namespace src.games;


public interface IGame
{
    public HashSet<Move> AvailableMoves {get;}
    public IState State {get;}
    public List<int> StateHashHistory {get;}
    public GameResult GameResult {get;}
    public void Reset();
    public IState CalculateStateAfterMove(int player, Move moveLocation);
    public void MakeMove(int player, Move moveLocation);
}
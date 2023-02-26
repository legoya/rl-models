using src.models;


namespace src.games;


public interface IGame
{
    public HashSet<Move> AvailableMoves {get;}
    public IState State {get;}
    public void Reset();
    public IState CalculateStateAfterMove(int player, Move moveLocation);
    public void MakeMove(int player, Move moveLocation);
    public GameResult GameResult(int player, Move moveLocation);
}
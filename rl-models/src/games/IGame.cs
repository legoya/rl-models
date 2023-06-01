using src.models;


namespace src.games;


public interface IGame
{
    public HashSet<Move> AvailableMoves {get;}
    public IState State {get;}
    public History History {get;}
    public GameResult GameResult {get;}
    public IGame NewGameFromConfiguration();
    public IState CalculateStateAfterMove(int player, Move moveLocation);
    public void MakeMove(int player, Move moveLocation);
}
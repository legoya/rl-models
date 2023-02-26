using src.models;


namespace src.games.TicTacToe;


public class TicTacToe : IGame
{
    public HashSet<Move> AvailableMoves {get; private set;}
    public IState State {get; private set;}
    public List<int> StateHashHistory {get; private set;}
    public GameResult GameResult {get; private set;}
    private int _size {get;}

    public TicTacToe(int size)
    {
        AvailableMoves = initialiseAvailableMoves(size);
        State = new TicTacToeState(size);
        StateHashHistory = new List<int>();
        GameResult = GameResult.Incomplete;
        _size = size;
    }

    public override string ToString()
    {
        var output = "";
        for (int row = 0; row < State.Squares.Count; row++) 
        {
            var rowString = String.Join("\t", State.Squares[row]) + "\n";
            output += rowString;
        }

        return output;
    }

    public IGame Copy()
    {
        return new TicTacToe(_size);
    }

    public IState CalculateStateAfterMove(int player, Move moveLocation)
    {
        var StateCopy = new TicTacToeState((TicTacToeState)State);
        StateCopy.Update(player, (CoordinateMove)moveLocation);

        return StateCopy;
    }

    public void MakeMove(int player, Move moveLocation)
    {
        var location = new CoordinateMove((CoordinateMove)moveLocation);
        
        AvailableMoves.Remove(location);
        State.Update(player, (CoordinateMove)moveLocation);
        StateHashHistory.Add(State.GetHashCode());
        GameResult = determinGameResult(player, moveLocation);
    }

    private GameResult determinGameResult(int player, Move moveLocation)
    {

        if (State.HasWinner(player, (CoordinateMove)moveLocation))
        {
            return player == 1 ? models.GameResult.Player1Win : models.GameResult.Player2Win;
        }

        if (AvailableMoves.Count == 0) { return models.GameResult.Draw; }

        return models.GameResult.Incomplete;

    }

    private HashSet<Move> initialiseAvailableMoves(int size)
    {
        HashSet<Move> output = new();

        foreach (int row in Enumerable.Range(0, size))
        {
            foreach (int column in Enumerable.Range(0, size))
            {
                var location = new CoordinateMove(row, column);
                output.Add(location);
            }
        }

        return output;
    }
}
using src.models;


namespace src.games.TicTacToe;


public class TicTacToeGame : Game
{
    private HashSet<CoordinateMoveLocation> _availableMoves;
    private TicTacToeState _state;

    public TicTacToeGame(int size)
    {
        _availableMoves = TicTacToeGame.initialiseAvailableMoves(size);
        _state = new TicTacToeState(size);
    }

    public override string ToString()
    {
        var output = "";
        for (int row = 0; row < _state.Squares.Count; row++) 
        {
            var rowString = String.Join("", _state.Squares[row]) + "\n";
            output += rowString;
        }

        return output;
    }

    public override State CalculateStateAfterMove(Move move)
    {
        var StateCopy = new TicTacToeState(_state);
        StateCopy.Update(move);

        return StateCopy;
    }

    public override void MakeMove(Move move)
    {
        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();
        var location = new CoordinateMoveLocation(Row, Column);
        
        _availableMoves.Remove(location);
        _state.Update(move);
    }

    public override GameResult GameResult(Move move)
    {
        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();

        if (_state.HasWinner(move))
        {
            return Player == 1 ? models.GameResult.Player1Win : models.GameResult.Player2Win;
        }

        if (_availableMoves.Count == 0) { return models.GameResult.Draw; }

        return models.GameResult.Incomplete;

    }

    private static HashSet<CoordinateMoveLocation> initialiseAvailableMoves(int size)
    {
        HashSet<CoordinateMoveLocation> output = new();

        foreach (int row in Enumerable.Range(0, size-1))
        {
            foreach (int column in Enumerable.Range(0, size-1))
            {
                var location = new CoordinateMoveLocation(row, column);
                output.Add(location);
            }
        }

        return output;
    }
}
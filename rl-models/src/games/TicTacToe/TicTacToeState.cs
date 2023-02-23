using src.models;


namespace src.games.TicTacToe;


public class TicTacToeState : State
{
    public List<List<int>> Squares { get; }
    private int _size;
    private List<int> _rowScores;
    private List<int> _columnScores;
    private int _diagonalScore;
    private int _offDiagonalScore;
    
    public TicTacToeState(int size)
    {
        Squares = initialiseSquares(size);
        _size = size;
        _rowScores = new List<int>(new int[size]);
        _columnScores = new List<int>(new int[size]);
        _diagonalScore = 0;
        _offDiagonalScore = 0;
    }
    
    public TicTacToeState(TicTacToeState other)
    {
        Squares = other.Squares;
        _size = other._size;
        _rowScores = other._rowScores;
        _columnScores = other._columnScores;
        _diagonalScore = other._diagonalScore;
        _offDiagonalScore = other._offDiagonalScore;
    }

    public override void Update(Move move)
    {
        validateMoveType(move);

        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();  // TODO: this casting can likely be done better.
        validateMoveLocation(Row, Column);

        Squares[Row][Column] = Player;
        
        _rowScores[Row] += Player;
        _columnScores[Column] += Player;

        if (Row == Column) { _diagonalScore += Player; }
        if (Row + Column == _size - 1) { _offDiagonalScore += Player; }
    }

    public override bool HasWinner(Move move)
    {
        validateMoveType(move);

        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();

        if (Math.Abs(_rowScores[Row]) == _size || Math.Abs(_columnScores[Column]) == _size) { return true; }
        if (Math.Abs(_diagonalScore) == _size || Math.Abs(_offDiagonalScore) == _size) { return true; }

        return false;
    }

    private List<List<int>> initialiseSquares(int size)
    {
        var output = new List<List<int>>();
        foreach (int i in Enumerable.Range(0, size-1))
        {
            output.Add(new List<int>(new int[size]));
        }

        return output;
    }

    private void validateMoveType(Move move)
    {
        if (move is not TicTacToeMove)
        {
            throw new ArgumentException("TicTacToeMove must be supplied to TicTacToeState.Update(Move)");
        }
    }

    private void validateMoveLocation(int Row, int Column)
    {
        if (Squares[Row][Column] != 0)
        {
            throw new ArgumentException("The supplied move is invalid as it attempts to use an already occupied location");
        }
    }

}
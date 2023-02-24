using src.models;


namespace src.games.TicTacToe;


public class TicTacToeState : State<CoordinateMoveLocation>
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

    public override void Update(int player, CoordinateMoveLocation moveLocation)
    {
        validateMoveLocation(moveLocation.Row, moveLocation.Column);

        Squares[moveLocation.Row][moveLocation.Column] = player;
        
        _rowScores[moveLocation.Row] += player;
        _columnScores[moveLocation.Column] += player;

        if (moveLocation.Row == moveLocation.Column) { _diagonalScore += player; }
        if (moveLocation.Row + moveLocation.Column == _size - 1) { _offDiagonalScore += player; }
    }

    public override bool HasWinner(int player, CoordinateMoveLocation moveLocation)
    {

        if (Math.Abs(_rowScores[moveLocation.Row]) == _size || Math.Abs(_columnScores[moveLocation.Column]) == _size) { return true; }
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

    private void validateMoveLocation(int Row, int Column)
    {
        if (Squares[Row][Column] != 0)
        {
            throw new ArgumentException("The supplied move is invalid as it attempts to use an already occupied location");
        }
    }

}
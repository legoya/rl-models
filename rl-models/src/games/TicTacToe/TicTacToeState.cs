using src.models;


namespace src.games.TicTacToe;


public class TicTacToeState : IState
{
    public List<List<int>> Squares { get; private set;}
    public int Size;
    private List<int> _rowScores;
    private List<int> _columnScores;
    private int _diagonalScore;
    private int _offDiagonalScore;

    public TicTacToeState(int size)
    {
        Squares = initialiseSquares(size);
        Size = size;
        _rowScores = new List<int>(new int[size]);
        _columnScores = new List<int>(new int[size]);
        _diagonalScore = 0;
        _offDiagonalScore = 0;
    }
    
    public TicTacToeState(TicTacToeState other)
    {
        Squares = copySquares(other.Squares);
        Size = other.Size;
        _rowScores = new List<int>(other._rowScores);
        _columnScores = new List<int>(other._columnScores);
        _diagonalScore = other._diagonalScore;
        _offDiagonalScore = other._offDiagonalScore;
    }

    public void Update(int player, Move moveLocation)
    {
        var coordinateMove = (CoordinateMove)moveLocation;
        validateMoveLocation(coordinateMove.Row, coordinateMove.Column);

        Squares[coordinateMove.Row][coordinateMove.Column] = player;
        
        _rowScores[coordinateMove.Row] += player;
        _columnScores[coordinateMove.Column] += player;

        if (coordinateMove.Row == coordinateMove.Column) { _diagonalScore += player; }
        if (coordinateMove.Row + coordinateMove.Column == Size - 1) { _offDiagonalScore += player; }
    }

    public bool HasWinner(int player, Move moveLocation)
    {
        var coordinateMove = (CoordinateMove)moveLocation;

        if (Math.Abs(_rowScores[coordinateMove.Row]) == Size || Math.Abs(_columnScores[coordinateMove.Column]) == Size)
        {
            return true; 
        }

        if (Math.Abs(_diagonalScore) == Size || Math.Abs(_offDiagonalScore) == Size)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        var squaresString = "";
        foreach (List<int> row in Squares)
        {
            squaresString += String.Join("", row);
        }

        return squaresString.GetHashCode();
    }

    private static List<List<int>> initialiseSquares(int size)
    {
        var output = new List<List<int>>();
        foreach (int i in Enumerable.Range(0, size))
        {
            output.Add(new List<int>(new int[size]));
        }

        return output;
    }

    private static List<List<int>> copySquares(List<List<int>> otherSquares)
    {
        var output = new List<List<int>>();
        foreach (List<int> row in otherSquares)
        {
            output.Add(new List<int>(row));
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
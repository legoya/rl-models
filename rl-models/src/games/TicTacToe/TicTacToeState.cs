using src.games;
using src.models;

namespace src.games.TicTacToe;


public class TicTacToeState : State
{
    public TicTacToeState(int size)
    {
        _size = size;
        _rowScores = new int[size];
        _columnScores = new int[size];
        _diagonalScore = 0;
        _offDiagonalScore = 0;
        _squares = new int[size, size];
    }

    private int _size;
    private int[] _rowScores;
    private int[] _columnScores;
    private int _diagonalScore;
    private int _offDiagonalScore;
    private int[,] _squares;
    

    public override void Update(Move move)
    {
        if (move is not TicTacToeMove)
        {
            throw new ArgumentException("TicTacToeMove must be supplied to TicTacToeState.Update(Move)");
        }

        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();  // TODO: this casting can likely be done better.

        _squares[Row, Column] = Player;
        
        _rowScores[Row] += Player;
        _columnScores[Column] += Player;

        if (Row == Column) { _diagonalScore += Player; }
        if (Row + Column == _size - 1) { _offDiagonalScore += Player; }
    }

    public override bool HasWinner(Move move)
    {
        if (move is not TicTacToeMove)
        {
            throw new ArgumentException("TicTacToeMove must be supplied to TicTacToeState.HasWinner(Move)");
        }

        var (Player, Row, Column) = ( (TicTacToeMove) move ).Decompose();

        if (Math.Abs(_rowScores[Row]) == _size || Math.Abs(_columnScores[Column]) == _size) { return true; }
        if (Math.Abs(_diagonalScore) == _size || Math.Abs(_offDiagonalScore) == _size) { return true; }

        return false;
    }
}
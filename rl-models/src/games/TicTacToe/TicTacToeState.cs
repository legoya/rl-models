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
            throw new ArgumentException("TicTacToeMove must be supplied to TicTacToeState.Update(IMove)");
        }

        Console.WriteLine("Update called with TicTacToeMove type move in TicTacToeState");   
    }

    public override bool HasWinner(Move move)
    {
        Console.WriteLine("HasWinner called in TicTacToeState");
        return false;
    }
}
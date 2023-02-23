using src.games;
using src.models;


namespace src.games.TicTacToe;

public class TicTacToeGame : Game
{
    public TicTacToeGame(int size)
    {
        _availableMoves = TicTacToeGame.initialiseAvailableMoves(size);

    }

    private HashSet<Tuple<int, int>> _availableMoves;

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    public override State CalculateStateAfterMove(Move move)
    {
        throw new NotImplementedException();
    }

    public override void MakeMove(Move move)
    {
        throw new NotImplementedException();
    }

    public override GameResult GameResult(Move move)
    {
        throw new NotImplementedException();
    }

    private static HashSet<Tuple<int, int>> initialiseAvailableMoves(int size)
    {
        HashSet<Tuple<int, int>> output = new();

        foreach (int row in Enumerable.Range(0, size-1))
        {
            foreach (int column in Enumerable.Range(0, size-1))
            {
                Tuple<int, int> location = new(row, column);
                output.Add(location);
            }
        }

        return output;
    }
}
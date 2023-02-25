using src.models;


namespace src.games.TicTacToe;

public class TicTacToeGame : Game<TicTacToeState, CoordinateMoveLocation>
{
    public override HashSet<CoordinateMoveLocation> AvailableLocations {get;}
    public override TicTacToeState State {get;}

    public TicTacToeGame(int size)
    {
        AvailableLocations = initialiseAvailableLocations(size);
        State = new TicTacToeState(size);
    }

    public override string ToString()
    {
        var output = "";
        for (int row = 0; row < State.Squares.Count; row++) 
        {
            var rowString = String.Join("", State.Squares[row]) + "\n";
            output += rowString;
        }

        return output;
    }

    public override TicTacToeState CalculateStateAfterMove(int player, CoordinateMoveLocation moveLocation)
    {
        var StateCopy = new TicTacToeState(State);
        StateCopy.Update(player, moveLocation);

        return StateCopy;
    }

    public override void MakeMove(int player, CoordinateMoveLocation moveLocation)
    {
        var location = new CoordinateMoveLocation(moveLocation);
        
        AvailableLocations.Remove(location);
        State.Update(player, moveLocation);
    }

    public override GameResult GameResult(int player, CoordinateMoveLocation moveLocation)
    {

        if (State.HasWinner(player, moveLocation))
        {
            return player == 1 ? models.GameResult.Player1Win : models.GameResult.Player2Win;
        }

        if (AvailableLocations.Count == 0) { return models.GameResult.Draw; }

        return models.GameResult.Incomplete;

    }

    private HashSet<CoordinateMoveLocation> initialiseAvailableLocations(int size)
    {
        HashSet<CoordinateMoveLocation> output = new();

        foreach (int row in Enumerable.Range(0, size - 1))
        {
            foreach (int column in Enumerable.Range(0, size - 1))
            {
                var location = new CoordinateMoveLocation(row, column);
                output.Add(location);
            }
        }

        return output;
    }
}
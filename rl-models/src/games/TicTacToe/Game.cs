using src.models;


namespace src.games.TicTacToe;


public class Game : IGame<State, CoordinateMove>
{
    public HashSet<CoordinateMove> AvailableMoves {get;}
    public State State {get;}

    public Game(int size)
    {
        AvailableMoves = initialiseAvailableMoves(size);
        State = new State(size);
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

    public State CalculateStateAfterMove(int player, CoordinateMove moveLocation)
    {
        var StateCopy = new State(State);
        StateCopy.Update(player, moveLocation);

        return StateCopy;
    }

    public void MakeMove(int player, CoordinateMove moveLocation)
    {
        var location = new CoordinateMove(moveLocation);
        
        AvailableMoves.Remove(location);
        State.Update(player, moveLocation);
    }

    public GameResult GameResult(int player, CoordinateMove moveLocation)
    {

        if (State.HasWinner(player, moveLocation))
        {
            return player == 1 ? models.GameResult.Player1Win : models.GameResult.Player2Win;
        }

        if (AvailableMoves.Count == 0) { return models.GameResult.Draw; }

        return models.GameResult.Incomplete;

    }

    private HashSet<CoordinateMove> initialiseAvailableMoves(int size)
    {
        HashSet<CoordinateMove> output = new();

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
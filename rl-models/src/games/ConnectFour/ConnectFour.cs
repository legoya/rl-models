using src.models;


namespace src.games.ConnectFour;


public class ConnectFour : IGame
{
    public HashSet<Move> AvailableMoves {get; private set;}
    public IState State {get; private set;}
    public History History {get; private set;}
    public GameResult GameResult {get; private set;}
    private int _numberOfRows {get;}
    private int _numberOfColumns {get;}
    private Display _display;

    public ConnectFour(int numberOfRows, int numberOfColumns)
    {
        AvailableMoves = initialiseAvailableMoves(numberOfColumns);
        State = new ConnectFourState(numberOfRows, numberOfColumns);
        History = new History(State);
        GameResult = GameResult.Incomplete;
        _numberOfRows = numberOfRows;
        _numberOfColumns = numberOfColumns;
        _display = new Display(State.Squares);
    }

    public override string ToString()
    {
        return _display.ToString();
    }

    public IGame NewGameFromConfiguration()
    {
        return new ConnectFour(_numberOfRows, _numberOfColumns);
    }

    public IState CalculateStateAfterMove(int player, Move moveLocation)
    {
        var StateCopy = new ConnectFourState((ConnectFourState)State);
        StateCopy.Update(player, (VerticalMove)moveLocation);

        return StateCopy;
    }

    public void MakeMove(int player, Move moveLocation)
    {
        var location = new VerticalMove((VerticalMove)moveLocation);
        
        State.Update(player, (VerticalMove)moveLocation);
        
        if (isColumnFull(location.Column))
        {
            AvailableMoves.Remove(location); 
        }
        
        History.Append(State, moveLocation);
        _display.Update(State.Squares);
        GameResult = determinGameResult(player, moveLocation);
    }

    private GameResult determinGameResult(int player, Move moveLocation)
    {

        if (State.HasWinner(player, (VerticalMove)moveLocation))
        {
            return player == 1 ? models.GameResult.Player1Win : models.GameResult.Player2Win;
        }

        if (AvailableMoves.Count == 0) { return models.GameResult.Draw; }

        return models.GameResult.Incomplete;

    }

    private HashSet<Move> initialiseAvailableMoves(int numberOfColumns)
    {
        HashSet<Move> availableMoves = new();

        for(int i = 0; i < numberOfColumns; i++)
        {
            var availableMove = new VerticalMove(i);
            availableMoves.Add(availableMove);
        }

        return availableMoves;
    }

    private bool isColumnFull(int column)
    {

        var connectFourState = (ConnectFourState)State;
        return connectFourState.NumberOfMarkersInColumn[column] == _numberOfRows;
    }
}
using src.models;
using src.games.ConnectFour.extensions;


namespace src.games.ConnectFour;


public class ConnectFour : IGame
{
    public HashSet<Move> AvailableMoves {get; private set;}
    public IState State {get; private set;}
    public List<int> StateHistory {get; private set;}
    public GameResult GameResult {get; private set;}
    private int _numberOfRows {get;}
    private int _numberOfColumns {get;}
    private Display _display;

    public ConnectFour(int numberOfRows, int numberOfColumns)
    {
        AvailableMoves = initialiseAvailableMoves(numberOfColumns);
        State = new ConnectFourState(numberOfRows, numberOfColumns);
        StateHistory = new List<int>();
        GameResult = GameResult.Incomplete;
        _numberOfRows = numberOfRows;
        _numberOfColumns = numberOfColumns;
        _display = new Display(State.Squares);
    }

    public override string ToString()
    {
        return _display.ToString();
    }

    public IGame Copy()
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
        
        if (State.ConnectFourColumnIsFull(location.Column))  // TODO abstract
        {
            AvailableMoves.Remove(location); 
        }
        
        StateHistory.Add(State.GetHashCode());
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
}
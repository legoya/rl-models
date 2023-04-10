using src.models;


namespace src.games.ConnectFour;


public class ConnectFourState : IState
{
    public List<List<int>> Squares { get; private set;}
    public int NumberOfRows;
    public int NumberOfColumns;


    public ConnectFourState(int numberOfRows, int numberOfColumns)
    {
        Squares = initialiseSquares(numberOfRows, numberOfColumns);
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;

    }
    
    public ConnectFourState(ConnectFourState other)
    {
        Squares = copySquares(other.Squares);
        NumberOfRows = other.NumberOfRows;
        NumberOfColumns = other.NumberOfColumns;
    }

    void IState.Update(int player, Move moveLocation)
    {
        throw new NotImplementedException();
    }

    bool IState.HasWinner(int player, Move moveLocation)
    {
        throw new NotImplementedException();
    }


//     public override int GetHashCode()
//     {
//         var squaresString = "";
//         foreach (List<int> row in Squares)
//         {
//             squaresString += String.Join("", row);
//         }

//         return squaresString.GetHashCode();
//     }

    private static List<List<int>> initialiseSquares(int numberOfRows, int numberOfColumns)
    {
        var squares = new List<List<int>>();

        foreach (int i in Enumerable.Range(0, numberOfRows))
        {
            squares.Add(new List<int>(new int[numberOfColumns]));
        }

        return squares;
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

    //     private void validateMoveLocation(int Row, int Column)
    //     {
    //         if (Squares[Row][Column] != 0)
    //         {
    //             throw new ArgumentException("The supplied move is invalid as it attempts to use an already occupied location");
    //         }
    //     }
}
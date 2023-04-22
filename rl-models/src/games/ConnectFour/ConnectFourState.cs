using src.models;


namespace src.games.ConnectFour;


public class ConnectFourState : IState
{
    public List<List<int>> Squares { get; private set;}
    public int NumberOfRows;
    public int NumberOfColumns;
    public List<int> NumberOfMarkersInColumn;


    public ConnectFourState(int numberOfRows, int numberOfColumns)
    {
        Squares = initialiseSquares(numberOfRows, numberOfColumns);
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        NumberOfMarkersInColumn = new List<int>(new int[numberOfColumns]);
    }
    
    public ConnectFourState(ConnectFourState other)
    {
        Squares = copySquares(other.Squares);
        NumberOfRows = other.NumberOfRows;
        NumberOfColumns = other.NumberOfColumns;
        NumberOfMarkersInColumn = copyNumberOfMarkersInColumn(other);
    }

    public void Update(int player, Move moveLocation)
    {
        var moveColumn = ((VerticalMove)moveLocation).Column;
        var moveRow = NumberOfMarkersInColumn[moveColumn];

        validateMoveLocation(moveRow, moveColumn);

        Squares[moveRow][moveColumn] = player;
    }

    public bool HasWinner(int player, Move moveLocation)
    {
        // basic implmentation first.

        // will be some kind of square search expansion from the move location outward in 4 directions
        
        return NumberOfMarkersInColumn.Max() > 5;
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

    private static List<int> copyNumberOfMarkersInColumn(ConnectFourState other)
    {
        var numberOfMarkersInColumn = new List<int>(new int[other.NumberOfColumns]);

        for (int r = 0; r < other.NumberOfRows; r++)
        {
            for (int c = 0; c < other.NumberOfColumns; c++)
            {
                numberOfMarkersInColumn[c] += other.Squares[r][c] == 0 ? 0 : 1;
            }
        }

        return numberOfMarkersInColumn;
    }

        private void validateMoveLocation(int Row, int Column)
        {
            if (Squares[Row][Column] != 0)
            {
                throw new ArgumentException("The supplied move is invalid as it attempts to use an already occupied location");
            }
        }
}
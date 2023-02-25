namespace src.models;


public abstract class Move {}

public class VerticalMove : Move
{
    public int Column {get; set;}

    public VerticalMove(int column)
    {
        Column = column;
    }
}

public class CoordinateMove : Move
{
    public int Row {get; set;}
    public int Column {get; set;}

    public CoordinateMove(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public CoordinateMove(CoordinateMove other)
    {
        Row = other.Row;
        Column = other.Column;
    }
}

namespace src.models;


public abstract class MoveLocation {}

public class VerticalMoveLocation : MoveLocation
{
    public int Column {get; set;}

    public VerticalMoveLocation(int column)
    {
        Column = column;
    }
}

public class CoordinateMoveLocation : MoveLocation
{
    public int Row {get; set;}
    public int Column {get; set;}

    public CoordinateMoveLocation(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public CoordinateMoveLocation(CoordinateMoveLocation other)
    {
        Row = other.Row;
        Column = other.Column;
    }
}

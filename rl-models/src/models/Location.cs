namespace src.models;


public abstract class MoveLocation {}

public class VerticalMoveLocation : MoveLocation
{
    int Column {get; set;}

    public VerticalMoveLocation(int column)
    {
        Column = column;
    }
}

public class CoordinateMoveLocation : MoveLocation
{
    int Row {get; set;}
    int Column {get; set;}

    public CoordinateMoveLocation(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

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

    public override int GetHashCode()
    {
        return Row * 10 + Column;
    }

    public override bool Equals(object? other)
    {
        if (other is null) { return false; }
        if (other is CoordinateMove)
        {
            var otherCoordinateMove = (CoordinateMove)other;
            return Row == otherCoordinateMove.Row && Column == otherCoordinateMove.Column;
        }

        return false; 
    }

}

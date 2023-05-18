using src.models;

namespace src.games.ConnectFour;


public static class Connections
{
    private const int _requiredConnectionSize = 4;
    private static Direction _down = new Direction(1, 0);
    private static Direction _left = new Direction(0, -1);
    private static Direction _right = new Direction(0, 1);
    private static Direction _upLeft = new Direction(-1, -1);
    private static Direction _downRight = new Direction(1, 1);
    private static Direction _upRight = new Direction(-1, 1);
    private static Direction _downLeft = new Direction(1, -1);

    public static bool HasRequiredConnections(List<List<int>> cells, int player, int row, int column)
    {
        if (search(cells, player, row, column, _down) >= _requiredConnectionSize)
        {
            return true;
        }

        var horizontalConnection = search(cells, player, row, column, _left) + search(cells, player, row, column, _right) -1;

        if (horizontalConnection >= _requiredConnectionSize)
        {
            return true;
        }

        var mainDiagonalConnection = search(cells, player, row, column, _upLeft) + search(cells, player, row, column, _downRight) -1;

        if (mainDiagonalConnection >= _requiredConnectionSize)
        {
            return true;
        }

        var offDiagonalConnection = search(cells, player, row, column, _upRight) + search(cells, player, row, column, _downLeft) -1;

        return offDiagonalConnection >= _requiredConnectionSize;
    }

    private static int search(List<List<int>> cells, int player, int row, int column, Direction direction)
    {
        if (!isInBounds(cells, row, column) || cells[row][column] != player)
        {
            return 0;
        }

        return 1 + search(cells, player, row + direction.DeltaRow, column + direction.DeltaColumn, direction);
        
    }

    private static bool isInBounds(List<List<int>> cells, int row, int column)
    {
        return row >= 0 && row < cells.Count && column >= 0 && column < cells[0].Count;
    }

    private class Direction
    {
        public int DeltaRow;
        public int DeltaColumn;

        public Direction(int deltaRow, int deltaColumn)
        {
            DeltaRow = deltaRow;
            DeltaColumn = deltaColumn;
        }
    }
}
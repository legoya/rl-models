using System.Text;
using src.models;


namespace src;


public class Display
{
    private static string EmptyCell = "     ";
    private static string Player1Marker = "X";
    private static string Player2Marker = "O";
    private static string VericalDivider = "|";
    private static string HorizontalDivider = "-";
    private int _displayRows;
    private int _displayColumns;
    private int _displayWidth;
    private string _displayString;

    public Display(List<List<int>> cells)
    {
        _displayRows = cells.Count;
        _displayColumns = cells[0].Count;
        _displayWidth = Display.EmptyCell.Length * _displayColumns + (_displayColumns - 1) * VericalDivider.Length;
        _displayString = initialiseDisplay(cells);
    }

    public override string ToString()
    {
        return _displayString;
    }

    public void UpdateWithMove(int player, Move lastMove)
    {
        return;
    }

    private string initialiseDisplay(List<List<int>> cells)
    {
        var displayStringBuilder = new StringBuilder();

        for (int iRow = 0; iRow < _displayRows - 1; iRow++)
        {
            displayStringBuilder.Append(emptyRow());
            displayStringBuilder.Append(horizontalDivider());
        }

        displayStringBuilder.Append(emptyRow());

        return displayStringBuilder.ToString();
    }

    private string emptyRow()
    {
        var rowStringBuilder = new StringBuilder();

        for (int iCol = 0; iCol < _displayColumns - 1; iCol++)
        {
            rowStringBuilder.Append(Display.EmptyCell);
            rowStringBuilder.Append(Display.VericalDivider);
        }

        rowStringBuilder.Append(Display.EmptyCell);
        rowStringBuilder.Append("\n");

        return rowStringBuilder.ToString();
    }

    private string horizontalDivider()
    {
        var horizontalDividerStringBuilder = new StringBuilder();

        for (int i = 0; i < _displayWidth; i++)
        {
            horizontalDividerStringBuilder.Append(Display.HorizontalDivider);
        }

        horizontalDividerStringBuilder.Append("\n");

        return horizontalDividerStringBuilder.ToString();
    }
}
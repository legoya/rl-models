using System.Text;


namespace src;


public class Display
{
    private static string EmptyCell = "     ";
    private static string Player1MarkerCell = "  X  ";
    private static string Player2MarkerCell = "  O  ";
    private static string VericalDivider = "|";
    private static string HorizontalDivider = "-";
    private int _displayRows;
    private int _displayColumns;
    private int _displayWidth;
    private string _displayAsString;

    public Display(List<List<int>> cells)
    {
        _displayRows = cells.Count;
        _displayColumns = cells[0].Count;
        _displayWidth = Display.EmptyCell.Length * _displayColumns + (_displayColumns - 1) * VericalDivider.Length;
        _displayAsString = buildDisplay(cells);
    }

    public override string ToString()
    {
        return _displayAsString;
    }

    public void Update(List<List<int>> cells)
    {
        _displayAsString = buildDisplay(cells);
    }

    private string buildDisplay(List<List<int>> cells)
    {
        var displayStringBuilder = new StringBuilder();

        for (int iRow = 0; iRow < _displayRows - 1; iRow++)
        {
            displayStringBuilder.Append(displayRow(cells[iRow]));
            displayStringBuilder.Append(horizontalDivider());
        }

        displayStringBuilder.Append(displayRow(cells[_displayColumns-1]));

        return displayStringBuilder.ToString();
    }

    private string displayRow(List<int> cells)
    {
        var rowStringBuilder = new StringBuilder();

        for (int iCol = 0; iCol < _displayColumns - 1; iCol++)
        {
            if (cells[iCol] == 0)
            {
                rowStringBuilder.Append(Display.EmptyCell);
            }
            else if (cells[iCol] == 1)
            {
                rowStringBuilder.Append(Display.Player1MarkerCell);
            }
            else
            {
                rowStringBuilder.Append(Display.Player2MarkerCell);
            }
            
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
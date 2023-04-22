namespace src.games.ConnectFour.extensions;

public static class StateExensions
{
    public static bool ConnectFourColumnIsFull(this IState state, int column)
    {
        var connectFourState = (ConnectFourState)state;
        return connectFourState.NumberOfMarkersInColumn[column] == connectFourState.NumberOfRows;
    }
}
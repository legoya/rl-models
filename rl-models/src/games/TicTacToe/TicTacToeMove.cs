using src.models;

namespace src.games.TicTacToe;


public class TicTacToeMove : Move
{
    public int Row  {get; set;}
    public int Column {get; set;}

    public TicTacToeMove(int player, int row, int column)
    {
        Player = player;
        Row = row;
        Column = column;
    }
}

public class X : Move
{
    public X(int player)
    {
        Player = player;
    }
}
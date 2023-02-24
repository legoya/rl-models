using src.models;


namespace src.games.TicTacToe;


public class HumanAgent : Agent
{
    public HumanAgent(int player) : base(player) {}

    public override MoveLocation SelectMoveLocation(State<MoveLocation> currentState, HashSet<MoveLocation> possibleMoves)
    {
        var row = Convert.ToInt32(Console.ReadLine());
        var column = Convert.ToInt32(Console.ReadLine());

        return new CoordinateMoveLocation(row, column);
    }

}
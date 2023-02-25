using src.agents;
using src.models;


namespace src.games.TicTacToe;


public class HumanAgent : Agent<State, CoordinateMove>
{
    public HumanAgent(int player) : base(player) {}

    public override CoordinateMove SelectMoveLocation(State currentState, HashSet<CoordinateMove> possibleMoves)
    {
        var row = Convert.ToInt32(Console.ReadLine());
        var column = Convert.ToInt32(Console.ReadLine());

        return new CoordinateMove(row, column);
    }

}
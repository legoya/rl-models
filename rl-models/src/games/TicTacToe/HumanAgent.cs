using src.agents;
using src.models;


namespace src.games.TicTacToe;


public class HumanAgent : Agent<TicTacToeState, CoordinateMoveLocation>
{
    public HumanAgent(int player) : base(player) {}

    public override CoordinateMoveLocation SelectMoveLocation(TicTacToeState currentState, HashSet<CoordinateMoveLocation> possibleMoves)
    {
        var row = Convert.ToInt32(Console.ReadLine());
        var column = Convert.ToInt32(Console.ReadLine());

        return new CoordinateMoveLocation(row, column);
    }

}
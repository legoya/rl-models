using src.models;


namespace src.games.TicTacToe;


public class HumanAgent : Agent
{
    public HumanAgent(Game game, int player) : base(game, player) {}

    public override MoveLocation SelectMove(State currentState, HashSet<MoveLocation> possibleMoves)
    {
        var row = Convert.ToInt32(Console.ReadLine());
        var column = Convert.ToInt32(Console.ReadLine());

        return new CoordinateMoveLocation(row, column);
    }

}
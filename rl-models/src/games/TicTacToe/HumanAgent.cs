using src.agents;
using src.models;


namespace src.games.TicTacToe;


public class HumanAgent : Agent<State, CoordinateMove>
{
    public HumanAgent(int player) : base(player) {}

    public override CoordinateMove SelectMove(State currentState, HashSet<CoordinateMove> availableMoves)
    {
        Console.WriteLine($"Enter the row number for your move (1-{currentState.Size})");
        var row = Convert.ToInt32(Console.ReadLine());  

        Console.WriteLine($"Enter the column number for your move (1-{currentState.Size})");
        var column = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n");

        var selectedMove = new CoordinateMove(--row, --column);  // Human readable is 1 to size, State is 0-indexed so needs -1

        if (!availableMoves.Contains(selectedMove))
        {
            return SelectMove(currentState, availableMoves);
        }

        return new CoordinateMove(row, column);
    }

}
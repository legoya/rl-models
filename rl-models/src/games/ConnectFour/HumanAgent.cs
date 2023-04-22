using src.agents;
using src.models;


namespace src.games.ConnectFour;


public class HumanAgent : Agent
{
    public HumanAgent(int player) : base(player) {}

    public override Move SelectMove(IGame currentGame)
    {
        var numberOfColumns = ((ConnectFourState)currentGame.State).NumberOfMarkersInColumn;
        
        Console.WriteLine($"Enter the column number for your move (1-{numberOfColumns})");
        var column = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        var selectedMove = new VerticalMove(--column);  // Human readable is 1 to size, State is 0-indexed so needs -1

        if (!currentGame.AvailableMoves.Contains(selectedMove))
        {
            Console.WriteLine("You must select a column that is not already filled, please select again");
            return SelectMove(currentGame);
        }

        return new VerticalMove(column);
    }

}
using src.games;
using src.agents;
using src.models;


namespace src;


public static class Match
{
    public static void start(IGame game, Agent agent1, Agent agent2)
    {
        var activeAgent = agent1;

        while (game.GameResult == GameResult.Incomplete)
        {
            Console.WriteLine(game);

            var selectedMove = activeAgent.SelectMove(game.State, game.AvailableMoves);
            game.MakeMove(activeAgent.Player, selectedMove);

            activeAgent = alternateActive(activeAgent, agent1, agent2);
        }

        Console.WriteLine("Game End");
        Console.WriteLine(game.GameResult);
        Console.WriteLine(game);
    }

    private static Agent alternateActive(Agent activeAgent, Agent agent1, Agent agent2)
    {
        return activeAgent.Player switch
        {
            1 => agent2,
            _ =>  agent1
        };
    }
} 
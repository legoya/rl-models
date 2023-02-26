using src.games;
using src.agents;
using src.models;


namespace src;


public static class Match
{
    public static IGame Play(IGame game, Agent agent1, Agent agent2)
    {
        var gameInstance = game.Copy();
        var activeAgent = agent1;

        while (gameInstance.GameResult == GameResult.Incomplete)
        {
            Console.WriteLine(gameInstance);

            var selectedMove = activeAgent.SelectMove(gameInstance.State, gameInstance.AvailableMoves);
            gameInstance.MakeMove(activeAgent.Player, selectedMove);

            activeAgent = alternateActive(activeAgent, agent1, agent2);
        }

        Console.WriteLine("Game End");
        Console.WriteLine(gameInstance.GameResult);
        Console.WriteLine(gameInstance);

        return gameInstance;
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
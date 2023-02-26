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
            var selectedMove = activeAgent.SelectMove(game);
            gameInstance.MakeMove(activeAgent.Player, selectedMove);

            activeAgent = alternateActive(activeAgent, agent1, agent2);
        }

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
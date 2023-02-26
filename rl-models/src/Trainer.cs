using src.games;
using src.agents;


namespace src;


public static class Trainer
{
    public static void Train(IGame game, Agent agent1, Agent agent2, int numberOfGames)
    {
        for (int i = 0; i < numberOfGames; i++)
        {
            var completedGame = Match.Play(game, agent1, agent2);

            Console.WriteLine(game.GameResult);
            learnFromGame(completedGame, agent1);

            // will process the game instance here to learn from what happened
        }
    }

    private static void learnFromGame(IGame game, Agent agent)
    {
        foreach (int stateHash in game.StateHashHistory)
        {
            Console.WriteLine(stateHash);
        }

        return;
    }
}
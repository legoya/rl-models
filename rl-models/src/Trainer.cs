using src.games;
using src.agents;


namespace src;


public static class Trainer
{
    public static void Train(IGame game, Agent agent1, Agent agent2, int numberOfGames)
    {
        if (agent1 is not LearningAgent && agent2 is not LearningAgent)
        {
            throw new ArgumentException("At least one of the suppied agents must be a LearningAgent");
        }
        
        loadLearnedValues(agent1, agent2, game.GetType().Name);

        double a1Wins = 0.0;

        for (int i = 1; i < numberOfGames+1; i++)
        {
            var completedGame = Match.Play(game, agent1, agent2);

            if (completedGame.GameResult is models.GameResult.Player1Win) { a1Wins++; }

            if (i % 500 == 0)
            {
                Console.WriteLine($"Agent 1 win rate: {Math.Round(a1Wins*100/500, 4)}%");
                a1Wins = 0.0;
            }
            
            learnFromGame(completedGame, agent1, agent2);
        }

        saveLearnedValues(agent1, agent2, game.GetType().Name);
    }

    private static void learnFromGame(IGame game, Agent agent1, Agent agent2)
    {
        if (agent1 is LearningAgent)
        {
            ((LearningAgent)agent1).Learn(game.StateHashHistory, game.GameResult);
            return;
        }

        ((LearningAgent)agent2).Learn(game.StateHashHistory, game.GameResult);
    }

    private static void loadLearnedValues(Agent agent1, Agent agent2, string gameName)
    {
        if (agent1 is LearningAgent)
        {
            ((LearningAgent)agent1).LoadLearning(gameName);
            return;
        }

        ((LearningAgent)agent2).LoadLearning(gameName);
    }

    private static void saveLearnedValues(Agent agent1, Agent agent2, string gameName)
    {
        if (agent1 is LearningAgent)
        {
            ((LearningAgent)agent1).SaveLearning(gameName);
            return;
        }

        ((LearningAgent)agent2).SaveLearning(gameName);
    }
}
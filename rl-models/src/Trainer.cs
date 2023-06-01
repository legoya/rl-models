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
        
        var statistics = new TrainingStatistics(numberOfGames, 0.1);
        loadLearnedValues(agent1, agent2, game.GetType().Name);

        for (int i = 1; i < numberOfGames+1; i++)
        {
            var completedGame = Match.Play(game, agent1, agent2);
            statistics.UpdateStats(completedGame.GameResult);
            statistics.PrintStatistics(i);
            
            learnFromGame(completedGame, agent1, agent2);
        }

        saveLearnedValues(agent1, agent2, game.GetType().Name);
    }

    private static void learnFromGame(IGame game, Agent agent1, Agent agent2)
    {
        if (agent1 is LearningAgent)
        {
            ((LearningAgent)agent1).Learn(game.History, game.GameResult);
            return;
        }

        ((LearningAgent)agent2).Learn(game.History, game.GameResult);
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
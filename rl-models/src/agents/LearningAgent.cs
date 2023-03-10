using src.games;
using src.models;


namespace src.agents;


public abstract class LearningAgent : Agent
{
    public LearningAgent(int player) : base(player) {}
    public abstract void Learn(List<int> stateHistory, GameResult result);
    public abstract void SaveLearning(string gameName);
    public abstract void LoadLearning(string gameName);
}
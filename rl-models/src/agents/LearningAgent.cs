using src.models;


namespace src.agents;


public abstract class LearningAgent : Agent
{
    public LearningAgent(int player) : base(player) {}
    public abstract void Learn(List<int> stateHistory, GameResult result);
}
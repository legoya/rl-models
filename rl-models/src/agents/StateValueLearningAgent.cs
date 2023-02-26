using src.models;
using src.games;


namespace src.agents;


public class StateValueLearningAgent : LearningAgent
{
    private double _learningRate;
    private double _explorationRate;
    private double _discountFactor;
    private Dictionary<int, double> _stateValueMap;
    
    public StateValueLearningAgent(int player, double learningRate, double explorationRate, double discountFactor) : base(player)
    {
        _learningRate = learningRate;
        _explorationRate = explorationRate;
        _discountFactor = discountFactor;
        _stateValueMap = new Dictionary<int, double>();
    }

    public override Move SelectMove(IState currentState, HashSet<Move> availableMoves)
    {
        return SelectRandomMoveLocation(availableMoves);
    }

    public override void Learn(List<int> stateHistory, GameResult result)
    {
        var reward = determineReward(result);

        for (int i = stateHistory.Count-1; i >= 0; i--)
        {
            var stateHash = stateHistory[i];
            
            if (!_stateValueMap.ContainsKey(stateHash)) { _stateValueMap.Add(stateHash, 0); }

            _stateValueMap[stateHash] += _learningRate * (_discountFactor * reward - _stateValueMap[stateHash]);
            reward = _stateValueMap[stateHash];
        }

        return;
    }

    private static double determineReward(GameResult result)
    {
        return result switch
        {
            GameResult.Player1Win => 1,
            GameResult.Player2Win => -1,
            _ => 0
        };
    }
}
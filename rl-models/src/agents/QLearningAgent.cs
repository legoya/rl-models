using System.Text.Json;
using src.models;
using src.games;


namespace src.agents;


public class QLearningAgent : LearningAgent
{
    private double _learningRate;
    private double _explorationRate;
    private double _discountFactor;
    private Dictionary<int, Dictionary<int, double>> _stateActionRewardMap {get; set;}
    
    public QLearningAgent(int player, double learningRate, double explorationRate, double discountFactor) : base(player)
    {
        _learningRate = learningRate;
        _explorationRate = explorationRate;
        _discountFactor = discountFactor;
        _stateActionRewardMap = new Dictionary<int, Dictionary<int, double>>();
    }

    public override Move SelectMove(IGame currentGame)
    {
        if (randomNumberGenerator.NextDouble() < _explorationRate)
        {
            return SelectRandomMoveLocation(currentGame.AvailableMoves);
        }

        var currentState = currentGame.State.GetHashCode();
        
        Move? selectedMove = null;
        double selectedMoveValue = double.MinValue;

        foreach (Move availableMove in currentGame.AvailableMoves)
        {
            var moveHash = availableMove.GetHashCode();
            var stateAction = new Tuple<int, int>(currentState, moveHash);  // this move can't be hashed can it?

            if (!_stateActionRewardMap.ContainsKey(currentState))
            {
                _stateActionRewardMap.Add(currentState, new Dictionary<int, double>());
            }

            var StateActionQuality = _stateActionRewardMap[currentState].ContainsKey(moveHash) ? _stateActionRewardMap[currentState][moveHash] * Player : 0.0;
            
            if (StateActionQuality > selectedMoveValue)
            {
                selectedMove = availableMove;
                selectedMoveValue = StateActionQuality;
            }
        }

        if (selectedMove is null) { throw new ArithmeticException("Move was not successfully selected"); }

        return selectedMove;
    }

    public override void Learn(History gameHistory, GameResult result)
    {
        var reward = determineReward(result);
        var stateHistory = gameHistory.States;
        var moveHistory = gameHistory.Moves;  // this is one shorter than stateHistory because there is no move to cause the initial state.

        for (int i = moveHistory.Count-1; i >= 0; i--)
        {
            if (!_stateActionRewardMap.ContainsKey(stateHistory[i]))
            {
                _stateActionRewardMap.Add(stateHistory[i], new Dictionary<int, double>());       
            }

            if (!_stateActionRewardMap[stateHistory[i]].ContainsKey(moveHistory[i]))
            {
                _stateActionRewardMap[stateHistory[i]].Add(moveHistory[i], 0.0);
            }

            _stateActionRewardMap[stateHistory[i]][moveHistory[i]] += _learningRate * (_discountFactor * reward - _stateActionRewardMap[stateHistory[i]][moveHistory[i]]);
            reward = _stateActionRewardMap[stateHistory[i]][moveHistory[i]];
        }

        return;
    }

    public override void SaveLearning(string gameName)
    {
        string fileName = gameName + "QLearning.json"; 
        string jsonString = JsonSerializer.Serialize(_stateActionRewardMap);
        File.WriteAllText(fileName, jsonString);
        return;
    }

    public override void LoadLearning(string gameName)
    {
        var fileName = gameName + "QLearning.json";

        if(File.Exists(fileName))
        {
            var pastValues = JsonSerializer.Deserialize<Dictionary<int, Dictionary<int, double>>>(File.ReadAllText(fileName));
            if (pastValues is not null) { _stateActionRewardMap = pastValues; }
        }
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
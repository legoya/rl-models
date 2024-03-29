using System.Text.Json;
using src.models;
using src.games;


namespace src.agents;


public class StateValueLearningAgent : LearningAgent
{
    private double _learningRate;
    private double _explorationRate;
    private double _discountFactor;
    private Dictionary<int, double> _stateValueMap {get; set;}
    
    public StateValueLearningAgent(int player, double learningRate, double explorationRate, double discountFactor) : base(player)
    {
        _learningRate = learningRate;
        _explorationRate = explorationRate;
        _discountFactor = discountFactor;
        _stateValueMap = new Dictionary<int, double>();
    }

    public override Move SelectMove(IGame currentGame)
    {
        if (randomNumberGenerator.NextDouble() < _explorationRate)
        {
            return SelectRandomMoveLocation(currentGame.AvailableMoves);
        }

        Move? selectedMove = null;
        double selectedMoveValue = double.MinValue;

        foreach (Move availableMove in currentGame.AvailableMoves)
        {
            var nextState = currentGame.CalculateStateAfterMove(Player, availableMove).GetHashCode();
            var nextStateValue = _stateValueMap.ContainsKey(nextState) ? _stateValueMap[nextState] * Player : 0.0;
            
            if (nextStateValue > selectedMoveValue)
            {
                selectedMove = availableMove;
                selectedMoveValue = nextStateValue;
            }

        }

        if (selectedMove is null) { throw new ArithmeticException("Move was not successfully selected"); }

        return selectedMove;
    }

    public override void Learn(History gameHistory, GameResult result)
    {
        var reward = determineReward(result);
        var stateHistory = gameHistory.States;

        for (int i = stateHistory.Count-1; i >= 0; i--)
        {
            var stateHash = stateHistory[i];
            
            if (!_stateValueMap.ContainsKey(stateHash)) { _stateValueMap.Add(stateHash, 0); }

            _stateValueMap[stateHash] += _learningRate * (_discountFactor * reward - _stateValueMap[stateHash]);
            reward = _stateValueMap[stateHash];
        }

        return;
    }

    public override void SaveLearning(string gameName)
    {
        string fileName = gameName + "StateValues.json"; 
        string jsonString = JsonSerializer.Serialize(_stateValueMap);
        File.WriteAllText(fileName, jsonString);
        return;
    }

    public override void LoadLearning(string gameName)
    {
        var fileName = gameName + "StateValues.json";

        if(File.Exists(fileName))
        {
            var pastValues = JsonSerializer.Deserialize<Dictionary<int, double>>(File.ReadAllText(fileName));
            if (pastValues is not null) { _stateValueMap = pastValues; }
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
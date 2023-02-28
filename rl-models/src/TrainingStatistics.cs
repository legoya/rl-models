using src.models;


namespace src;


public class TrainingStatistics
{
    private int _printInterval;
    private int _agent1WinCount;
    private int _agent2WinCount;
    
    public TrainingStatistics(int totalGames, double printRate)
    {
        _printInterval = (int)(totalGames * printRate);

        _agent1WinCount = 0;
        _agent2WinCount = 0;
    }

    public void UpdateStats(GameResult result)
    {
        if (result is GameResult.Player1Win) { _agent1WinCount++; return; }
        if (result is GameResult.Player2Win) { _agent2WinCount++; return; }
    }

    public void PrintStatistics(int gamesPlayed)
    {
        if (gamesPlayed == 0 || gamesPlayed % _printInterval != 0) { return; }
        
        var agent1WinRate = Math.Round((double)_agent1WinCount * 100 / gamesPlayed, 2);
        var agent2WinRate = Math.Round((double)_agent2WinCount * 100 / gamesPlayed, 2);
        var drawRate = Math.Round((double)(gamesPlayed - _agent1WinCount - _agent2WinCount) * 100 / gamesPlayed, 2);

        Console.WriteLine($"Agent 1 Rate: {agent1WinRate}%, Agent 2 Rate: {agent2WinRate}%, Draw Rate: {drawRate}%");
    }

}
using src.games;
using src.agents;
using src.models;


namespace src.games;


public class Match
{
    private Agent _agent1;
    private Agent _agent2;
    private Agent _activeAgent;

    public Match(Agent agent1, Agent agent2)
    {
        _agent1 = agent1;
        _agent2 = agent2;
        _activeAgent = agent1;
    }

    public void start(IGame game)
    {
        var gameResult = GameResult.Incomplete;

        while (gameResult == GameResult.Incomplete)
        {
            Console.WriteLine(game);

            var selectedMove = _activeAgent.SelectMove(game.State, game.AvailableMoves);

            game.MakeMove(_activeAgent.Player, selectedMove);
            gameResult = game.GameResult(_activeAgent.Player, selectedMove);

            _activeAgent = alternateActive(_activeAgent);
        }

        Console.WriteLine("Game End");
        Console.WriteLine(gameResult);
        Console.WriteLine(game);
    }

    private Agent alternateActive(Agent activeAgent)
    {
        return _activeAgent.Player switch
        {
            1 => _agent2,
            _ =>  _agent1
        };
    }
    
} 
using src.games;
using src.agents;
using src.models;


namespace src;


public abstract class Match<TState>
{
    private Agent<TState> _agent1;
    private Agent<TState> _agent2;
    private Agent<TState> _activeAgent;

    public Match(Agent<TState> agent1, Agent<TState> agent2)
    {
        _agent1 = agent1;
        _agent2 = agent2;
        _activeAgent = agent1;
    }

    public void start(IGame<TState> game)
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

    private Agent<TState> alternateActive(Agent<TState> activeAgent)
    {
        return _activeAgent.Player switch
        {
            1 => _agent2,
            _ =>  _agent1
        };
    }
    
} 
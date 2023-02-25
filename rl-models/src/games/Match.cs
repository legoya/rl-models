using src.games;
using src.agents;
using src.models;


namespace src;


public abstract class Match<TState, TMove>
{
    private models.GameResult _gameResult;
    private Agent<TState, TMove> _player1Agent;
    private Agent<TState, TMove> _player2Agent;
    private Agent<TState, TMove> _activeAgent;

    public Match(Agent<TState, TMove> player1Agent, Agent<TState, TMove> player2Agent)
    {
        _gameResult = GameResult.Incomplete;
        _player1Agent = player1Agent;
        _player2Agent = player2Agent;
        _activeAgent = player1Agent;
    }

    public void start(IGame<TState, TMove> game)
    {
        while (_gameResult == GameResult.Incomplete)
        {
            var selectedMove = _activeAgent.SelectMoveLocation(game.State, game.AvailableLocations);
            game.MakeMove(_activeAgent.Player, selectedMove);

            _gameResult = game.GameResult(_activeAgent.Player, selectedMove);
            
            _activeAgent = alternateMove(_activeAgent);
        }

        Console.WriteLine("Game End");
        Console.WriteLine(_gameResult);

    }

    private Agent<TState, TMove> alternateMove(Agent<TState, TMove> activeAgent)
    {
        return activeAgent.Player switch
        {
            1 => _player2Agent,
            _ =>  _player1Agent
        };
    }
    
} 
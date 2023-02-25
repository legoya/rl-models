using src.games;
using src.models;


namespace src;


public class Play<TState, TMoveLocation>
{
    private Game<TState, TMoveLocation> _game;
    private models.GameResult _gameResult;
    private Agent<TState, TMoveLocation> _player1Agent;
    private Agent<TState, TMoveLocation> _player2Agent;
    private Agent<TState, TMoveLocation> _activeAgent;


    public Play(Game<TState, TMoveLocation> game, Agent<TState, TMoveLocation> player1Agent, Agent<TState, TMoveLocation> player2Agent)
    {
        _game = game;
        _gameResult = GameResult.Incomplete;
        _player1Agent = player1Agent;
        _player2Agent = player2Agent;
        _activeAgent = player1Agent;
    }

    public void start()
    {
        while (_gameResult is GameResult.Incomplete)
        {
            var selectedMove = _activeAgent.SelectMoveLocation(_game.State, _game.AvailableLocations);
            _game.MakeMove(_activeAgent.Player, selectedMove);

            _gameResult = _game.GameResult(_activeAgent.Player, selectedMove);
            
            _activeAgent = alternateMove(_activeAgent);
        }

        Console.WriteLine("Game End");
        Console.WriteLine(_gameResult);

    }

    private Agent<TState, TMoveLocation> alternateMove(Agent<TState, TMoveLocation> activeAgent)
    {
        return activeAgent.Player switch
        {
            1 => _player2Agent,
            _ =>  _player1Agent
        };
    }
    
} 
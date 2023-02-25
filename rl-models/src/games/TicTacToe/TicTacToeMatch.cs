using src.models;
using src.agents;


namespace src.games.TicTacToe;


public class TicTacToeMatch : Match<TicTacToeState, CoordinateMoveLocation>
{
    public TicTacToeMatch(Agent<TicTacToeState, CoordinateMoveLocation> player1Agent, Agent<TicTacToeState, CoordinateMoveLocation> player2Agent) : base (player1Agent, player2Agent)
    {
        
    }
}
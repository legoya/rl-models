using src.models;
using src.agents;


namespace src.games.TicTacToe;


public class Match : Match<State, CoordinateMove>
{
    public Match(Agent<State, CoordinateMove> player1Agent, Agent<State, CoordinateMove> player2Agent) : base (player1Agent, player2Agent)
    {

    }
}
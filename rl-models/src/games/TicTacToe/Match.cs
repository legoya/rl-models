using src.models;
using src.agents;


namespace src.games.TicTacToe;


public class Match : Match<State, CoordinateMove>
{
    public Match(Agent<State, CoordinateMove> agent1, Agent<State, CoordinateMove> agent2) : base(agent1, agent2) {}

}

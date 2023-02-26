using src.models;
using src.agents;


namespace src.games.TicTacToe;


public class Match : Match<State>
{
    public Match(Agent<State> agent1, Agent<State> agent2) : base(agent1, agent2) {}

}

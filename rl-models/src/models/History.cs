using src.games;

namespace src.models;


public class History
{
    public List<int> States {get; private set;}
    public List<int> Moves {get; private set;}

    public History(IState initialState)
    {
        States = new List<int>() { initialState.GetHashCode() };  // the initial state doesn't depend on any moves
        Moves = new List<int>();
    }

    public void Append(IState state, Move move)
    {
        States.Add(state.GetHashCode());
        Moves.Add(move.GetHashCode());
    }
}

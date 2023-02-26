using src;
using src.agents;
using src.games.TicTacToe;


// var a1 = new HumanAgent(1);
// var a2 = new HumanAgent(-1);

var a1 = new RandomAgent(1);
var a2 = new RandomAgent(-1);

var g = new TicTacToe(3);

// var completedGame = Match.Play(new TicTacToe(3), a1, a2);

Trainer.Train(g, a1, a2, 2);

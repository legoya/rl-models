using src;
using src.agents;
using src.games.TicTacToe;


// var a1 = new HumanAgent(1);
// var a2 = new HumanAgent(-1);

var a1 = new StateValueLearningAgent(1, 0.4, 0.05, 0.9);
// var a1 = new RandomAgent(1);
var a2 = new RandomAgent(-1);
// var a2 = new StateValueLearningAgent(-1, 0.4, 0.15, 0.9);

var g = new TicTacToe(3);

// var completedGame = Match.Play(new TicTacToe(3), a1, a2);

Trainer.Train(g, a1, a2, 10000);

using src;
using src.agents;
using src.games.TicTacToe;


var a1 = new StateValueLearningAgent(1, 0.4, 0.15, 0.9);
// var a1 = new RandomAgent(1);
var a2 = new RandomAgent(-1);
// var a2 = new StateValueLearningAgent(-1, 0.4, 0.05, 0.9);

var tg = new TicTacToe(3);
Trainer.Train(tg, a1, a2, 10000);

var l1 = new StateValueLearningAgent(1, 0.4, 0.0, 0.9);
var h2 = new HumanAgent(-1);
var hg = new TicTacToe(3);

l1.LoadLearning(hg.GetType().Name);
Match.Play(hg, l1, h2, debug: true);

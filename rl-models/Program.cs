using src;
using src.agents;
using src.games.TicTacToe;
using src.games.ConnectFour;


// var a1 = new StateValueLearningAgent(1, 0.4, 0.15, 0.9);
// var a2 = new RandomAgent(-1);

// var tg = new TicTacToe(3);
// Trainer.Train(tg, a1, a2, 10000);

// var l1 = new StateValueLearningAgent(1, 0.4, 0.0, 0.9);
// var h2 = new HumanAgent(-1);
// var hg = new TicTacToe(3);

// l1.LoadLearning(hg.GetType().Name);
// Match.Play(hg, l1, h2, debug: true);

var h1 = new src.games.ConnectFour.HumanAgent(1);
var r1 = new RandomAgent(1);
var r2 = new RandomAgent(-1);

// var ttt = new TicTacToe(3);

// Match.Play(ttt, r1, r2, debug: true);

var cfg = new ConnectFour(6, 7);
Match.Play(cfg, h1, r2, debug: true);


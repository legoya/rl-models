using src;
using src.agents;
using src.games.TicTacToe;


// var a1 = new HumanAgent(1);
// var a2 = new HumanAgent(-1);

var a1 = new RandomAgent(1);
var a2 = new RandomAgent(-1);

var g = new TicTacToe(3);

Match.start(g, a1, a2);

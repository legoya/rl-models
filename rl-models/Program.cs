using src.agents;
using src.games;
using src.games.TicTacToe;


// var a1 = new HumanAgent(1);
// var a2 = new HumanAgent(-1);

var a1 = new RandomAgent(1);
var a2 = new RandomAgent(-1);

var m = new Match(a1, a2);
var g = new Game(3);

m.start(new Game(3));

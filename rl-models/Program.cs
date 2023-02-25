using src.games.TicTacToe;


var g = new TicTacToeGame(3);

var h1 = new HumanAgent(1);
var h2 = new HumanAgent(-1);

var p = new TicTacToeMatch(h1, h2);
p.start(g);
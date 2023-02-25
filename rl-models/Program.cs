using src.games.TicTacToe;


var h1 = new HumanAgent(1);
var h2 = new HumanAgent(-1);

var m = new Match(h1, h2);
var g = new Game(3);

m.start(new Game(3));

using src.games.TicTacToe;
using src.models;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var ttts = new TicTacToeState(3);
var tttm = new TicTacToeMove(1, 1, 1);

var x = new X(1);

ttts.Update(x);
ttts.HasWinner(tttm);

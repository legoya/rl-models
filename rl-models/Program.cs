using src.games.TicTacToe;
using src.models;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var ttts = new TicTacToeState(3);

var m1 = new TicTacToeMove(1, 1, 1);
ttts.Update(m1);
Console.WriteLine(ttts.HasWinner(m1));

var m2 = new TicTacToeMove(1, 1, 1);
ttts.Update(m1);
Console.WriteLine(ttts.HasWinner(m2));

var m3 = new TicTacToeMove(1, 1, 1);
ttts.Update(m1);
Console.WriteLine(ttts.HasWinner(m3));

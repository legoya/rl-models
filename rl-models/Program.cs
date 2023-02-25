﻿using src;
using src.games.TicTacToe;
using src.models;


var g = new TicTacToeGame(3);

var h1 = new HumanAgent(1);
var h2 = new HumanAgent(-1);

var p = new Play<TicTacToeState, CoordinateMoveLocation>(g, h1, h2);
p.start();
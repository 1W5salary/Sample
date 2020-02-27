You have been provided with a third-party library "ChessLib" which calculates the legal moves a knight can make given
a position on an 8 by 8 board. The library has been used to create a program which moves a knight randomly around a
board, given an initial starting position and a total number of moves to make.

Problem:
========

Extend this program to set up an 8 by 8 square game board containing several different pieces in predefined positions.
For each move of the game, the program will choose a piece at random, and move it to a randomly selected valid
position.

You are not allowed to change any of the ChessLib code.
 
Extend the program as required. 
Use Object Oriented Design and Modeling appropriately for extensibility.

Please supply all the code for your solution in the file Answer.cs in the SampleProgram project.
Please supply all the tests for your solution in the file TestAnswer.cs in the SampleProgram.Test project.


Game Rules:
-----------
 
* Only one piece can occupy any position on the board at a given time.
* All pieces can “jump” any occupied position.

Note: Although the game bears a striking resemblance to Chess, this is entirely coincidental. Do not assume other
chess rules apply.

 
Game Pieces to support:
-----------------------

* Knight – Moves as implemented by ChessLib
* Bishop - Moves diagonally, any distance within board boundaries
* Queen – Moves diagonally, horizontally or vertically, any distance within board boundaries

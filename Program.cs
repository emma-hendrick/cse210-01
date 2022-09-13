/*
Tic-Tac-Toe
Author: Michael Hendrick
Assignment: "Unit 01 Prove: Developer"
*/
using System.Collections.Generic;

namespace TicTacToeProgram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Players!");

            // Create a new TicTacToe board
            TicTacToe board = new TicTacToe();
            char player, winner;
            int space;
            int turnNum = 0;

            char[] players = new char[2]{'X', 'O'};

            do {

            player = players[turnNum % 2];

            // Play the current turn
            Console.WriteLine();
            Console.WriteLine(board);
            Console.WriteLine($"{player}'s turn to choose a square (1-9): ");

            // Declare variable space to be the space the player is trying to play in
            space = int.Parse(Console.ReadLine() ?? "0");

            if (board.CheckPos(space) == players[turnNum % 2] || board.CheckPos(space) == players[(turnNum + 1) % 2]) {
                Console.WriteLine("No Cheating!");
                winner = ' ';
            }
            else {
                winner = board.PlayTurn(player, space);
                turnNum++;
            }
            if (turnNum >= 9) {winner = '.';}

            } while (winner == ' ');

            Console.WriteLine();
            Console.WriteLine(board);
            if (winner == '.'){Console.WriteLine("It's a draw!!");}
            else {Console.WriteLine($"Game Over! {winner} won!!");}

        }
    }

    public class TicTacToe
    {
        // Initialize an empty board
        private char[,] board;

        // Class constructor
        public TicTacToe(){

            // Initialize an empty 3x3 board
            board = new char[3, 3]{{'1','2','3'},{'4','5','6'},{'7','8','9'}};

        }

        // Called when a player takes a turn, it will return an X if the turn results in X winning, will return an O if it results in O winning, or will return a space otherwise
        public char PlayTurn(char player, int position)
        {

            position -= 1;

            int x = position / 3;
            int y = position % 3;
            int boardSize = 3;
            // Set the specified index to the correct symbol
            board[x, y] = player;

            // Check for a win on the X axis
            for (int i = 0; i < boardSize; i++) {

                // If any item in the X axis isn't the players symbol then exit the loop
                if (board[i, y] != player){
                    break;
                }

                // Otherwise, report a win
                if (i == (boardSize - 1)){
                    return player;
                }
            }

            // Check for a win on the Y axis
            for (int i = 0; i < boardSize; i++) {

                // If any item in the Y axis isn't the players symbol then exit the loop
                if (board[x, i] != player){
                    break;
                }

                // Otherwise, report a win
                if (i == (boardSize - 1)){
                    return player;
                }
            }

            // Check for a win along the main diagonal
            if (x == y) {
                for (int i = 0; i < boardSize; i++) {
                    // If any item along the diagonal isn't the players symbol then exit the loop
                    if (board[i, i] != player){
                        break;
                    }

                    // Otherwise, report a win
                    if (i == (boardSize - 1)){
                        return player;
                    }
                }
            }

            // Check for a win along the other diagonal
            if (x + y == 2) {
                for (int i = 0; i < boardSize; i++) {
                    // If any item along the diagonal isn't the players symbol then exit the loop
                    if (board[2-i, i] != player){
                        break;
                    }

                    // Otherwise, report a win
                    if (i == (boardSize - 1)){
                        return player;
                    }
                }
            }

            return ' ';
        }

        // Convert the board into a string for display
        public override string ToString()
        {
            string boardString = "";
            int boardStringSize = 5;

            for (int i = 0; i < boardStringSize; i ++) {
                for (int j = 0; j < boardStringSize; j ++) {
                    if (i % 2 == 1 && j % 2 == 1) {boardString += "+";}
                    else if (i % 2 == 1) {boardString += "-";}
                    else if (j % 2 == 1) {boardString += "|";}
                    else {boardString += board[i / 2, j / 2];}
                }

                boardString += "\n";
            }

            return boardString;
        }

        // Check if there is a character at the specified position
        public char CheckPos(int position)
        {
            position -= 1;

            int x = position / 3;
            int y = position % 3;
            
            return board[x, y];
        }

    }

}

using System;

namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board(4);
           // var player = new Player();
            //var mine = new Mine(board);
            // var minesweeper = new Minesweeper(board, player);
            //
            // minesweeper.PlayGame();
            
            Console.WriteLine(board.DisplayBoard());
           
           
           Console.WriteLine(board.DisplayBoardForPlayer());
            
        }
    }
}
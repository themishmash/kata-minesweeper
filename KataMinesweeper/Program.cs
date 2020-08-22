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
            //Console.WriteLine(board.DisplayBoard1());

            //to access _boardSquares
            // foreach (var item in board._boardSquares1)
            // {
            //     foreach (var square in item)
            //     {
            //         Console.WriteLine(square.Value);
            //     }
            // }

            // var coordinate = new Coordinate(1,1);
            // board.GenerateHintForSingleSquare(coordinate);
            // var coordinate2 = new Coordinate(1,3);
            // board.GenerateHintForSingleSquare(coordinate2);
            
            var coordinate = new Coordinate(1,0);
            board.GenerateHintForSingleSquare(coordinate);
            board.DisplayBoard();
            
           Console.WriteLine(board.DisplayBoard());
            
        }
    }
}
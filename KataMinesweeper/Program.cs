using System;

namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        
        {
            var board = new Board(4);
            
            var consoleInputOutput = new ConsoleInputOutput();
            var player = new Player(consoleInputOutput);
            var coord = player.PlayTurn();
            var minesweeper = new Minesweeper(board, player, consoleInputOutput);
            
           //  board.GetHintForPlayerMove(coord);
           //  Console.WriteLine(board.DisplayBoard());
           //
           //  var coordinate = new Coordinate(1,1);
           //  board.GetHintForPlayerMove(coordinate);
           //  Console.WriteLine(board.DisplayBoard());
           //  
           //  var coordinate2 = new Coordinate(1,2);
           //  board.GetHintForPlayerMove(coordinate2);
           //  Console.WriteLine(board.DisplayBoard());
           //  
           //  
           //  var coordinate3 = new Coordinate(1,0);
           //  board.GetHintForPlayerMove(coordinate3);
           //  board.DisplayBoard();
           //  
           // Console.WriteLine(board.DisplayBoard());
            
        }
    }
}
using System;

namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board(4);
            Console.WriteLine(board.DisplayBoard());
            
        }
    }
}
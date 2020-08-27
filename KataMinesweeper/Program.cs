namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
         var board = new Board(4);
         var consoleInputOutput = new ConsoleInputOutput();
         var player = new Player(consoleInputOutput);
         var minesweeper = new Minesweeper(board, player, consoleInputOutput);
         minesweeper.PlayGame();
        }
    }
}
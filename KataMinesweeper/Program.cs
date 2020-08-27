namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
         var board = new Board(4);
         var consoleInputOutput = new ConsoleInputOutput();
         var mineGenerator = new MineGenerator(board);
         
         var player = new Player(consoleInputOutput);
         var minesweeper = new Minesweeper(board, player, consoleInputOutput, mineGenerator);
         minesweeper.PlayGame();
        }
    }
}
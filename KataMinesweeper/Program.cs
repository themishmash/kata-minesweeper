using System;
using System.Net;

namespace KataMinesweeper
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");
            Console.WriteLine("Please enter the difficulty level:");
            var difficultyLevel = Console.ReadLine();
            var board = new Board(int.Parse(difficultyLevel));
            var consoleInputOutput = new ConsoleInputOutput();
            var player = new Player(consoleInputOutput);
            var mineGenerator = new MineGenerator(board);
            var minesweeper = new Minesweeper(board, player, consoleInputOutput, mineGenerator);
            minesweeper.PlayGame();
            
            while (true)
            {
                if (minesweeper.GameStatus == GameStatus.Lost || minesweeper.GameStatus == GameStatus.Won)
                {
                    Console.WriteLine("Would you like to play again?");
                    Console.WriteLine("1. Yes please!");
                    Console.WriteLine("2. No thanks.");
                    var selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                        {
                            Console.WriteLine("Please enter the difficulty level:");
                            difficultyLevel = Console.ReadLine();
                            board = new Board(int.Parse(difficultyLevel));
                            consoleInputOutput = new ConsoleInputOutput();
                            player = new Player(consoleInputOutput);
                            mineGenerator = new MineGenerator(board);
                            minesweeper = new Minesweeper(board, player, consoleInputOutput, mineGenerator);
                            minesweeper.PlayGame();
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
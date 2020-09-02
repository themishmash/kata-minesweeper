using System;
using System.Net;

namespace KataMinesweeper
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            processUserOptions();
        }

        private static void processUserOptions()
        {
            Console.WriteLine("Welcome to Minesweeper!");
            while (true)
            {
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("1. Play an easy Minesweeper game");
                Console.WriteLine("2. Customise my Minesweeper game");
                Console.WriteLine("3. Exit");
                var userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out var userOption))
                {
                    Console.WriteLine("Please enter a number");
                }
                
                if (userOption == 1)
                {
                    var board = new Board(3);
                    var consoleInputOutput = new ConsoleInputOutput();
                    var player = new Player(consoleInputOutput);
                    var mineGenerator = new MineGenerator(board);
                    var minesweeper = new Minesweeper(board, player, consoleInputOutput, mineGenerator);
                    minesweeper.PlayGame();
                }
            
                else if (userOption == 2)
                {
                    Console.WriteLine("Please enter the difficulty level:");
                    var difficultyLevel = Console.ReadLine();
                    var board = new Board(int.Parse(difficultyLevel));
                    var consoleInputOutput = new ConsoleInputOutput();
                    var player = new Player(consoleInputOutput);
                    var mineGenerator = new MineGenerator(board);
                    var minesweeper = new Minesweeper(board, player, consoleInputOutput, mineGenerator);
                    minesweeper.PlayGame();
                }
            
                else if (userOption == 3)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }

        }
    }
}
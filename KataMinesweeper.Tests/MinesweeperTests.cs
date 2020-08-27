using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class MinesweeperTests
    {
        [Fact]
        public void Game_Status_Set_To_Playing_At_Start_Of_Game()
        {
            var board = new Board(4);
            var testInput = new PlayerInput(new List<(int, int)>{(1, 1)});
            var mineInput = new MineGeneratorInput(board);
            var player = new Player(testInput);
            var minesweeper = new Minesweeper(board, player, new NullInputOutput(), mineInput);
        
            Assert.Equal(GameStatus.Playing, minesweeper.GameStatus);
        }

        [Fact]
        public void Game_Status_Set_To_Lost_After_Player_Clicks_Mine()
        {
            var board = new Board(4);
            var testInput = new PlayerInput(new List<(int, int)>{(1,1), (1, 0)});
            var mineInput = new MineGeneratorInput(board);
            var player = new Player(testInput);
            var minesweeper = new Minesweeper(board, player, new NullInputOutput(), mineInput);
            minesweeper.PlayGame();
            
            Assert.Equal(GameStatus.Lost, minesweeper.GameStatus);
        }

        [Fact]
        public void Game_Status_Set_To_Won_After_Player_Clicks_All_Non_Mines()
        {
            var board = new Board(4);
            var testInput = new PlayerInput(new List<(int, int)>{(0,1),(0,2),(0,3),(1,1),(1,2),(1,3),(2,1),(2,2),(2,3),(3,1),(3,2),(3,3)});
            var player = new Player(testInput);
            var mineInput = new MineGeneratorInput(board);
            var minesweeper = new Minesweeper(board, player, new NullInputOutput(), mineInput);
            minesweeper.PlayGame();
            
            Assert.Equal(GameStatus.Won, minesweeper.GameStatus);
        }
        
    }
}
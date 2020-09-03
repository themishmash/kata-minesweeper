using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void Selecting_Mine_Will_Reveal_Mines_And_Hints()
        {
            var board = new Board(4);
            var playerInput = new PlayerInput(new List<(int, int)>{(1,0)});
            var player = new Player(playerInput);
            var mineInput = new MineGeneratorInput();
            var minesweeper = new Minesweeper(board, player, playerInput, mineInput);
            minesweeper.PlayGame();
            
           Assert.Equal(" *  2  0  0 \n *  3  0  0 \n *  3  0  0 \n *  2  0  0 \n", minesweeper.DisplayBoard(true));
        }

        [Fact]
        public void Selecting_All_Squares_Except_Mines()
        {
            var board = new Board(4);
            var playerInput = new PlayerInput(new List<(int, int)>{(0,1),(0,2),(0,3),(1,1),(1,2),(1,3),(2,1),(2,2),
            (2,3),(3,1),(3,2),(3,3)});
            var player = new Player(playerInput);
            var mineInput = new MineGeneratorInput();
            var minesweeper = new Minesweeper(board, player, playerInput, mineInput);
            minesweeper.PlayGame();
            
           Assert.Equal(" .  2  0  0 \n .  3  0  0 \n .  3  0  0 \n .  2  0  0 \n", minesweeper.DisplayBoard(false));
        }
    }
}
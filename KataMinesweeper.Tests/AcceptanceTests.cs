using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void Making_A_Move_Will_Reveal_Mines_And_Hints()
        {
            var board = new Board(4);
            var playerInput = new PlayerInput(new List<(int, int)>{(1,0)});
            var player = new Player(playerInput);
            var mineInput = new MineGeneratorInput(board);
            var minesweeper = new Minesweeper(board, player, playerInput, mineInput);
            minesweeper.PlayGame();
            
           Assert.Equal(" *  2  0  0 \n *  3  0  0 \n *  3  0  0 \n *  2  0  0 \n", minesweeper.DisplayBoard(true));
        }

        [Fact]
        public void Making_A_Move_Will_Reveal_One_Hint()
        {
            var board = new Board(4);
            var playerInput = new PlayerInput(new List<(int, int)>{(1,1)});
            var player = new Player(playerInput);
            var mineInput = new MineGeneratorInput(board);
            var minesweeper = new Minesweeper(board, player, playerInput, mineInput);
            minesweeper.PlayGame();
            
           Assert.Equal(" .  .  .  . \n .  3  .  . \n .  .  .  . \n .  .  .  . \n", minesweeper.DisplayBoard(false));
        }
    }
}
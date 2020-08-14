using System;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        
        public void Making_A_Move_Will_Update_Board()
        {
            var board = new Board(4);
            var player = new Player();
            player.MakeMove(1, 1);
            var minesweeper = new Minesweeper(board, player);
            minesweeper.PlayGame();

            Assert.Equal(GameStatus.Playing, minesweeper.GameStatus);
            Assert.Equal(4, board.CountMines());
            // Assert.Equal(1, move.XCoordinate);
            // Assert.Equal(1, move.YCoordinate);
            //Assert.Equal(" . .  .  . \n .  .  . . \n .  .  . . ", board.DisplayBoard());
        }
        
    }
}
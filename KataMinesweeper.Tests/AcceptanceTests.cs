using System;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        
        public void Making_A_Move_Will_Reveal_Mines()
        {
            var board = new Board(4);
            var player = new Player();
            player.PlayTurn(1, 1);
            // var minesweeper = new Minesweeper(board, player);
            // minesweeper.PlayGame();

            
            Assert.Equal(4, board.CountMines());
            // Assert.Equal(1, move.XCoordinate);
            // Assert.Equal(1, move.YCoordinate);
            //Assert.Equal(GameStatus.Lost, minesweeper.GameStatus);
           // Assert.Equal(" *  2  0  0 \n *  3  0  0 \n *  3  0  0 \n *  2  0  0 ",board.DisplayBoard());
           
        }
        
    }
}
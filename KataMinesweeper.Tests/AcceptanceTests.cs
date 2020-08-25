using System;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        
        public void Making_A_Move_Will_Reveal_Mines_And_Hints()
        {
            var board = new Board(4);
            //var player = new Player();
           // player.PlayTurn(1, 0);
            // var minesweeper = new Minesweeper(board, player);
            // minesweeper.PlayGame();

            
            //Assert.Equal(4, board.CountMines());
            // Assert.Equal(1, move.XCoordinate);
            // Assert.Equal(0, move.YCoordinate);
            //Assert.Equal(GameStatus.Lost, minesweeper.GameStatus);
           // Assert.Equal(" *  2  0  0 \n *  3  0  0 \n *  3  0  0 \n *  2  0  0 ",board.DisplayBoard());
           
        }

        [Fact]
        public void Making_A_Move_Will_Reveal_One_Hint()
        {
            // var board = new Board(4);
            // var player = new Player();
            // player.PlayTurn(1, 1);
            // var minesweeper = new Minesweeper(board, player);
            // minesweeper.PlayGame();
            //
            // Assert.Equal(4, board.countMines());
            // Assert.Equal(1, move.XCoordinate);
            // Assert.Equal(1, move.YCoordinate);
            //Assert.Equal(GameStatus.playing, minesweeper.GameStatus);
           // Assert.Equal(" .  .  .  . \n .  3  .  . \n .  .  .  . \n .  .  .  . \n",board.DisplayBoard());
        }
        
        //[Fact]
        //public void 
        
    }
}
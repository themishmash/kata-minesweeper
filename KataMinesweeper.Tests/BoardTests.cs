using Xunit;

namespace KataMinesweeper.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Generate_4x4_Board_With_4_Mines()
        {
           var board = new Board(4);
          Assert.Equal(4, board.CountMines());
        }

        // [Fact]
        // public void Generate_Board()
        // {
        //     var board = new Board(4);
        //     Assert.Equal(" *  .  .  . \n *  .  .  . \n *  .  .  . \n *  .  .  . ",board.DisplayBoard());
        // }
        [Fact]
        public void Generate_Squares_In_Board_With_Hints()
        {
            var board = new Board(4);
            Assert.Equal(" *  2  0  0  \n *  3  0  0  \n *  3  0  0  \n *  2  0  0  \n",board.DisplayBoard());
        }

        
    }
}
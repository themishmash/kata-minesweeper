using Xunit;

namespace KataMinesweeper.Tests
{
    public class WinLoseTests
    {
        [Fact]
        public void Mines_Created_According_To_Size_Of_Board()
        {
            var board = new Board(4);
            var winLose = new WinLose(board);
            
            Assert.Equal(4, board.CountMines());
        }

        //todo up to here
        [Fact]
        public void Change_Square_To_Revealed_When_Selected()
        {
            var board = new Board(4);
            var winLose = new WinLose(board);
            var coordinate = new Coordinate(1,1);
            winLose.RevealSquareForPlayerMove(coordinate);
           // Assert.Equal(true, 
        }
    }
}
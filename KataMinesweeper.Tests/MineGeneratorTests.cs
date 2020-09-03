using Xunit;

namespace KataMinesweeper.Tests
{
    public class MineGeneratorTests
    {
        [Fact]
        public void Place_Mines_According_To_Board_Size()
        {
            var board = new Board(4);
            var mineGeneratorInput = new MineGeneratorInput();
            var coordinate = new Coordinate(0,0);
            var square = board.GetSquare(coordinate);
            mineGeneratorInput.PlaceMinesToBoard(board);
            
            Assert.True(square.IsMine);
            Assert.Equal(4, board.GetNumberOfMines());
        }
    }
    
}
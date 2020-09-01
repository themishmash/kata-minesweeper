using Xunit;

namespace KataMinesweeper.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Generate_Board_Of_Size_4()
        {
            var board = new Board(4);

            Assert.Equal(4, board.Size);
        }
        
        [Fact]
        public void Get_Square_From_Coordinates()
        {
            var board = new Board(4);
            var square = board.GetSquare(new Coordinate(1,1));
            
           Assert.Equal(1, square.Coordinate.X);
           Assert.Equal(1, square.Coordinate.Y);
        }

        
    }
}
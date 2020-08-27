using Xunit;

namespace KataMinesweeper.Tests
{
    public class MineGeneratorTests
    {
        [Fact]
        public void Place_Mines_According_To_Board_Size()
        {
            var board = new Board(4);
            var mineGeneratorInput = new MineGeneratorInput(board);
            mineGeneratorInput.PlaceMinesToBoard();
            var coordinate = new Coordinate(1,1);
            var hintCalculator = new HintCalculator(board);
            
            Assert.Equal(3, hintCalculator.Calculate(coordinate));
            
        }
    }
}
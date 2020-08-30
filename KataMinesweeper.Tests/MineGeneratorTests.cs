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
            var playerCoordinate = new Coordinate(1,3);
            mineGeneratorInput.PlaceMinesToBoard(playerCoordinate);
            var hintCalculator = new HintCalculator(board);
            
            Assert.Equal(0, hintCalculator.Calculate(playerCoordinate));
        }
    }
}
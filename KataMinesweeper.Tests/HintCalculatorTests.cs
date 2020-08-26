using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class HintCalculatorTests
    {
        [Fact]
        public void Return_Hint_From_Coordinate()
        {
            var board = new Board(3);
          
            var hintCalculator = new HintCalculator(board);

            var coordinate = new Coordinate(1,1);
            var mine = board.GetSquare(new Coordinate(0,0)).IsMine = true;
            var mine2 = board.GetSquare(new Coordinate(1,0)).IsMine = true;
            var mine3 = board.GetSquare(new Coordinate(2,0)).IsMine = true;

            Assert.Equal(3, hintCalculator.Calculate(coordinate));
        }

        [Fact]
        public void Return_Hint_For_Coordinate_With_Only_Three_Neighbours()
        {
            var board = new Board();
        }
        
        //Test for top left corner, test for bottom right, test for top right, bottom left
        //test for 8 mines and empty space in middle
    }
}
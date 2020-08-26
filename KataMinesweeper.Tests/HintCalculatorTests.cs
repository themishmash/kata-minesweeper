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
        public void Return_Hint_For_Top_Left_Corner_Coordinate_With_Three_Neighbours()
        {
            var board = new Board(3);
            var hintCalculator = new HintCalculator(board);
            var coordinate = new Coordinate(0,0);
            
            Assert.Equal(0, hintCalculator.Calculate(coordinate));
        }

        [Fact]
        public void Return_Hint_For_Bottom_Right_Coordinate_With_Three_Neighbours()
        {
            var board = new Board(3);
            var hintCalculator = new HintCalculator(board);
            var coordinate = new Coordinate(2,2);
            
            Assert.Equal(0, hintCalculator.Calculate(coordinate));
        }
        
        [Fact]
        public void Return_Hint_For_Top_Right_Coordinate_With_Three_Neighbours()
        {
            var board = new Board(3);
            var hintCalculator = new HintCalculator(board);
            var coordinate = new Coordinate(0,2);
            
            Assert.Equal(0, hintCalculator.Calculate(coordinate));
        }
        
        [Fact]
        public void Return_Hint_For_Bottom_Left_Coordinate_With_Three_Neighbours()
        {
            var board = new Board(3);
            var hintCalculator = new HintCalculator(board);
            var coordinate = new Coordinate(2,0);
            
            Assert.Equal(0, hintCalculator.Calculate(coordinate));
        }

        [Fact]
        public void Return_Hint_For_Coordinate_With_Eight_Mine_Neighbours()
        {
            var board = new Board(3);
            var hintCalculator = new HintCalculator(board);
            var coordinate = new Coordinate(1,1);
            var mine = board.GetSquare(new Coordinate(0,0)).IsMine = true;
            var mine2 = board.GetSquare(new Coordinate(1,0)).IsMine = true;
            var mine3 = board.GetSquare(new Coordinate(2,0)).IsMine = true;
            var mine4 = board.GetSquare(new Coordinate(0,1)).IsMine = true;
            var mine5 = board.GetSquare(new Coordinate(0,2)).IsMine = true;
            var mine6 = board.GetSquare(new Coordinate(1,2)).IsMine = true;
            var mine7 = board.GetSquare(new Coordinate(2,1)).IsMine = true;
            var mine8 = board.GetSquare(new Coordinate(2,2)).IsMine = true;
            
            Assert.Equal(8, hintCalculator.Calculate(coordinate));
        }
    }
}
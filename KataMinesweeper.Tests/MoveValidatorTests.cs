using Xunit;

namespace KataMinesweeper.Tests
{
    public class MoveValidatorTests
    {
        [Fact]
        public void Coordinate_Is_Valid_When_Placing_Move_On_Vacant_Spot()
        {
            var board = new Board(4);
            var coordinate = new Coordinate(1,1);
            Assert.True(MoveValidator.IsValidMove(coordinate, board));
        }

        [Fact]
        public void Coordinate_Is_Invalid_When_Placing_Move_On_Revealed_Spot()
        {
            var board = new Board(4);
            var validCoordinate = new Coordinate(1,1);
            var invalidCoordinate = new Coordinate(1,1);
            var square = board.GetSquare(validCoordinate);
            square.IsRevealed = true;
           
            Assert.False(MoveValidator.IsValidMove(invalidCoordinate, board));
        }

        [Fact]
        public void Coordinate_Is_Invalid_When_Placing_Move_On_Spot_Outside_Of_Boundaries()
        {
            var board = new Board(4);
            var coordinate = new Coordinate(4,4);

            Assert.False(MoveValidator.IsValidMove(coordinate, board));
        }
        
        [Fact]
        public void Coordinate_Is_Invalid_When_It_Is_Negative()
        {
            var board = new Board(4);
            var coordinate = new Coordinate(-2,0);
            
            Assert.False(MoveValidator.IsValidMove(coordinate, board));
        }
    }
}
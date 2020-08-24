using Xunit;

namespace KataMinesweeper.Tests
{
    public class CoordinateValidatorTests
    {
        [Fact]
        public void Turn_Is_Valid_When_Square_Is_Selected_On_Vacant_Spot()
        {
            var board = new Board(4);
            var coordinate = new Coordinate(1,1);
           
            Assert.True(CoordinateValidator.IsValidMove(coordinate, board));
        }

        [Fact]
        public void Turn_Is_Invalid_When_Square_Is_Selected_On_Filled_Spot()
        {
            var board = new Board(4);
            var validMove = new Coordinate(1,1);
            var invalidMove = new Coordinate(1,1);
            board.GetHintForPlayerMove(validMove);
            
            Assert.False(CoordinateValidator.IsValidMove(invalidMove, board));
        }

        [Fact]
        public void Turn_Is_Invalid_When_Choosing_Coordinates_Outside_Of_Boundaries()
        {
            var board = new Board(4);
            var coordinate = new Coordinate(-2,4);
            
            Assert.False(CoordinateValidator.IsValidMove(coordinate, board));
        }
    }
}
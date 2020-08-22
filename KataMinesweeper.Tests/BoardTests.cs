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
        
        [Fact]
        public void ChangeSquareToPlayerSymbolXForValidMove()
        {
            var board = new Board(4);
           var coordinate = new Coordinate(1,1);
           board.GenerateHintForSingleSquare(coordinate);
            //board.DisplayBoardForPlayer();
            Assert.Equal(" .  .  .  . \n .  3  .  . \n .  .  .  . \n .  .  .  . \n",board.DisplayBoard());
        }
        
        
        //from tic tac toe
        // [Fact]
        // public void GenerateSquaresInBoardWithCorrectCoordinates()
        // {
        //     var board = new Board(3);
        //     Assert.Equal(" .  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
        // }
        //
        // [Fact]
        // public void ChangeSquareToPlayerSymbolXForValidMove()
        // {
        //     var board = new Board(3);
        //     var move = new Move(1,1);
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, move);
        //     board.DisplayBoard();
        //     Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
        // }

        
    }
}
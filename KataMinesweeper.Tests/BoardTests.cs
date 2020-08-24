using Xunit;

namespace KataMinesweeper.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Generate_Board_Display_For_Player()
        {
            var board = new Board(4);
            
            Assert.Equal(" .  .  .  . \n .  .  .  . \n .  .  .  . \n .  .  .  . \n",board.DisplayBoard());
        }
        
        [Fact]
        public void Generate_4x4_Board_With_4_Mines()
        {
           var board = new Board(4);
           var minesweeper = new Minesweeper(board);
          
           Assert.Equal(4, board.CountMines());
        }

        [Fact]
        public void Change_Square_To_Hint_For_Single_Coordinate()
        {
            var board = new Board(4);
            var minesweeper = new Minesweeper(board);
            var coordinate = new Coordinate(1,1);
           board.GetHintForPlayerMove(coordinate);
           
           Assert.Equal(" .  .  .  . \n .  3  .  . \n .  .  .  . \n .  .  .  . \n",board.DisplayBoard());
        }

        [Fact]
        public void Reveal_Entire_Board_When_Mine_Chosen()
        {
            var board = new Board(4);
            var minesweeper = new Minesweeper(board);
            var coordinate = new Coordinate(1,0);
            board.GetHintForPlayerMove(coordinate);
            
            Assert.Equal(" *  2  0  0 \n *  3  0  0 \n *  3  0  0 \n *  2  0  0 \n", board.DisplayBoard());
        }
    }
}
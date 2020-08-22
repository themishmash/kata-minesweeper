using Xunit;

namespace KataMinesweeper.Tests
{
    public class MoveTests
    {
        [Fact]
        public void Generate_Board_For_Player_After_Making_Move()
        {
            var board = new Board(4);
            var player = new Player();
            player.MakeMove(1, 1);
            
            var move = new Coordinate(1,1);
            
           // Assert.Equal(" .  2  .  .  \n .  .  .  .  \n .  .  .  .  \n .  .  .  .  \n", move.DisplayBoardForPlayer());
        }
        //test array for the board
    }
}
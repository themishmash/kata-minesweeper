using Xunit;

namespace KataMinesweeper.Tests
{
    public class MinesweeperTests
    {
        [Fact]
        public void Game_Status_Set_To_Playing_At_Start_Of_Game()
        {
            var board = new Board(4);
            var testInput = new PlayerInput((1,1));
            var player = new Player(testInput);
            var minesweeper = new Minesweeper(board, player, new NullInputOutput());

            Assert.Equal(GameStatus.Playing, minesweeper.GameStatus);
        }
        
        
    }
}
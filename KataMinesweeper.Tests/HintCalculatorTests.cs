using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class HintCalculatorTests
    {
        [Fact]
        public void Return_Hint_From_Coordinates()
        {
            var board = new Board(4);
            var hintCalculator = new HintCalculator(board);
            var playerInput = new PlayerInput(new List<(int, int)> {(1,1)});
            var player = new Player(playerInput);
            var minesweeper = new Minesweeper(board, player, new NullInputOutput());
            var coordinate = new Coordinate(1,1);

            Assert.Equal(3, hintCalculator.GetHintFromPlayerMove(coordinate));
        }
    }
}
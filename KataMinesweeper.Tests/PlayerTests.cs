using System.Collections.Generic;
using Xunit;

namespace KataMinesweeper.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Plays_Single_Turn_With_X_And_Y_Coordinates()
        {
            //arrange
            var input = new PlayerInput(new List<(int, int)>{(1,1)});
            var playerX = new Player(input);
            //act
            var coordinate = playerX.PlayTurn();
            //assert
            Assert.Equal(1, coordinate.XCoordinate);
            Assert.Equal(1, coordinate.YCoordinate);
        }
        
    }
}
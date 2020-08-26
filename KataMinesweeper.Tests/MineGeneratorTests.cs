// using System.Collections.Generic;
// using Xunit;
//
// namespace KataMinesweeper.Tests
// {
//     public class MineGeneratorTests
//     {
//         [Fact]
//         public void Place_Mines_According_To_Board_Size()
//         {
//             // var mine = new MineGeneratorInput(0,0);
//             // var board = new Board(4);
//             // var mineGenerator = new MineGenerator(board);
//             //
//             // // var playerInput = new PlayerInput(new List<(int, int)>{(0,0)});
//             // // var player = new Player(playerInput);
//             // // var coordinate = player.PlayTurn();
//             var board = new Board(4);
//             var playerInput = new PlayerInput(new List<(int, int)>{(0,0)});
//             var player = new Player(playerInput);
//            // var mineGeneratorInput = new MineGeneratorInput(new List<Square>());
//             var minesweeper = new Minesweeper(board, player, new NullInputOutput());
//
//
//             var square = board.GetSquare(1, 1);
//             
//             Assert.True(square.IsMine);
//             
//         }
//     }
// }
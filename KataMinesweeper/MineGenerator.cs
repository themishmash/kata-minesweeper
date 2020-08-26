// using System;
// using System.Collections.Generic;
//
// namespace KataMinesweeper
// {
//     public class MineGenerator: IMineGenerator
//     {
//         private readonly Board _board;
//         private List<Square> _mines;
//         public MineGenerator(Board board)
//         {
//             _board = board;
//             GenerateMines();
//         }
//
//         private int GetXCoordinate()
//         {
//            var random = new Random();
//            var randomCoordinate = random.Next(0, _board.Size+1);
//            return randomCoordinate;
//         }
//
//         private int GetYCoordinate()
//         {
//             var random = new Random();
//             var randomCoordinate = random.Next(0, _board.Size+1);
//             return randomCoordinate;
//         }
//
//         public IEnumerable<Square> GenerateMines()
//         {
//             _mines = new List<Square>();
//             for (var i = 0; i <= _board.Size; i++)
//             {
//                 var mine = new Square(GetXCoordinate(), GetYCoordinate()){IsMine = true};
//                 if (!_mines.Contains(mine))
//                 {
//                     _mines.Add(mine);
//                 }
//             }
//
//             return _mines;
//         }
//
//         public void PlaceMinesToBoard()
//         {
//             foreach (var mine in GenerateMines())
//             {
//                 _board.GetSquare(mine.XCoordinate, mine.YCoordinate).IsMine = true;
//             }
//         }
//     }
// }
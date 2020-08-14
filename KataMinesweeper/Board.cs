using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMinesweeper
{
    public class Board
    {
        public readonly int Size;
        private Square[,] _squares;


        public Board(int size)
        {
            Size = size;
            CreateBoard();
            //generate mines? 
            GenerateMines();
            
        }

        private void CreateBoard()
        {
            _squares = new Square[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _squares[x,y] = new Square(x,y);
                }
            }
        }
        
        private void GenerateMines()
        { 
            
            var mineList = new List<Square>();
            for (var i = 0; i < Size; i++)
            {
                var mine = new Square(i, 0){MineStatus = MineStatus.True};
                mineList.Add(mine);
            }
            
            //Why do i need this method? 
            
            foreach (var item in mineList)
            {
                GetSquareByCoordinates(item).MineStatus = MineStatus.True;
            }
           
        }

        public int CountMines()
        {
            return _squares.Cast<Square>().Count(square => square.MineStatus == MineStatus.True);
        }
        
        public string DisplayBoard()
        {

            var currentBoard = "";
            var rows = new string[Size];

            for (var currentRow = 0; currentRow < Size; currentRow++)
            {
                var columns = new string[Size];
                for (var currentCol = 0; currentCol < Size; currentCol++)
                {
                    columns[currentCol] = _squares[currentRow, currentCol].ToString();
                }
                rows[currentRow] = string.Join("", columns);
            }
            currentBoard += string.Join("\n", rows);
            return currentBoard;
        }

        public Square GetSquareByCoordinates(Square square)
        {
            return _squares[square.XCoordinate, square.YCoordinate];
        }
        
    }
}
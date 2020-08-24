using System;
using System.Runtime.InteropServices;

namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string Value { get; set; }
        public MineStatus MineStatus { get; set; }
        public bool IsRevealed { get; set; }
        
        public Square(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Value = " . ";
            MineStatus = MineStatus.False;
            IsRevealed = false;
        }
        
       

    }
}
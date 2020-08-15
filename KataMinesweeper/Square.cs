using System;
using System.Runtime.InteropServices;

namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public MineStatus MineStatus;

        public Square(int xCoordinate, int yCoordinate, MineStatus mineStatus = MineStatus.False)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            MineStatus = mineStatus;
        }

        public override string ToString()
        {
            switch (MineStatus)
            {
                case(MineStatus.False):
                    //todo call method to check neighbours? 
                    // return the method? 
                    return Board.GenerateHints() + " ";
                case(MineStatus.True):
                    return " * ";
                default:
                    return " . ";
            }
        }
    }
}
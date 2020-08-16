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
                case(MineStatus.Hint0):
                    return " 0 ";
                case(MineStatus.Hint1):
                    //todo call method to check neighbours? 
                    // return the method? 
                    return " 1 ";
                case(MineStatus.Hint2):
                    return " 2 ";
                case(MineStatus.Hint3):
                    return " 3 ";
                case(MineStatus.Hint4):
                    return " 4 ";
                case(MineStatus.Hint5):
                    return " 5 ";
                case(MineStatus.Hint6):
                    return " 6 ";
                case(MineStatus.Hint7):
                    return " 7 ";
                case(MineStatus.Hint8):
                    return " 8 ";
                case(MineStatus.True):
                    return " * ";
                default:
                    return " . ";
            }
        }
    }
}
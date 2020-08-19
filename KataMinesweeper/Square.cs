using System;
using System.Runtime.InteropServices;

namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public SquareStatus SquareStatus;

        public Square(int xCoordinate, int yCoordinate, SquareStatus squareStatus = SquareStatus.False)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            SquareStatus = squareStatus;
        }

        
        //todo this will need to change - call a method that returns a string dependent on hint number perhaps? 
        public override string ToString()
        {
            switch (SquareStatus)
            {
                case(SquareStatus.Hint0):
                    return " 0 ";
                case(SquareStatus.Hint1):
                    return " 1 ";
                case(SquareStatus.Hint2):
                    return " 2 ";
                case(SquareStatus.Hint3):
                    return " 3 ";
                // case(SquareStatus.Hint4):
                //     return " 4 ";
                // case(SquareStatus.Hint5):
                //     return " 5 ";
                // case(SquareStatus.Hint6):
                //     return " 6 ";
                // case(SquareStatus.Hint7):
                //     return " 7 ";
                // case(SquareStatus.Hint8):
                //     return " 8 ";
                case(SquareStatus.True):
                    return " * ";
                default:
                    return " . ";
            }
            
        }

        
    }
}
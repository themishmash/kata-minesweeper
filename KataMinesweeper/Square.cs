using System;
using System.Runtime.InteropServices;

namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        
        public string Value { get; set; }
        
        //dictionary

        public MineStatus MineStatus { get; set; }

        public Square(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Value = ".";
            //dictionary - key: square value: mine/hint//property of square but instantiated 
            
            MineStatus = MineStatus.False;
        }
        
       

    }
}
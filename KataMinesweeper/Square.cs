namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public int Hint { get; set; } 
        public bool IsMine { get; set; } 
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        
        public Square(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Hint = 0;
            IsMine = false; 
            IsRevealed = false;
            IsFlagged = false;
        }
    }
}
namespace KataMinesweeper
{
    public class Square
    {
        public int XCoordinate => Coordinate.X;
        public int YCoordinate => Coordinate.Y;
        public int Hint { get; set; }
        public bool IsMine { get; set; } 
        public bool IsRevealed { get; set; }  //immutable
        private Coordinate Coordinate { get; }
        
        public Square(Coordinate coordinate)
        {
            Coordinate = coordinate;
            Hint = 0;
            IsMine = false; 
            IsRevealed = false;
        }
        
        //only tink nknow about x and y - is player and when coordinate created 
    }
}
namespace KataMinesweeper
{
    public class Square
    {
        public bool IsMine { get; set; } 
        public bool IsRevealed { get; set; }  
        public Coordinate Coordinate { get; }
        
        public Square(Coordinate coordinate)
        {
            Coordinate = coordinate;
            IsMine = false; 
            IsRevealed = false;
        }
        
        //only think know about x and y - is player and when coordinate created 
    }
}
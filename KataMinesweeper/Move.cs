namespace KataMinesweeper
{
    public class Move
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        
        public string Value { get; set; }
        
        public Move(int xCoordinate, int yCoordinate) 
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            
        }
        
        
        
        

        
    }
}
namespace KataMinesweeper
{
    public class Minesweeper
    {
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;
        private readonly HintCalculator _hintCalculator;
       // private readonly MineGenerator _mineGenerator;

        public GameStatus GameStatus { get; set; }
        
        public Minesweeper(Board board, Player player, IInputOutput iio)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
          //  _mineGenerator = new MineGenerator(board);
           
            GameStatus = GameStatus.Playing;
            GenerateMines();
        }

        private void GenerateMines()
        {
            //todo generating random ones - need to do a check. if minestatus is false - then set to true. new mine only created with those that are false. later create Mine placing class. 
            for (var i = 0; i < _board.Size; i++)
            {
                var mine = new Square(i, 0);
                var coordinate = new Coordinate(mine.XCoordinate, mine.YCoordinate);
                var square = _board.GetSquare(coordinate);
                square.IsMine = true;
            }
        }

        public void PlayGame()
        {
           // _mineGenerator.PlaceMinesToBoard();
            while (true)
            {
                var coordinate = _player.PlayTurn();
                var square = _board.GetSquare(coordinate);
                if (!square.IsMine)
                {
                    square.Hint = _hintCalculator.Calculate(coordinate); 
                    square.IsRevealed = true;
                }
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    return;
                }

                if (!HasPlayerWon()) continue;
                GameStatus = GameStatus.Won;
                return;
            }
        }

        private bool HasPlayerWon()
        {
            return _board.AreAllHintsRevealed();
        }
        
        // public void PlaceMinesToBoard()
        // {
        //     foreach (var mine in GenerateMines())
        //     {
        //         _board.GetSquare(mine.XCoordinate, mine.YCoordinate).IsMine = true;
        //     }
        // }
        
    }
}
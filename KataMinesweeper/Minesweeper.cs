namespace KataMinesweeper
{
    public class Minesweeper
    {
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;
        private readonly HintCalculator _hintCalculator;

        public GameStatus GameStatus { get; set; }
        

        public Minesweeper(Board board, Player player, IInputOutput iio)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
            GameStatus = GameStatus.Playing;
            GenerateMines();
        }

        private void GenerateMines()
        {
            //todo generating random ones - need to do a check. if minestatus is false - then set to true. new mine only created with those that are false. later create Mine placing class. 
            for (var i = 0; i < _board.Size; i++)
            {
                var mine = new Square(i, 0);
                var square = _board.GetSquare(mine.XCoordinate, mine.YCoordinate);
                square.IsMine = true;
            }
        }

        

        public void PlayGame()
        {
            
            while (true)
            {
                var coordinate = _player.PlayTurn();
                var square = _board.GetSquare(coordinate.XCoordinate, coordinate.YCoordinate);
                if (!square.IsMine)
                {
                    _hintCalculator.GetHintFromPlayerMove(coordinate);
                    square.IsRevealed = true;
                }
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    return;
                }

                if (HasPlayerWon())
                {
                    GameStatus = GameStatus.Won;
                    return;
                }
            }
        }

        private bool HasPlayerWon()
        {
            return _board.AreAllHintsRevealed();
        }
    }
}
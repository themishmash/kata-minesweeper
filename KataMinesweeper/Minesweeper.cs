using System;

namespace KataMinesweeper
{
    public class Minesweeper
    {
        public GameStatus GameStatus { get; private set; }
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;
        private readonly HintCalculator _hintCalculator;
        private readonly IMineGenerator _iMineGenerator;
        private int _hintRevealedCount;
        
        public Minesweeper(Board board, Player player, IInputOutput iio, IMineGenerator iMineGenerator)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
            _iMineGenerator = iMineGenerator;
            GameStatus = GameStatus.AwaitingFirstMove;
        }

        public void PlayGame()
        {
            _iio.Output($"Please enter coordinates in the format x,y. Note valid coordinates are between 0 and {_board.Size-1}.");
            _iio.Output(DisplayBlankBoard());
           while (true)
           {
               var coordinate = _player.PlayTurn();
              
                if (_board.NoSquareRevealed())
                {
                    _iMineGenerator.SetFirstMove(coordinate);
                    _iMineGenerator.PlaceMinesToBoard(_board); 
                }
               
                //for testing purposes
               //_iio.Output(RevealAllMinesAndHints());
                while (!MoveValidator.IsValidMove(coordinate, _board))
                {
                    _iio.Output($"Please enter a valid move.");
                    coordinate = _player.PlayTurn();
                }
                
                var square = _board.GetSquare(coordinate);
                if (!square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Playing;
                    _iio.Output("Current play:"); 
                    _iio.Output(DisplayBoard(false));
                }

                if (HasPlayerWon(coordinate))
                {
                    GameStatus = GameStatus.Won;
                    _iio.Output("Congratulations! You win :)");
                    return;
                }
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    _iio.Output("You stepped on a mine! You lose :(");
                    _iio.Output(DisplayBoard(true));
                    return;
                }
           }
        }
        
        private string DisplayBlankBoard()
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    board += " . ";
                }
                board += Environment.NewLine;
            }
            return board;
        }
        
       public string DisplayBoard(bool revealAll)  
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var square = _board.GetSquare(new Coordinate(i,j));
                    
                    var coordinate = new Coordinate(i, j);
                    
                    var hint = _hintCalculator.Calculate(coordinate);
       
                    if (revealAll)
                        board = DisplayHintAndMines(square, board, hint);
       
                    if (!revealAll)
                        board = DisplayHint(square, board, hint);
                }
                board += Environment.NewLine;
            }
            return board;
        }

       private static string DisplayHint(Square square, string board, int hint)
        {
            if (!square.IsRevealed)
            {
                board += " . ";
            }
            if (square.IsRevealed && !square.IsMine)
            {
                board += " " + hint + " ";
            }
            return board;
        }

        private static string DisplayHintAndMines(Square square, string board, int hint)
        {
            if (square.IsMine)
            {
                board += " * ";
                return board;
            }
            board += " " + hint + " ";
            return board;
        }

        private bool HasPlayerWon(Coordinate coordinate)
        {
            return AreAllHintsRevealed(coordinate);
        }

        private bool AreAllHintsRevealed(Coordinate coordinate)
        {
            if (!_board.GetSquare(coordinate).IsMine && _board.GetSquare(coordinate).IsRevealed)
            {
                _hintRevealedCount++;
            }
            return _hintRevealedCount == _board.Size*_board.Size-_board.GetNumberOfMines(); 
        }
        
        //using this for testing purposes
        //take boolean in - if true keeps unrevealed squares hidden
        //each square knows if revealed or not
        public string RevealAllMinesAndHints()  
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var square = _board.GetSquare(new Coordinate(i,j));
                    
                    var coordinate = new Coordinate(i, j);
                    var hint = _hintCalculator.Calculate(coordinate);
                    
                    if (square.IsMine)
                        board += " * ";
                    
                    if(!square.IsMine)
                        board += " " + hint + " ";
                }
                board += Environment.NewLine;
            }
            return board;
        }
        
        
    }
}
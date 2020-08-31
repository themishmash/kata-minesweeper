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
               //for testing purposes
               //_iio.Output(RevealAllMinesAndHints());
               
                var coordinate = _player.PlayTurn();
                if (_board.NoSquareRevealed())
                {
                    _iMineGenerator.PlaceMinesToBoard(coordinate); 
                }
               
                //for testing purposes
               _iio.Output(RevealAllMinesAndHints());
                while (!MoveValidator.IsValidMove(coordinate, _board))
                {
                    _iio.Output($"Please enter a valid move.");
                    coordinate = _player.PlayTurn();
                }
                
                var square = _board.GetSquare(coordinate);
                if (!square.IsMine)
                {
                    square.IsRevealed = true;
                    square.Hint = _hintCalculator.Calculate(coordinate); //don't need this
                    GameStatus = GameStatus.Playing;
                    _iio.Output("Here's the current board:");
                    _iio.Output(DisplayBoard(coordinate)); 
                }
                //else if for the messages. one of display board. 
                //don't need multiple returns or continues;
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    _iio.Output("You stepped on a mine! You lose :(");
                    _iio.Output(DisplayBoard(coordinate)); 
                    return;
                }

                if (!HasPlayerWon(coordinate)) continue; //get rid of continue
                GameStatus = GameStatus.Won; //last thing
                _iio.Output("Congratulations! You win :)");
                _iio.Output(DisplayBoard(coordinate)); 
                return;
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

        private string DisplayBoard(Coordinate playerCoordinate)
        {
            var board = "";
            for (var i = 0; i < _board.Size; i++)
            {
                for (var j = 0; j < _board.Size; j++)
                {
                    var coordinate = new Coordinate(i, j);
                    var square = _board.GetSquare(coordinate);
                    var hint = _hintCalculator.Calculate(coordinate);
                    var playerSquare = _board.GetSquare(playerCoordinate);
                    
                    board = !playerSquare.IsMine ? DisplayHint(square, board, playerSquare) : DisplayHintAndMines(square, board, hint);
                    if (_board.NoSquareRevealed())
                    {
                        board += " . ";
                    }
                }
                board += Environment.NewLine;
            }
            return board;
        }
        
        private static string DisplayHint(Square square, string board, Square playerSquare)
        {
            if (square.IsRevealed == false)
            {
                board += " . ";
            }
            if (square.IsRevealed && !square.IsMine && playerSquare.IsRevealed && !playerSquare.IsMine)
            {
                board += " " + square.Hint + " ";
            }
            return board;
        }

        private static string DisplayHintAndMines(Square square, string board, int hint)
        {
            if (square.IsMine)
                board += " * ";
            if (!square.IsMine)
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
            return _hintRevealedCount == _board.Size*_board.Size-_board.GetNumberOfMines(); //_board.getminesnumber 
        }
        
        //using this for testing purposes
        private string RevealAllMinesAndHints()  
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
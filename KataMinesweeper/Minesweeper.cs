using System;

namespace KataMinesweeper
{
    public class Minesweeper
    {
        
        private readonly Board _board;
        private readonly Player _player;
        private readonly IInputOutput _iio;
        private readonly HintCalculator _hintCalculator;
       
        private static int _count = 0;

        private readonly IMineGenerator _iMineGenerator;

        public GameStatus GameStatus { get; private set; }
        
        public Minesweeper(Board board, Player player, IInputOutput iio, IMineGenerator iMineGenerator)
        {
            _board = board;
            _player = player;
            _iio = iio;
            _hintCalculator = new HintCalculator(board);
            _iMineGenerator = iMineGenerator;
           //_mineGenerator = new MineGenerator(board);
           GameStatus = GameStatus.Playing;

          // InitGame();
        }

        // void InitGame()
        // {
        //     generateMines();
        //     calculateHints();
        // }

        public void PlayGame()
        {
            _iMineGenerator.PlaceMinesToBoard();
           _iio.Output(RevealAllMinesAndHints());
           _iio.Output(DisplayBlankBoard());
           while (true)
            {
                var coordinate = _player.PlayTurn();
                while (!MoveValidator.IsValidMove(coordinate, _board))
                {
                    _iio.Output("Please enter a valid move.");
                    coordinate = _player.PlayTurn();
                }
                
                var square = _board.GetSquare(coordinate);
                if (!square.IsMine)
                {
                    square.IsRevealed = true;
                    square.Hint = _hintCalculator.Calculate(coordinate);
                    GameStatus = GameStatus.Playing;
                    _iio.Output(DisplayBoard(coordinate)); //this should be display board
                }
                if (square.IsMine)
                {
                    square.IsRevealed = true;
                    GameStatus = GameStatus.Lost;
                    _iio.Output(DisplayBoard(coordinate)); //this shoudl be display board
                    return;
                }

                if (!HasPlayerWon(coordinate)) continue;
                GameStatus = GameStatus.Won;
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

        //maybe combine these two methods - take in boolean should reveal part board or whole board. 
        
        //this should change to DisplayBoard name.
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
        
        //Ismineselected - it will display all or display single
        
        //playercoordinate only need to be called in extracted method
        
        //to display blank board - check if all square.unrevealed
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
                    if (!playerSquare.IsMine)
                    {
                        if (square.IsRevealed == false)
                        {
                            board += " . ";
                        }
                        if (square.IsRevealed && !square.IsMine && playerSquare.IsRevealed && !playerSquare.IsMine)
                        {
                            board += " " + square.Hint + " ";
                        }
                    }
                    

                    if (playerSquare.IsMine)
                    {
                        if (square.IsMine)
                            board += " * ";
                    
                        if(!square.IsMine)
                            board += " " + hint + " ";
                    }
                }
                board += Environment.NewLine;
            }
            return board;
        }

        // private string RevealHintForPlayerMove(Coordinate coordinate)
        // {
        //     var board = "";
        //     for (var i = 0; i < _board.Size; i++)
        //     {
        //         for (var j = 0; j < _board.Size; j++)
        //         {
        //             var square = _board.GetSquare(new Coordinate(i,j));
        //             
        //             //if square.ismine == then show
        //             //if square not mine - show
        //            
        //                board = DisplayHints(square, board); //todo THIS WORKS NEED TO NOW EXTRACT DISPLAY. DO BOOLEAN
        //            
        //            
        //            // var playerSquare = _board.GetSquare(playerCoordinate);
        //             
        //         }
        //         board += Environment.NewLine;
        //     }
        //     return board;
        // }
        //
        // private static string DisplayHints(Square square, string board)
        // {
        //     if (square.IsRevealed == false)
        //     {
        //         board += " . ";
        //     }
        //
        //     if (square.IsRevealed && !square.IsMine)
        //     {
        //         board += " " + square.Hint + " ";
        //     }
        //
        //     return board;
        // }

        private bool IsMineSelected(Square square)
        {
            return square.IsMine;
        }

        private bool HasPlayerWon(Coordinate coordinate)
        {
            return AreAllHintsRevealed(coordinate);
        }

        private bool AreAllHintsRevealed(Coordinate coordinate)
        {
            if (!_board.GetSquare(coordinate).IsMine && _board.GetSquare(coordinate).IsRevealed)
            {
                _count++;
            }
            return _count == _board.Size*_board.Size-_board.Size;
        }
        
        // private string DisplayBlankBoard()
        // {
        //     var board = "";
        //     for (var i = 0; i < _board.Size; i++)
        //     {
        //         for (var j = 0; j < _board.Size; j++)
        //         {
        //             board += " . ";
        //         }
        //         board += Environment.NewLine;
        //     }
        //     return board;
        // }
        //
        // //maybe combine these two methods - take in boolean should reveal part board or whole board. 
        //
        // //this should change to DisplayBoard name.
        // private string RevealAllMinesAndHints()  
        // {
        //     var board = "";
        //     for (var i = 0; i < _board.Size; i++)
        //     {
        //         for (var j = 0; j < _board.Size; j++)
        //         {
        //     
        //             var square = _board.GetSquare(new Coordinate(i,j));
        //             
        //             var coordinate = new Coordinate(i, j);
        //             var hint = _hintCalculator.Calculate(coordinate);
        //             
        //             if (square.IsMine)
        //                 board += " * ";
        //             
        //             if(!square.IsMine)
        //                 board += " " + hint + " ";
        //         }
        //         board += Environment.NewLine;
        //     }
        //     return board;
        // }
        //
        // //Ismineselected - it will display all or display single
        //
        // //playercoordinate only need to be called in extracted method
        //
        // //to display blank board - check if all square.unrevealed
        //
        // private string RevealHintForPlayerMove(Coordinate playerCoordinate)
        // {
        //     var board = "";
        //     for (var i = 0; i < _board.Size; i++)
        //     {
        //         for (var j = 0; j < _board.Size; j++)
        //         {
        //             var square = _board.GetSquare(new Coordinate(i,j));
        //             
        //             var playerSquare = _board.GetSquare(playerCoordinate);
        //             if (square.IsRevealed == false)
        //             {
        //                 board += " . ";
        //             }
        //             if (square.IsRevealed && !square.IsMine && playerSquare.IsRevealed && !playerSquare.IsMine)
        //             {
        //                 board += " " + square.Hint + " ";
        //             }
        //         }
        //         board += Environment.NewLine;
        //     }
        //     return board;
        // }
        
    }
}
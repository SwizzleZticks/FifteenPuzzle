
using FifteenPuzzleGame.Interfaces;

namespace FifteenPuzzleGame
{
    public class Player : IPlayerMovement
    {
        private int _x;
        private int _y;
        private int _moveCount;
        private GameBoard _gameBoard;
        private ConsoleKeyInfo _keyPress;

        public int X 
        {
            get { return _x; } 
            set { _x = value; }
        }
        public int Y 
        {
            get { return _y; } 
            set { _y = value; }
        }

        public int MoveCount
        {
            get { return _moveCount; }
        }

        public Player(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _x = GetAxisLocation("x");
            _y = GetAxisLocation("y");
            _moveCount = 0;
        }

        private int GetAxisLocation(string axis)
        {
            int axisLocation = -1;

            for (int i = 0; i < _gameBoard.BoardSize; i++)
            {
                for (int j = 0; j < _gameBoard.BoardSize; j++)
                {
                    if (_gameBoard.Board[i, j] == 0)
                    {
                        if (axis == "x")
                        {
                            axisLocation = i;
                        }
                        else if (axis == "y")
                        {
                            axisLocation = j;
                        }
                    }
                }
            }
            return axisLocation;
        }

        public void Move()
        {
            _keyPress = Console.ReadKey();

            switch (_keyPress.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        MoveUp();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        MoveDown();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        MoveLeft();
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        MoveRight();
                        break;
                    }
            }
        }

        public void MoveUp()
        {
            if(_x != 0)
            {
                SwapTiles(_x, _y, _x - 1, _y);
                _x--;
            }
        }

        public void MoveDown()
        {
            if (_x != _gameBoard.BoardSize - 1)
            {
                SwapTiles(_x, _y, _x + 1, _y);
                _x++;
            }
        }

        public void MoveLeft()
        {
            if (_y != 0)
            {
                SwapTiles(_x, _y, _x, _y - 1);
                _y--;
            }
        }

        public void MoveRight()
        {
            if (_y != _gameBoard.BoardSize - 1)
            {
                SwapTiles(_x, _y, _x, _y + 1);
                _y++;
            }
        }
        private void SwapTiles(int currentX, int currentY, int zeroX, int zeroY)
        {
            int tempValueHolder = _gameBoard.Board[currentX, currentY];
            _gameBoard.Board[currentX, currentY] = _gameBoard.Board[zeroX, zeroY];
            _gameBoard.Board[zeroX, zeroY] = tempValueHolder;
            _moveCount++;
        }
    }
}

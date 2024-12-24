
using FifteenPuzzleGame.Interfaces;

namespace FifteenPuzzleGame
{
    public class Player : IPlayerMovement
    {
        private readonly GameBoard _gameBoard;
        private ConsoleKeyInfo _keyPress;

        public int X { get; set; }
        public int Y { get; set; }
        public int MoveCount { get; set; }

        public Player(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            X = GetAxisLocation("x");
            Y = GetAxisLocation("y");
            MoveCount = 0;
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
            if(X != 0)
            {
                SwapTiles(X, Y, X - 1, Y);
                X--;
            }
        }

        public void MoveDown()
        {
            if (X != _gameBoard.BoardSize - 1)
            {
                SwapTiles(X, Y, X + 1, Y);
                X++;
            }
        }

        public void MoveLeft()
        {
            if (Y != 0)
            {
                SwapTiles(X, Y, X, Y - 1);
                Y--;
            }
        }

        public void MoveRight()
        {
            if (Y != _gameBoard.BoardSize - 1)
            {
                SwapTiles(X, Y, X, Y + 1);
                Y++;
            }
        }
        private void SwapTiles(int currentX, int currentY, int zeroX, int zeroY)
        {
            (_gameBoard.Board[currentX, currentY], _gameBoard.Board[zeroX, zeroY]) = (_gameBoard.Board[zeroX, zeroY], _gameBoard.Board[currentX, currentY]);
            MoveCount++;
        }
    }
}

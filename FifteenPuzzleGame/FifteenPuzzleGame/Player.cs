using System;

namespace FifteenPuzzleGame
{
    public class Player
    {
        private int _x;
        private int _y;
        private int _moveCount;
        private GameBoard _gameBoard;

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

        public Player(int x, int y, GameBoard gameBoard)
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
    }
}

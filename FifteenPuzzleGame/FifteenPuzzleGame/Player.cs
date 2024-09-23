using System;

namespace FifteenPuzzleGame
{
    public class Player
    {
        private int _x;
        private int _y;

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

        public int MoveCount { get; } = 0;

        public Player(int x, int y, int moveCount)
        {
            X = x;
            Y = y;
            MoveCount = moveCount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame
{
    public class GameBoard
    {
        private static List<int> numberPool = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13, 14, 15, 0 };
        //uncouple this list, and make a property for gameboard size
        //then use a forloop to populate the list with numbers based on gameboard size
        private const int DEFAULT_BOARD_SIZE = 3;

        private Random _randomNumber;
        private char[,] _board;
        private int _boardSize;

        public int BoardSize 
        {
            get { return _boardSize; } 
            set 
            {
                if (_boardSize < 3)
                {
                    _boardSize = value;
                }
                else
                {
                    _boardSize = DEFAULT_BOARD_SIZE;
                }
            }
        }
        public char[,] Board 
        {
            get { return _board; }
            set { _board = value; }
        }

        public GameBoard()
        {
            this._randomNumber = new Random();
            _board = new char[_boardSize, _boardSize];
            InitializeValues(_board, _randomNumber);

            /*
             *                      -----Steps to check if board is solvable before setting it-----
             * 1. Need to initialize values of gameboard based on user choice (use board size and do n * n and add the space)
             * 
             * 2. loop through to populate list to use populate and remove method
             * 
             * 3. need to pass the game board into a method that returns bool
             * 
             * 4. then the array will need flattened to check if inversion count is even or odd
             * 
             * 5. locate the row of the empty space to check if its even or odd (note: even or odd is based from bottom row number up)
             * 
             * 6. if not solvable the loop will continue to run and check until a solvable board is created and set
             */
        }


        private static void InitializeValues(char[,] gameBoard, Random rndNum)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameBoard[i,j] = PopulateAndRemove(numberPool, rndNum);
                }
            }
        }
        private static char PopulateAndRemove(List<int> numPool, Random rndNum) //list parameter will go away and use board size
        {
            int accessIndex = rndNum.Next(0,numPool.Count);
            int result = numberPool[accessIndex];
            numberPool.RemoveAt(accessIndex);

            return Convert.ToChar(result);
        }
    }
}

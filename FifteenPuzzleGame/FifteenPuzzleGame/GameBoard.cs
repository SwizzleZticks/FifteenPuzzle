using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame
{
    public class GameBoard
    {
        private const int DEFAULT_BOARD_SIZE = 3;

        private List<int> _numberPool;
        private Random _randomNumber;
        private int[,] _board;
        private int _boardSize;

        public int BoardSize 
        {
            get { return _boardSize; } 
            set 
            {
                if (value >= 3)
                {
                    _boardSize = value;
                }
                else
                {
                    _boardSize = value >= 3 ? value : DEFAULT_BOARD_SIZE;
                }
            }
        }
        public int[,] Board 
        {
            get { return _board; }
            set { _board = value; }
        }

        public GameBoard()
        {
            _randomNumber = new Random();
            _numberPool = new List<int>();
            BoardSize = DEFAULT_BOARD_SIZE;
            PopulateRandomNumberPool();
            do
            {
                _board = new int[_boardSize, _boardSize];
            } while (!IsSolvableBoard(_numberPool, _board, _randomNumber));
        }

        private bool IsSolvableBoard(List<int> numberPool, int[,] gameBoard, Random rndNum)
        {
            // Initialize the game board with random values
            InitializeValues(numberPool,gameBoard, rndNum);
            // Flatten the 2D array for inversion checking
            int[] flatBoard = Flatten2DArray(gameBoard);
            // Check for even number of inversions
            bool isEvenInversion = IsEvenInversionCount(flatBoard);
            // Check the row location of the blank space, counting from the bottom
            bool isEvenFromBottom = CheckRowLocation();

            return CheckSolvability(isEvenInversion, isEvenFromBottom);
        }

        private bool CheckSolvability(bool isEvenInversion, bool isEvenFromBottom)
        {
            if (_boardSize % 2 != 0)
            {
                return isEvenInversion; //if board size is odd, then if it will be solvable if inversions are even
            }
            else
            {
                return (isEvenFromBottom && !isEvenInversion) || (!isEvenFromBottom && isEvenInversion);
            }
        }
        private int FindBlankSpace()
        {
            for (int i = _boardSize - 1; i >= 0; i--)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (_board[i, j] == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private bool CheckRowLocation()
        {
            int xLocation = FindBlankSpace();
            return xLocation % 2 == 0; //true if even from bottom, false if odd from bottom
        }
        private bool IsEvenInversionCount(int[] flatArr)
        {
            int inversionCount = 0;

            for (int i = 0; i < _boardSize * _boardSize - 1; i++)
            {
                for (int j = i + 1; j < _boardSize * _boardSize; j++)
                {
                    if ((flatArr[j] != 0 && flatArr[i] != 0) && (flatArr[i] > flatArr[j]))
                    {
                        inversionCount++;
                    }
                }
            }
            return inversionCount % 2 == 0;
        }
        private int[] Flatten2DArray(int[,] board)
        {
            int totalLength = board.Length;

            int[] flatArr = new int[totalLength];
            int index = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    flatArr[index++] = board[i, j];
                }
            }

            return flatArr;
        }

        private void InitializeValues(List<int> numberPool,int[,] gameBoard, Random rndNum)
        {

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i,j] = PopulateAndRemove(numberPool, rndNum);
                }
            }
        }
        private int PopulateAndRemove(List<int> numberPool, Random rndNum)
        {
            int accessIndex = rndNum.Next(0,numberPool.Count);
            int result = numberPool[accessIndex];
            numberPool.RemoveAt(accessIndex);

            return result;
        }
        private void PopulateRandomNumberPool()
        {
            for(int i = 0; i < _boardSize * _boardSize; i++)
            {
                _numberPool.Add(i);
            }
        }
    }
}

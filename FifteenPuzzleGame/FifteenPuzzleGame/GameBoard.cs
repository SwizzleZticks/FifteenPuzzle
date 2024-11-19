
namespace FifteenPuzzleGame
{
    public class GameBoard
    {
        /*                      -----Rules for solvable puzzle-----
         * 1.If N is odd, then puzzle instance is solvable if number of inversions is even in the input state.
         * 
         * 2.  If N is even, puzzle instance is solvable if 
         *     -the blank is on an even row counting from the bottom (second-last, fourth-last, etc.) 
         *      and number of inversions is odd.
         *   
         *     -the blank is on an odd row counting from the bottom (last, third-last, fifth-last, etc.) 
         *      and number of inversions is even.
         * 
         * 3. For all other cases, the puzzle instance is not solvable.
         */

        private const int DEFAULT_BOARD_SIZE = 3;

        private List<int> _numberPool;
        private Random _randomNumber;
        private int[,] _board;
        private int _boardSize;

        public int BoardSize 
        {
            get { return _boardSize; } 
            set { _boardSize = value >= 3 ? value : DEFAULT_BOARD_SIZE; }
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
            _boardSize = DEFAULT_BOARD_SIZE;          
            do
            {
                PopulateRandomNumberPool(); //this is required since PopulateAndRemove empties the list
                _board = new int[_boardSize, _boardSize];
            } while (!IsSolvableBoard());
        }

        private bool IsSolvableBoard()
        {
            InitializeValues();
            int[] flatBoard = Flatten2DArray(_board);
            bool isEvenInversion = IsEvenInversionCount(flatBoard);
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

        private void InitializeValues()
        {

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i,j] = PopulateAndRemove();
                }
            }
        }
        private int PopulateAndRemove()
        {
            int accessIndex = _randomNumber.Next(0,_numberPool.Count);
            int result = _numberPool[accessIndex];
            _numberPool.RemoveAt(accessIndex);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame
{
    public class GameBoard
    {
        private static Random randNum = new Random();
        private static List<int> numberPool = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13, 14, 15, 0 };

        private int[,] _gameBoard;

        public GameBoard()
        {
            _gameBoard = new int[4, 4]; //todo: need to uncouple this for gameboard sizes by user choice
            InitializeValues(_gameBoard);
        }

        private static void InitializeValues(int[,] board)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i,j] = PopulateAndRemove(numberPool);
                }
            }
        }
        private static int PopulateAndRemove(List<int> numPool)
        {
            int accessIndex = randNum.Next(0,numPool.Count);
            int result = numberPool[accessIndex];
            numberPool.RemoveAt(accessIndex);

            return result;
        }
    }
}

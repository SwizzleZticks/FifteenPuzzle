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
        //uncouple this list, and make a property for gameboard size
        //then use a forloop to populate the list with numbers based on gameboard size
        private int[,] _board;
        public int[,] Board 
        {
            get { return _board; }
            set { _board = value; }
        }

        public GameBoard()
        {
            _board = new int[4, 4]; //todo: need to uncouple this for gameboard sizes by user choice
            InitializeValues(_board);
        }

        private static void InitializeValues(int[,] gameBoard)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameBoard[i,j] = PopulateAndRemove(numberPool);
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

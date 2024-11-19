using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame
{
    public class BoardRenderer
    {
        public void RenderBoard(GameBoard board)
        {
            Console.WriteLine(PrintColumns(board));
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Console.Write("| {0,2} ", board.Board[i,j]);
                }
                Console.WriteLine("|");
                Console.WriteLine(PrintColumns(board));
            }
        }

        private string PrintColumns(GameBoard board)
        {
            string gridPattern = "+";

            for (int i = 0; i < board.BoardSize; i++)
            {
                gridPattern += "----+";
            }
            return gridPattern;
        }
    }
}

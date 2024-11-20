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
            PrintBoardHeader(board.BoardSize);
            Console.WriteLine(PrintColumns(board));
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (board.Board[i, j] == 0)
                    {
                        Console.Write("| ");
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write("| {0,2} ", board.Board[i, j].ToString("D2"));
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine(PrintColumns(board));
            }
            ConsoleHelper.WriteLineCentered("Movement Instructions:");
            ConsoleHelper.WriteLineCentered("Up, Right, Down, Left keys.");
        }

        private void PrintBoardHeader(int boardSize)
        {
            if(boardSize == 3)
            {
                ConsoleHelper.WriteLineCentered("****************");
                ConsoleHelper.WriteLineCentered("*  [8-Puzzle]  *");
                ConsoleHelper.WriteLineCentered("****************");
            }

            else if (boardSize == 4)
            {
                ConsoleHelper.WriteLineCentered("*********************");
                ConsoleHelper.WriteLineCentered("*    [15-Puzzle]    *");
                ConsoleHelper.WriteLineCentered("*********************");               
            }

            else if(boardSize == 5)
            {
                ConsoleHelper.WriteLineCentered("**************************");
                ConsoleHelper.WriteLineCentered("*       [24-Puzzle]      *");
                ConsoleHelper.WriteLineCentered("**************************");
            }

            else if (boardSize == 6)
            {
                ConsoleHelper.WriteLineCentered("*******************************");
                ConsoleHelper.WriteLineCentered("*         [35-Puzzle]         *");
                ConsoleHelper.WriteLineCentered("*******************************");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame
{
    public class BoardRenderer
    {
        public void RenderBoard(GameBoard board, Player player)
        {
            //steps
            //get console width
            //figure each cell width
            //multiply the board size(number of cells per row) by each cell width, then add 1 for the border
            //^^^ THIS TELLS US THE WIDTH OF THE BOARD ^^^^
            //then subract console from our board width and divide by 2, this finds out padding left
            //which then allows us to find the starting position of the cursor to start printing to console
            //instead of printing straight to console, create an empty string, and append
            //after we are done appending to the string, we can use our padding of empty spaces
            //then we finally append our string build after the padded spaces to print that row
            //then repeat this process based on the condition in the for loop

            //***NOTE***
            //we need to have a conditional since odd rows print differently than even
            //this will just add a space to realign it if it is an even board size

            int consoleWidth = Console.WindowWidth;
            int cellWidth = 5;
            int boardWidth = (board.BoardSize * cellWidth) + 1;
            int padding = (consoleWidth - boardWidth) / 2;

            PrintBoardHeader(board.BoardSize);
            ConsoleHelper.WriteLineCentered($"Move Count: {player.MoveCount}");
            PrintColumns(board);

            for (int i = 0; i < board.BoardSize; i++)
            {
                string row = "";
                if (board.BoardSize % 2 == 0)
                {
                    row += " ";
                }

                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (board.Board[i, j] == 0)
                    {
                        row += "|    ";
                    }
                    else
                    {
                        row += string.Format("|{0,3} ", board.Board[i, j].ToString("D2"));
                    }
                }
                row += "|";
                Console.WriteLine(new string(' ', padding) + row);
                PrintColumns(board);
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

        private void PrintColumns(GameBoard board)
        {
            string gridPattern = "+";

            for (int i = 0; i < board.BoardSize; i++)
            {
                gridPattern += "----+";
            }
            ConsoleHelper.WriteLineCentered(gridPattern);
        }
    }
}

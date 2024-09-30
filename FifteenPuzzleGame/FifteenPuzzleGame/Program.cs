namespace FifteenPuzzleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //N * N - 1 (N is your grid width, and minus 1 to account for the blank space)
            //If N is odd and has an even number of inversions it is solvable
            //If N is even puzzle is solvable if
            //  1. The blank is on an even row, counting from bottom. So 1st row and 3rd row from top i = 1 or 3 & inversion is odd
            //  2. The blank is on an odd row, counting from bottom. So 2nd and 4th row from top i = 2 or 4 & inversion is even

            int N = 3;
            int inversionCount = 0;
            bool isSolvable;
            
            int[,] array = new int[,]
            {
                { 1, 8, 2 },
                { 0, 4, 3 },
                { 7, 6, 5 }
            };
            //This converts 2d into 1d array
            int totalLength = array.Length;

            int[] flatArr = new int[totalLength];

            int index = 0;

            for (int i = 0; i < array.GetLength(0); i++) //get length position is [0,1] - gets X length
            {
                for (int j = 0; j < array.GetLength(1); j++) //basically gets Y length
                {
                    flatArr[index++] = array[i, j];
                }
            }
            //end of conversion

            //beginning of inversion count
            for (int i = 0; i < N * N - 1; i++)
            {               
                for (int j = i + 1; j < N * N; j++)
                {
                    //compares i to every single thing in the array, disregarding 0. Note: i + 1 to not compare i to itself
                    if ((flatArr[j] != 0 && flatArr[i] != 0) && (flatArr[i] > flatArr[j]))
                    {
                        inversionCount++;
                    }
                }
            }

            Console.WriteLine(inversionCount);
            //end of inversion count

            //locate the empty space (return type of (int,int))? deconstruct and set in the setter?
            int x = -1;
            int y = -1;

            for (int i = 0; i < N; i++)
            {
                for(int j = 0; i < N; j++)
                {
                    if (array[i,j] == 0)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            //maybe theres a way we can use a loop to call a method so it can read 0 or 1
            //to determine which int(x or y) to return
            //return -1 for x & y if no blank is found

            //end blank location
            //check for even or odd of inversion & check even or odd row !!!COUNTING FROM BOTTOM!!!

            bool isEvenInversion;
            bool isEvenRow;

            if (inversionCount % 2 == 0) //should be able to make this a 1 liner return type
            {
                isEvenInversion = true;
            }
            if (x == 1 || x == 3) //should be able to make this a 1 liner return type
            {
                isEvenRow = true;
            }
            Console.ReadLine();
        }
    }
}

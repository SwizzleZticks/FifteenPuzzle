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

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
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
                    //compares i to every single thing into the array, disregarding 0. Note: j + 1 to not compare i to itself
                    if ((flatArr[j] != 0 && flatArr[j] != 0) && (flatArr[i] > flatArr[j])) 
                    {
                        inversionCount++;
                    }
                }
            }

            Console.WriteLine(inversionCount);
            //end of inversion count

            Console.ReadLine();
        }
    }
}

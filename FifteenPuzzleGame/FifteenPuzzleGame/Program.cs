namespace FifteenPuzzleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            BoardRenderer boardRenderer = new BoardRenderer();

            boardRenderer.RenderBoard(board);

            Console.ReadLine();
        }
    }
}

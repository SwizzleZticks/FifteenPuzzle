namespace FifteenPuzzleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoardRenderer boardRenderer = new BoardRenderer();
            GameMenu menu = new GameMenu();
            GameBoard board = new GameBoard(menu.GetGameSize());
            
            boardRenderer.RenderBoard(board);


            Console.ReadLine();
        }
    }
}

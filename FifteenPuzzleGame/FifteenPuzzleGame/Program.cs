namespace FifteenPuzzleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "15-Puzzle Game";

            do
            {
                Console.Clear();
                Game newGame = new Game();
                newGame.Run();
                Console.ResetColor();
            } while (Game.IsPlayingAgain());
        }
    }
}
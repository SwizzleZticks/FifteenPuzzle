
namespace FifteenPuzzleGame
{
    public class Game
    {
        private GameBoard _board;
        private GameMenu _menu;
        private BoardRenderer _boardRenderer;
        private Player _player;

        public Game()
        {
            _boardRenderer = new BoardRenderer();
            _menu = new GameMenu();
            _board = new GameBoard(_menu.GetGameSize());
            _player = new Player(_board);

        }
        public void Run()
        {
            Console.Title = "15-Puzzle Game";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true)
            {
                Console.Clear();
                _boardRenderer.RenderBoard(_board, _player);
                _player.Move();
            }
        }
    }
}

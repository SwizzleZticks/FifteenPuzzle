namespace FifteenPuzzleGame
{
    public class Game
    {
        private GameBoard _gameBoard;
        private GameMenu _menu;
        private BoardRenderer _gameBoardRenderer;
        private Player _player;

        public Game()
        {
            _gameBoardRenderer = new BoardRenderer();
            _menu = new GameMenu();
            _gameBoard = new GameBoard(_menu.GetGameSize());
            _player = new Player(_gameBoard);
        }
        public void Run()
        {
            Console.Title = "15-Puzzle Game";
            Console.ForegroundColor = ConsoleColor.Blue;

            while (!IsCompletedPuzzle())
            {
                Console.Clear();
                _gameBoardRenderer.RenderBoard(_gameBoard, _player);
                _player.Move();
            }
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Green;
            _gameBoardRenderer.RenderBoard(_gameBoard, _player);
            PrintComplete();
        }
        public static bool IsPlayingAgain()
        {
            bool isActiveLoop = true;
            bool isPlaying = false;

            do
            {
                ConsoleHelper.WriteLineCentered("Would you like to continue playing (Y/N)?");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    isPlaying = true;
                    isActiveLoop = false;
                }
                else if (userInput == "N")
                {
                    isPlaying = false;
                    isActiveLoop = false;
                }
            } while (isActiveLoop);

            return isPlaying;
        }
        private void PrintComplete()
        {
            ConsoleHelper.WriteLineCentered("*****************", ConsoleColor.Green);
            ConsoleHelper.WriteLineCentered("*  [COMPLETE!]  *", ConsoleColor.Green);
            ConsoleHelper.WriteLineCentered("*****************", ConsoleColor.Green);

            ConsoleHelper.WriteLineCentered("Press enter to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }

        private bool IsCompletedPuzzle()
        {
            int count = 1;

            for (int i = 0; i < _gameBoard.Board.GetLength(0); i++)
            {
                for (int j = 0; j < _gameBoard.Board.GetLength(1); j++)
                {
                    if (i == _gameBoard.Board.GetLength(0) - 1 && j == _gameBoard.Board.GetLength(1) - 1)
                    {
                        if (_gameBoard.Board[i, j] != 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_gameBoard.Board[i, j] != count)
                        {
                            return false;
                        }
                        count++;
                    }
                }
            }
            return true;
        }
    }
}
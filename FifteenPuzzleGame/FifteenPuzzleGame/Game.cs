namespace FifteenPuzzleGame
{
    public class Game
    {
        private GameBoard _gameBoard;
        private readonly GameMenu _menu;
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
        private static void PrintComplete()
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
                    if (i == _gameBoard.Board.GetLength(0) - 1 && j == _gameBoard.Board.GetLength(1) - 1) //This checks last cell case for the player at the end of the board
                    {
                        if (_gameBoard.Board[i, j] != 0) // if last cell doesnt equal 0 its false
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_gameBoard.Board[i, j] != count) //this compares to the count checking each postion in the array for incremental match
                        {
                            return false;
                        }
                        count++;
                    }
                }
            }
            return true; // if the check makes it through every increment and the last spot is a 0(player positon) all checks passed and the board is solved
        }
    }
}
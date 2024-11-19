
namespace FifteenPuzzleGame
{
    public class Game
    {
        private GameBoard _board;
        private Player _player;

        public GameBoard Board 
        { 
            get {  return _board; }
            set { _board = value; }
        }
        public Player Player
        { 
            get { return _player; } 
            set { Player = value; }
        }

        public Game(GameBoard board, Player player)
        {
            _board = board;
            _player = player;
        }
    }
}

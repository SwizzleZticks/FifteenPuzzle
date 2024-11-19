
using FifteenPuzzleGame.Interfaces;

namespace FifteenPuzzleGame
{
    public class GameMenu : IMenuNavigation
    {
        private ConsoleKeyInfo _keyPress;
        private int _boardSize;

        public int BoardSize 
        { 
            get {  return _boardSize; }
            set { _boardSize = value; }
        }

        public GameMenu(int boardSize)
        {
            _boardSize = boardSize;
        }

        public GameMenu() { }

        public void DisplayMenu()
        {

        }

        public void MoveUp(ConsoleKeyInfo keyPress)
        {
            throw new NotImplementedException();
        }

        public void MoveDown(ConsoleKeyInfo keyPress)
        {
            throw new NotImplementedException();
        }

        public void Select(ConsoleKeyInfo keyPress)
        {
            throw new NotImplementedException();
        }
    }
}

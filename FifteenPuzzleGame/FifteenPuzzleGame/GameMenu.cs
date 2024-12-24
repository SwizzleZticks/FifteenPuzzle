
using FifteenPuzzleGame.Interfaces;

namespace FifteenPuzzleGame
{
    public class GameMenu
    {
        private ConsoleKeyInfo _keyPress;
        private readonly string[] _menuOptions = ["->  [8-Puzzle] - (Mini)", " [15-Puzzle] - (Classic)", " [24-Puzzle] - (Expanded)"," [35-Puzzle] - (Advanced)"];

        public int GetGameSize()
        {
            int index;
            int boardSize;

            do
            {
                DisplayMenu();
                _keyPress = Console.ReadKey();
                index = GetUserSelection();

                boardSize = index switch
                {
                    0 => 3,
                    1 => 4,
                    2 => 5,
                    3 => 6,
                    _ => 3
                };
               
                Console.Clear();
            } while (_keyPress.Key != ConsoleKey.Enter);

            return boardSize;
        }

        private int GetUserSelection()
        {
            int index = -1;
            
            if (_keyPress.Key is ConsoleKey.UpArrow or ConsoleKey.DownArrow)
            {
                Move();
            }

            else if (_keyPress.Key == ConsoleKey.Enter)
            {
                index = GetSelectIndex();
            }
           
            return index;
        }
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintMenuHeader();
            foreach (var menuOption in _menuOptions)
            {
                ConsoleHelper.WriteLineCentered(menuOption + "\n");
            }
        }

        private static void PrintMenuHeader()
        {
            ConsoleHelper.WriteLineCentered("********************");
            ConsoleHelper.WriteLineCentered("*      [MENU]      *");
            ConsoleHelper.WriteLineCentered("********************");
        }

        private int GetSelectIndex()
        {
            return Array.FindIndex(_menuOptions, s => s.Contains('>'));
        }

        private void Move()
        {
            ChangeMenuSelection(_keyPress.Key);
        }
        
        private void ChangeMenuSelection(ConsoleKey keyPress)
        {
            int index = GetSelectIndex();

            if ((index == 0 && keyPress == ConsoleKey.UpArrow) || 
                (index == _menuOptions.Length - 1 && keyPress == ConsoleKey.DownArrow))
            {
                return;
            }
            string alteredIndexText = _menuOptions[index].Remove(0,2);
            _menuOptions[index] = alteredIndexText.TrimStart();

            index = keyPress == ConsoleKey.UpArrow ? index - 1 : index + 1;

            alteredIndexText = _menuOptions[index];
            alteredIndexText = "-> " + alteredIndexText;
            _menuOptions[index] = alteredIndexText;
        }
    }
}

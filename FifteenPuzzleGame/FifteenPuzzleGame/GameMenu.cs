
using FifteenPuzzleGame.Interfaces;

namespace FifteenPuzzleGame
{
    public class GameMenu : IMenuNavigation
    {
        private ConsoleKeyInfo _keyPress;
        private string[] _menuOptions = ["->  [8-Puzzle] - (Mini)", " [15-Puzzle] - (Classic)", " [24-Puzzle] - (Expanded)"," [35-Puzzle] - (Advanced)"];

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

            switch (_keyPress.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        MoveUp();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        MoveDown();
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        index = GetSelectIndex();
                        break;
                    }
            }
            return index;
        }
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintMenuHeader();
            foreach (var menuOption in _menuOptions)
            {
                ConsoleHelper.WriteLineCentered(menuOption + "\n");
            }
        }

        private void PrintMenuHeader()
        {
            ConsoleHelper.WriteLineCentered("********************");
            ConsoleHelper.WriteLineCentered("*      [MENU]      *");
            ConsoleHelper.WriteLineCentered("********************");
        }

        public int GetSelectIndex()
        {
            return Array.FindIndex(_menuOptions, s => s.Contains(">"));
        }

        public void MoveUp()
        {
            int index = GetSelectIndex();

            if(index != 0)
            {
                string alteredIndexText = _menuOptions[index].Remove(0,2);
                _menuOptions[index] = alteredIndexText.TrimStart();

                index--;

                alteredIndexText = _menuOptions[index];
                alteredIndexText = "-> " + alteredIndexText;
                _menuOptions[index] = alteredIndexText;             
            }
        }

        public void MoveDown()
        {
            int index = GetSelectIndex();

            if (index != _menuOptions.Length - 1)
            {
                string alteredIndexText = _menuOptions[index].Remove(0, 2);
                _menuOptions[index] = alteredIndexText.TrimStart();

                index++;

                alteredIndexText = _menuOptions[index];
                alteredIndexText = "-> " + alteredIndexText;
                _menuOptions[index] = alteredIndexText;
            }
        }
    }
}

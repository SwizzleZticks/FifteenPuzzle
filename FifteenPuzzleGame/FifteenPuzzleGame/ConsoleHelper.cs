
namespace FifteenPuzzleGame
{
    public static class ConsoleHelper
    {
        public static void WriteLineCentered(string text)
        {
            int consoleWidth = Console.WindowWidth;

            int textLength = text.Length;
            int startPositionX = (consoleWidth / 2) - (textLength / 2);

            Console.SetCursorPosition(startPositionX, Console.CursorTop);
            Console.WriteLine(text);
        }

        public static void WriteLineCentered(string text, ConsoleColor color)
        {
            int consoleWidth = Console.WindowWidth;

            int textLength = text.Length;
            int startPositionX = (consoleWidth / 2) - (textLength / 2);

            Console.SetCursorPosition(startPositionX, Console.CursorTop);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static void WriteCentered(string text)
        {
            int consoleWidth = Console.WindowWidth;

            int textLength = text.Length;
            int startPositionX = (consoleWidth / 2) - (textLength / 2);

            Console.SetCursorPosition(startPositionX, Console.CursorTop);
            Console.Write(text);
        }
    }
}

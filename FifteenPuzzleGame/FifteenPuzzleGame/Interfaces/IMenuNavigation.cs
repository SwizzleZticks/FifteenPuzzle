using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.Interfaces
{
    public interface IMenuNavigation
    {
        void MoveUp(ConsoleKeyInfo keyPress);
        void MoveDown(ConsoleKeyInfo keyPress);
        void Select(ConsoleKeyInfo keyPress);
    }
}

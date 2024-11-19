using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.Interfaces
{
    public interface IPlayerMovement
    {
        int MoveUp(ConsoleKeyInfo keyPress);
        int MoveDown(ConsoleKeyInfo keyPress);
        int MoveLeft(ConsoleKeyInfo keyPress);
        int MoveRight(ConsoleKeyInfo keyPress);
    }
}

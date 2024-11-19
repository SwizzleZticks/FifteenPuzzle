using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.Interfaces
{
    public interface IMenuNavigation
    {
        void MoveUp();
        void MoveDown();
        int GetSelectIndex();
    }
}

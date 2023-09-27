using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Drop : MovableEntity
    {
        public enum DropType
        {
            weaponUpgrade,
        }
        public DropType Type;
        public Drop(int x, int y, DropType drop)
        {
            XPos = x;
            YPos = y;
            CurrentDirection = Direction.Down;
            Type = drop;
        }
    }
}

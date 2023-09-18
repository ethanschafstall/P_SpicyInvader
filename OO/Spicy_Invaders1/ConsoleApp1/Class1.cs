using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Drop : Sprite
    {
        public enum DropType 
        {
            weaponUpgrade,
        }
        public DropType dropType;
        public Drop(int x, int y, DropType drop) 
        {
            XPos = x;
            YPos = y;
            MoveDirection = 'd';
            dropType = drop; 
        }
    }
}

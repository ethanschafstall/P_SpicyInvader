using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public enum DropType
    {
        weaponUpgrade,
    }
    public class Drop : MovableEntity
    {
        public DropType Type { get; set; }
        public Drop(int x, int y, DropType dropType)
        {
            Position = new Vector(x, y);
            Velocity = new Vector(2, 2);
            CurrentDirection = Direction.Down;
            Type = dropType;
        }
    }
}

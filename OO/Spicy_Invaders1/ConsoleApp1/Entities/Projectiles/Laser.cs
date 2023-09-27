using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Laser : Projectile
    {
        public Laser(int x, int y, Direction direction = Direction.Up)
        {
            XPos = x;
            YPos = y;
            CurrentDirection = direction;
            VerticalMoveSpeed = 3;
            HorizontalMoveSpeed = 3;
            Damage = 25;
        }
        public Laser() { }
    }
}

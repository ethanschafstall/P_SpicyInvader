using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Bullet : Projectile
    {
        public Bullet(int x, int y, Direction direction = Direction.Up)
        {
            XPos = x;
            YPos = y;
            CurrentDirection = direction;
            VerticalMoveSpeed = 2;
            HorizontalMoveSpeed = 2;
            Damage = 35;
        }
        public Bullet() { }
    }
}

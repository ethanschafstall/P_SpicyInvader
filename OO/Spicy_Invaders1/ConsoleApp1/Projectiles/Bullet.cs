using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders.Projectiles
{
    public class Bullet : Projectile
    {
        public Bullet(int x, int y, char direction = 'u')
        {
            XPos = x;
            YPos = y;
            MoveDirection = direction;
            VerticalMoveSpeed = 2;
            HorizontalMoveSpeed = 2;
            Damage = 35;
        }
        public Bullet() { }
    }
}

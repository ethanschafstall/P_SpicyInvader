using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int x, int y, char direction = 'u')
        {
            XPos = x;
            YPos = y;
            MoveDirection = direction;
            VerticalMoveSpeed = 3;
            HorizontalMoveSpeed = 3;
            Damage = 25;
        }
        public Laser() { }
    }
}

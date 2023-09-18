using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders.Projectiles
{
    public class Missile : Projectile
    {
        public Missile(int x, int y, char direction = 'u') 
        {
            XPos = x;
            YPos = y;
            MoveDirection = direction;
            VerticalMoveSpeed = 1;
            HorizontalMoveSpeed = 1;
            Damage = 75;
        }
        public Missile() { }
    }
}

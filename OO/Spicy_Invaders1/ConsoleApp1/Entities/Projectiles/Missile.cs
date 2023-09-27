using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Missile : Projectile
    {
        public Missile(int x, int y, Direction direction = Direction.Up) 
        {
            XPos = x;
            YPos = y;
            CurrentDirection = direction;
            VerticalMoveSpeed = 1;
            HorizontalMoveSpeed = 1;
            Damage = 75;
        }
        public Missile() { }
    }
}

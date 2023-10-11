﻿using System;
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
            Position = new Vector(x, y);
            TravelDirection = direction;
            Velocity = new Vector(2, 2);
            Damage = 35;
        }
        public Bullet() { }
    }
}

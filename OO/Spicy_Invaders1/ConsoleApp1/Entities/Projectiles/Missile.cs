﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Missile : Projectile
    {
        public Missile(int x, int y, SmartEntity origin, Direction direction = Direction.Up) 
        {
            Position = new Vector(x, y);
            Shooter = origin;
            TravelDirection = direction;
            Velocity = new Vector(1, 1);
            Damage = 75;
        }
        public Missile() { }
    }
}
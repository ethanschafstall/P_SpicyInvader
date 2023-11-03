using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Missile projectile class for the rocket launcher weapon. Inherents from Projectile.
    /// </summary>
    public class Missile : Projectile
    {
        public Missile(int x, int y, Direction direction = Direction.Up)
        {
            Position = new Vector(x, y);
            TravelDirection = direction;
            Velocity = new Vector(1, 1);
            Damage = 9;
        }
        public Missile() { }
    }
}

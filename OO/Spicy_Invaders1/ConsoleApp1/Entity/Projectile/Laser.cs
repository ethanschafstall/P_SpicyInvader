using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Laser projectile class for the laser gun weapon. Inherents from Projectile.
    /// </summary>
    public class Laser : Projectile
    {
        public Laser(int x, int y, Direction direction = Direction.Up)
        {
            Position = new Vector(x, y);
            TravelDirection = direction;
            Velocity = new Vector(3, 3);
            Damage = 4;
        }
        public Laser() { }
    }
}

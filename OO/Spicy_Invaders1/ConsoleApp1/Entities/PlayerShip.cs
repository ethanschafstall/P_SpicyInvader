using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class PlayerShip : SmartEntity
    {
        public PlayerShip() 
        {
        }
        public PlayerShip(int x, int y) 
        {
            Position = new Vector(x, y);
            Velocity = new Vector(1, 1);
            weaponType = WeaponType.Gun;
            FaceDirection = Direction.Up;
        }
        public override void Hit(Projectile projectile) 
        { 
            IsAlive = false;
        }
    }
}

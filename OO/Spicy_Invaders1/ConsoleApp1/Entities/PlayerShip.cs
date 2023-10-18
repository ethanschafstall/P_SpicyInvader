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
            this.Position = new Vector(x, y);
            this.Velocity = new Vector(1, 1);
            this.Weapon = WeaponType.Gun;
            this.FaceDirection = Direction.Up;
            this.HealthPoints = 3;
            this.EntityWidth = 2;
        }
        public override void Hit(Projectile projectile) 
        {
            this.ShowHitAnimation = true;
            this.HealthPoints -= 1;
            if (HealthPoints <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}

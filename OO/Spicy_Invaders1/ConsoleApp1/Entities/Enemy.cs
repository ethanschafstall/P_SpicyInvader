using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Enemy : SmartEntity
    {
        public EnemyType enemyType { get; }

        public bool CanFire { get; set; }

        public Enemy(int x, int y, EnemyType type, Direction direction = Direction.Right)
        {
            TravelDirection = direction;
            enemyType = type;
            FaceDirection = Direction.Down;
            Position = new Vector(x, y);
            Velocity = new Vector();
            weaponType = WeaponType.Gun;
        }

        public override void Hit(Projectile projectile) 
        { 
            this.HealthPoints -= projectile.Damage;
            if (HealthPoints <= 0)
            {
                IsAlive = false;
            }
        }

        //public Drop DropUpgrade()
        //{
        //    //return new Drop(1,1);
        //}
    }
}

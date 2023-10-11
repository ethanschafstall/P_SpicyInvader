using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spicy_Invaders
{
    /// <summary>
    /// AnimatedSprite are all objects that are "Alive" (player and enemies).
    /// </summary>
    public class SmartEntity : MovableEntity
    {

        public WeaponType weaponType { get; set; }

        public int HealthPoints { get; set; }

        public Direction FaceDirection { get; set; }

        public int ShootXPos { get; set; }

        public int ShootYPos { get; set; }

        public Vector Hitbox { get; set; }

        public Vector ShootBox { get; set; }

        public int XPos { get; set; }

        public bool IsAlive { get; set; }
        protected SmartEntity()
        {
        }
        public Projectile Shoot()
        {
            ShootXPos = Position.X;
            ShootYPos = Position.Y;

            switch (weaponType)
            {
                case WeaponType.Gun:
                    return new Bullet(ShootXPos, ShootYPos, FaceDirection);
                    break;
                case WeaponType.MissileLauncher:
                    return new Missile(ShootXPos, ShootYPos, FaceDirection);
                    break;
                case WeaponType.LaserGun:
                    return new Laser(ShootXPos, ShootYPos, FaceDirection);
                    break;
                default:
                    throw new NotImplementedException("unknown weapon type");
                    break;
            }
        }

        public virtual void Hit(Projectile projectile) 
        { 

        }
    }
}

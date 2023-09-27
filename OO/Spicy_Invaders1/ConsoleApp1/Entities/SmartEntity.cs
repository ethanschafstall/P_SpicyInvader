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
        public enum WeaponType
        { 
            Gun,
            LaserGun,
            MissileLauncher
        }

        public WeaponType weaponType;

        public int HealthPoints;

        public Direction FaceDirection;

        public int ShootXPos;

        public int ShootYPos;

        public bool IsAlive;
        protected SmartEntity()
        {
        }
        public Projectile Shoot()
        {
            ShootXPos = XPos;
            ShootYPos = YPos;

            switch (weaponType)
            {
                case WeaponType.Gun:
                    return new Bullet(XPos, YPos, FaceDirection);
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
    }
}

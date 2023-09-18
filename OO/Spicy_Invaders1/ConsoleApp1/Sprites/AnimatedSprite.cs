using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spicy_Invaders.Projectiles;

namespace Spicy_Invaders
{
    public class AnimatedSprite : Sprite
    {
        public enum WeaponType
        { 
            Gun,
            LaserGun,
            MissileLauncher
        }

        public WeaponType weaponType;

        public int HealthPoints;

        public char FaceDirection;

        public int ShootXPos;

        public int ShootYPos;

        public bool IsAlive;
        protected AnimatedSprite()
        {
        }

        public Projectile Shoot()
        {
            ShootXPos = XPos;
            ShootYPos = YPos;

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
    }
}

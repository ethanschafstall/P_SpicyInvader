using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    /// <summary>
    /// SmartEntity are all objects that are "Alive", so they don't just move but also interact with other objects (player and enemies).
    /// </summary>
    public class SmartEntity : MovableEntity
    {
        /// <summary>
        /// The weapon it uses have/use
        /// </summary>
        public WeaponType Weapon { get; set; }

        /// <summary>
        /// It's healthpoints.
        /// </summary>
        public int HealthPoints { get; set; }

        /// <summary>
        /// The direction it is facing
        /// </summary>
        public Direction FaceDirection { get; set; }

        /// <summary>
        /// The shoot x position (where the bullet will exit the entity)
        /// </summary>
        public int ShootXPos { get; set; }

        /// <summary>
        /// The shoot y position (where the bullet will exit the entity)
        /// </summary>
        public int ShootYPos { get; set; }

        /// <summary>
        /// How large the entity is.
        /// </summary>
        public int EntityWidth { get; set; }

        /// <summary>
        /// Bool for if the entity is alive or dead.
        /// </summary>
        public bool IsAlive { get; set; } = true;

        /// <summary>
        /// If the entity has been hit by a projectile. 
        /// </summary>
        public bool IsHit { get; set; } = false;

        protected SmartEntity()
        {
        }
        /// <summary>
        /// Shoot method that generates a projectile object based on shoot x/y pos and weapon type.
        /// </summary>
        /// <returns>A projectile</returns>
        public Projectile Shoot()
        {
            ShootXPos = Position.X;
            ShootYPos = Position.Y;

            switch (Weapon)
            {
                default:
                    return new Bullet(ShootXPos, ShootYPos, FaceDirection);
                    break;
                case WeaponType.Gun:
                    return new Bullet(ShootXPos, ShootYPos, FaceDirection);
                    break;
                case WeaponType.MissileLauncher:
                    return new Missile(ShootXPos, ShootYPos, FaceDirection);
                    break;
                case WeaponType.LaserGun:
                    return new Laser(ShootXPos, ShootYPos, FaceDirection);
                    break;
            }
        }

        /// <summary>
        /// Virtual hit method for when an entity is hit by a projetile.
        /// </summary>
        /// <param name="projectile">The projectile which hit the entity.</param>
        public virtual void Hit(Projectile projectile) 
        { 

        }
    }
}

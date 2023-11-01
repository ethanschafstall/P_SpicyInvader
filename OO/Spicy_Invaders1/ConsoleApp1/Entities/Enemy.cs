using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// Enemy Class which is a SmartEntity
    /// </summary>
    public class Enemy : SmartEntity
    {
        /// <summary>
        /// The enemy's type
        /// </summary>
        public EnemyType Type { get; }

        /// <summary>
        /// What explosion level it's at.
        /// </summary>
        public int ExplosionLevel { get; set; } = 0;
        /// <summary>
        /// if the enemy can fire projectiles
        /// </summary>
        public bool CanFire { get; set; }

        /// <summary>
        /// The amount of points a enemy gives when destoryed-
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Constructor for enemies which sets the different attributs based on the enemy type.
        /// </summary>
        /// <param name="x">current x pos</param>
        /// <param name="y">current y pos</param>
        /// <param name="type">the type of enemy</param>
        /// <param name="direction">current travling direction</param>
        public Enemy(int x, int y, EnemyType type, Direction direction = Direction.Right)
        {
            this.TravelDirection = direction;
            this.Type = type;
            this.FaceDirection = Direction.Down;
            this.Position = new Vector(x, y);
            this.Velocity = new Vector(1,1);
            this.Weapon = WeaponType.Gun;
            switch (type)
            {
                case EnemyType.Strawberry:
                    this.HealthPoints = 50;
                    this.EntityWidth = 3;
                    this.Points = 10;
                    break;
                case EnemyType.Banana:
                    this.HealthPoints = 75;
                    this.EntityWidth = 3;
                    this.Points = 20;
                    break;
                case EnemyType.Grape:
                    this.HealthPoints = 105;
                    this.EntityWidth = 3;
                    this.Points = 40;
                    break;
                case EnemyType.Melon:
                    this.HealthPoints = 200;
                    this.EntityWidth = 4;
                    this.Points = 5;
                    break;
            }
        }
        /// <summary>
        /// override for Hit method which lowers enemy's healthpoints by the projectile type's damage. If health points are zero than enemy is dead and starts to explode.
        /// </summary>
        /// <param name="projectile"></param>
        public override void Hit(Projectile projectile) 
        { 
            this.HealthPoints -= projectile.Damage;
            this.IsHit = true;
            if (HealthPoints <= 0)
            {
                this.IsAlive = false;
                this.ExplosionLevel = 1;
            }
        }

    }
}

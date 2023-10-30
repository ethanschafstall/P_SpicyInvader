using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Enemy : SmartEntity
    {
        public EnemyType Type { get; }

        public int ExplosionLevel { get; set; } = 0;
        public bool CanFire { get; set; }

        public int Points { get; set; }

        public Enemy(int x, int y, EnemyType type, Direction direction = Direction.Right)
        {
            this.TravelDirection = direction;
            this.Type = type;
            this.FaceDirection = Direction.Down;
            this.Position = new Vector(x, y);
            this.Velocity = new Vector();
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

        public override void Hit(Projectile projectile) 
        { 
            this.HealthPoints -= projectile.Damage;
            this.ShowHitAnimation = true;
            if (HealthPoints <= 0)
            {
                this.IsAlive = false;
                this.ExplosionLevel = 1;
            }
        }

        //public Drop DropUpgrade()
        //{
        //    //return new Drop(1,1);
        //}
    }
}

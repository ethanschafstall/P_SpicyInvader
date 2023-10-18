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
            switch (this.Type)
            {
                case EnemyType.Strawberry:
                    this.HealthPoints = 50;
                    this.EntityWidth = 3;
                    break;
                case EnemyType.Banana:
                    this.HealthPoints = 100;
                    this.EntityWidth = 3;
                    break;
                case EnemyType.Grape:
                    this.HealthPoints = 150;
                    this.EntityWidth = 3;
                    break;
                case EnemyType.Melon:
                    this.HealthPoints = 200;
                    this.EntityWidth = 4;
                    break;
            }
            this.HealthPoints = this.Points;
        }

        public override void Hit(Projectile projectile) 
        { 
            this.HealthPoints -= projectile.Damage;
            this.ShowHitAnimation = true;
            if (HealthPoints <= 0)
            {
                this.IsAlive = false;
            }
        }

        //public Drop DropUpgrade()
        //{
        //    //return new Drop(1,1);
        //}
    }
}

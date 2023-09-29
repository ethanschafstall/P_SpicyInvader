using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public enum EnemyType
    {
        Strawberry = 1,
        Banana = 2,
        Grape = 3,
        Melon = 4
    }
    public class Enemy : SmartEntity
    {

        public EnemyType enemyType { get; }

        public bool CanFire { get; set; }

        public Enemy(int x, int y, EnemyType type, Direction direction = Direction.Right)
        {
            CurrentDirection = direction;
            enemyType = type;
            FaceDirection = Direction.Down;
            Position = new Vector(x, y);
            Velocity = new Vector();
            weaponType = WeaponType.Gun;
        }

        //public Drop DropUpgrade()
        //{
        //    //return new Drop(1,1);
        //}
    }
}

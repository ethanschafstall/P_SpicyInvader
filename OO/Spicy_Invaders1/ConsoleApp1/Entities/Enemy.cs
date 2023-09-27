using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Enemy : SmartEntity
    {
        public enum EnemyType
        {
            Strawberry = 50,
            Banana = 100,
            Grape = 150,
            Melon = 200
        }

        public EnemyType enemyType;

        public bool CanFire;

        public Enemy(int x, int y, EnemyType type, Direction direction = Direction.Right)
        {
            CurrentDirection = direction;
            XPos = x;
            YPos = y;
            enemyType = type;
            HealthPoints = (int)type;
            weaponType = WeaponType.Gun;
            FaceDirection = Direction.Down;
            if (type == EnemyType.Melon)
            {
                VerticalMoveSpeed = 3;
                HorizontalMoveSpeed = 3;
                CanFire = false; 
            }
            else
            {
                CanFire = true;
            }
        }

        //public Drop DropUpgrade()
        //{
        //    //return new Drop(1,1);
        //}
    }
}

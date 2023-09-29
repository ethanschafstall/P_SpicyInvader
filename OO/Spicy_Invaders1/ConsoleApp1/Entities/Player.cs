using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Player : SmartEntity
    {
        public Player() 
        {
        }
        public Player(int x, int y) 
        {
            Position = new Vector(x, y);
            Velocity = new Vector(1, 1);
            weaponType = WeaponType.MissileLauncher;
            FaceDirection = Direction.Up;
        }  
    }
}

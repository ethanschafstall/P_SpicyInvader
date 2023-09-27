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
            XPos = x;
            YPos = y;
            weaponType = WeaponType.Gun;
            FaceDirection = Direction.Up;
        }
    }
}

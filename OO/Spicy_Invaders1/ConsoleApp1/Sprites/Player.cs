using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Player : Sprite
    {
        public Player() { }
        
        public void Upgrade(Drop drop) 
        {
            switch (drop.dropType)
            {
                case Drop.DropType.weaponUpgrade:
                    break;
                default:
                    break;
            }
        }
    }
}

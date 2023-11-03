using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// PlayerShip Classes which inherits from SmartEntity
    /// </summary>
    public class PlayerShip : SmartEntity
    {
        /// <summary>
        /// Constructor, x/y are it's starting positions.
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public PlayerShip(int x, int y) 
        {
            this.Position = new Vector(x, y);
            this.Velocity = new Vector(2, 1);
            this.FaceDirection = Direction.Up;
            this.HealthPoints = 3;
            this.EntityWidth = 2;
        }
        /// <summary>
        /// override Hit method, if the playership is hit than IsHit becomes true, healthPoints are lowered by 1. player is dead if healthpoints is zero.
        /// </summary>
        /// <param name="projectile"></param>
        public override void Hit(Projectile projectile) 
        {
            this.IsHit = true;
            this.HealthPoints -= 1;
            if (HealthPoints <= 0)
            {
                this.IsAlive = false;
                
            }
        }
    }
}

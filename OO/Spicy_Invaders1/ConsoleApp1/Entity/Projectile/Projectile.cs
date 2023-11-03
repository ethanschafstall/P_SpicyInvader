using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// projectile class for weapons projectiles (what comes out of the weapon). Inherent from MoveEntity.
    /// </summary>
    public class Projectile : MovableEntity
    {
        /// <summary>
        /// The amount of damage the projectile deals on contact.
        /// </summary>
        public int Damage { get; set; }

        protected Projectile() { }
    }
}

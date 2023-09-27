using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Projectile : MovableEntity
    {
        public int Damage { get; set; }
        protected Projectile() { }
    }
}

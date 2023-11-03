using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Vector Class for different x/y values using by all moveable entities.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// x value attribute
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y value attribute
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public Vector() { }
        /// <summary>
        /// constructor with x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

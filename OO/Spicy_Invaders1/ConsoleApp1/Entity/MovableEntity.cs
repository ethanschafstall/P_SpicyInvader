using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{

    /// <summary>
    /// MoveableEntity class, which is any object in the game which moves.
    /// </summary>
    public class MovableEntity
    {
        /// <summary>
        /// The direction in which the entity is moving.
        /// </summary>
        public Direction TravelDirection { get; set; }

        /// <summary>
        /// The entity's current position
        /// </summary>
        public Vector Position { get; set; }

        /// <summary>
        /// the speed by which the entity moves.
        /// </summary>
        public Vector Velocity { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected MovableEntity() { }

        /// <summary>
        /// Move Method which updates the entity's position based on it's move speed (velocity), it's current positon, and travel direction.
        /// </summary>
        /// <param name="directionToGo">Direction param if the enetity to move it in a different direction than it's current travel direction</param>
        public void Move(Direction directionToGo = Direction.None)
        {
            // if parameter == none then default to global MoveDirection variable
            if (directionToGo == Direction.None)
            {
                directionToGo = TravelDirection;
            }
            switch (directionToGo)
            {
                case Direction.Up:
                    Position.Y -= Velocity.Y;
                    break;
                case Direction.Down:
                    Position.Y += Velocity.Y;
                    break;
                case Direction.Left:
                    Position.X -= Velocity.X;
                    break;
                case Direction.Right:
                    Position.X += Velocity.X;
                    break;
            }
        }
    }
}

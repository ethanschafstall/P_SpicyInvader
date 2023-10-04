using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{

    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }
    public class MovableEntity
    {
        public Direction CurrentDirection { get; set; }

        public Vector Position { get; set; }

        public Vector Velocity { get; set; } 
        protected MovableEntity() { }
        public virtual void Move(Direction directionToGo = Direction.None)
        {
            // if parameter == none then default to global MoveDirection variable
            if (directionToGo == Direction.None)
            {
                directionToGo = CurrentDirection;
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

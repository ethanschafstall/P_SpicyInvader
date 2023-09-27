using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// Sprites are all objects that move, so this includes player, enemies, projectiles, and drops.
    /// </summary>
    public class MovableEntity
    {
        public enum Direction 
        { 
            None,
            Up,
            Down,
            Left,
            Right,
        }
        public Direction CurrentDirection { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int HorizontalMoveSpeed { get; set; } = 1;
        public int VerticalMoveSpeed { get; set; } = 1;
        protected MovableEntity() { }
        public void Move(Direction directionToGo = Direction.None)
        {
            // if parameter == none then default to global MoveDirection variable
            if (directionToGo == Direction.None)
            {
                directionToGo = CurrentDirection;
            }
                switch (directionToGo)
                {
                    case Direction.Up:
                        YPos -= VerticalMoveSpeed;
                        break;
                    case Direction.Down:
                        YPos += VerticalMoveSpeed;
                        break;
                    case Direction.Left:
                        XPos -= HorizontalMoveSpeed;
                        break;
                    case Direction.Right:
                        XPos += HorizontalMoveSpeed;
                        break;
                }
        }
    }
}
